# Build MCCToolChestPE for Windows x86 (32-bit native)
param(
    [string]$Configuration = "Release"
)

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

dotnet restore (Join-Path $exeProject "MCCToolChestPE.csproj") -r win7-x86 | Out-Null
& $msbuild (Join-Path $exeProject "MCCToolChestPE.csproj") /p:Configuration=$Configuration /p:PlatformTarget=x86 /p:Prefer32Bit=true /v:minimal
if ($LASTEXITCODE -ne 0) { exit $LASTEXITCODE }

$outDir = Join-Path $exeProject "bin\$Configuration\net45"
Write-Host ""
Write-Host "x86 build succeeded."
Write-Host "Output: $outDir\MCCToolChestPE.exe"
