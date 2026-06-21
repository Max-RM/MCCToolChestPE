# Build MCCToolChestPE from source (Any CPU IL, runs as 64-bit on x64 Windows)
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
& $msbuild $sln /p:Configuration=Release /v:minimal
if ($LASTEXITCODE -ne 0) { exit $LASTEXITCODE }

$outDir = Join-Path $exeProject "bin\Release\net45"
Write-Host ""
Write-Host "Build succeeded."
Write-Host "Output: $outDir\MCCToolChestPE.exe"
