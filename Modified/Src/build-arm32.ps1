# Build MCCToolChestPE for Windows ARM32 (requires Visual Studio 2022 MSBuild)
$msbuild = "${env:ProgramFiles}\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe"
if (-not (Test-Path $msbuild)) {
    $msbuild = "${env:ProgramFiles(x86)}\Microsoft Visual Studio\2022\BuildTools\MSBuild\Current\Bin\MSBuild.exe"
}
if (-not (Test-Path $msbuild)) {
    Write-Error "MSBuild not found. Install Visual Studio 2022 with .NET desktop development workload."
    exit 1
}

$root = Split-Path $PSScriptRoot -Parent
$exeProject = Join-Path $root "Src\MCCToolChestPE_exe"
$arm32Dll = Join-Path $root "Src\LevelDB-MCPE-ARM32.dll"
if (-not (Test-Path $arm32Dll) -or (Get-Item $arm32Dll).Length -lt 1024) {
    Write-Host "LevelDB ARM32 DLL missing or empty. Building from leveldb-mojang-main..."
    $bat = Join-Path $root "Src\leveldb-mojang-main\build-leveldb-arm32.bat"
    & cmd /c "`"$bat`""
    if ($LASTEXITCODE -ne 0) { exit $LASTEXITCODE }
}

$required = @(
    "56VNfxQrwOeY2geE3i.76YChJEysnAtodwYU0",
    "UXXDn3cvaSJiMtEimR.14FmER7TIdULJkLVey",
    "obfuscator_payload.dll"
)
$missing = $required | Where-Object { -not (Test-Path (Join-Path $exeProject $_)) }
if ($missing) {
    if ($missing -contains "obfuscator_payload.dll") {
        Write-Host "Extracting obfuscator payload from original MCCToolChestPE.exe..."
        dotnet run --project (Join-Path $PSScriptRoot "tools\ExtractPayload\ExtractPayload.csproj") -c Release -- `
            (Join-Path $root "MCCToolChestPE.exe") `
            (Join-Path $exeProject "obfuscator_payload.dll")
    }
    $missingResources = $missing | Where-Object { $_ -ne "obfuscator_payload.dll" }
    if ($missingResources) {
        Write-Host "Extracting obfuscator embedded resources from original MCCToolChestPE.exe..."
        & (Join-Path $PSScriptRoot "tools\extract-resources.ps1")
    }
}

$sln = Join-Path $root "Src\MCCToolChestPE.sln"
& $msbuild $sln /t:Rebuild /p:Configuration=Release /p:Platform=ARM /v:minimal
if ($LASTEXITCODE -ne 0) { exit $LASTEXITCODE }

$outDir = Join-Path $exeProject "bin\ARM\Release\net472"
$managedDlls = @(
    "NBTExplorerWrapper.dll",
    "Substrate.dll",
    "NBTModel.dll",
    "ClearScript.dll",
    "FastColoredTextBox.dll",
    "NAppUpdate.Framework.dll"
)
foreach ($dll in $managedDlls) {
    $path = Join-Path $outDir $dll
    if (-not (Test-Path $path)) {
        Write-Error "ARM32 build output missing $dll"
        exit 1
    }
    $bytes = [System.IO.File]::ReadAllBytes($path)
    $peOffset = [BitConverter]::ToInt32($bytes, 0x3C)
    $machine = [BitConverter]::ToUInt16($bytes, $peOffset + 4)
    if ($machine -ne 0x01c4) {
        Write-Error "ARM32 build produced wrong architecture for ${dll}: expected ARM32 (0x01C4), got 0x{0:X4}. Run build-arm32.ps1 after x64 builds, or delete bin/obj under Src." -f $machine
        exit 1
    }
}

Write-Host ""
Write-Host "ARM32 build succeeded."
Write-Host "Output: $outDir\MCCToolChestPE.exe"
Write-Host "LevelDB: $outDir\LevelDB-MCPE-32.dll (ARM32 native)"
