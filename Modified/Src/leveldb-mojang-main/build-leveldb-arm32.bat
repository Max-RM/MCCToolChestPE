@echo off
setlocal EnableExtensions EnableDelayedExpansion

set "ROOT=%~dp0"
set "ROOT=%ROOT:~0,-1%"
set "BUILD_DIR=%ROOT%\build-arm32"
set "OUT_DLL=%ROOT%\..\LevelDB-MCPE-ARM32.dll"
set "CMAKE_DIR=%ROOT%\mcpe-dll"

where cmake >nul 2>&1
if errorlevel 1 (
  echo ERROR: cmake not found. Install CMake and add it to PATH.
  exit /b 1
)

set "VSWHERE=%ProgramFiles(x86)%\Microsoft Visual Studio\Installer\vswhere.exe"
set "VCVARS="
if exist "%VSWHERE%" (
  for /f "usebackq delims=" %%I in (`"%VSWHERE%" -latest -products * -requires Microsoft.VisualStudio.Component.VC.Tools.x86.x64 -property installationPath`) do (
    set "VCVARS=%%I\VC\Auxiliary\Build\vcvarsall.bat"
  )
)
if not defined VCVARS (
  if exist "%ProgramFiles%\Microsoft Visual Studio\2022\Community\VC\Auxiliary\Build\vcvarsall.bat" (
    set "VCVARS=%ProgramFiles%\Microsoft Visual Studio\2022\Community\VC\Auxiliary\Build\vcvarsall.bat"
  )
)
if not exist "%VCVARS%" (
  echo ERROR: Visual Studio C++ toolchain not found.
  exit /b 1
)

call "%VCVARS%" x86_arm >nul
if errorlevel 1 (
  echo ERROR: Failed to initialize ARM32 cross-compiler environment.
  echo Install VS 2022 with C++ desktop workload and an older Windows 10 SDK ^(10.0.22621^) that still ships ARM32 libs.
  exit /b 1
)

if exist "%BUILD_DIR%" rmdir /s /q "%BUILD_DIR%"
mkdir "%BUILD_DIR%"

set "SDK_VERSION="
if defined WindowsSDKVersion set "SDK_VERSION=%WindowsSDKVersion:~0,-1%"
if not defined SDK_VERSION (
  for /f "delims=" %%V in ('dir /b /ad /o-n "%ProgramFiles(x86)%\Windows Kits\10\Lib" 2^>nul ^| findstr /r "^10\."') do (
    if not defined SDK_VERSION set "SDK_VERSION=%%V"
  )
)
if not defined SDK_VERSION (
  echo ERROR: Windows 10 SDK not found.
  exit /b 1
)

echo Using Windows SDK %SDK_VERSION%
echo Configuring LevelDB for ARM32...

cmake -S "%CMAKE_DIR%" -B "%BUILD_DIR%" -G "Visual Studio 17 2022" -A ARM -T v143 ^
  -DCMAKE_SYSTEM_NAME=Windows ^
  -DCMAKE_SYSTEM_VERSION=10.0 ^
  -DCMAKE_VS_WINDOWS_TARGET_PLATFORM_VERSION=%SDK_VERSION%
if errorlevel 1 exit /b 1

echo Building Release...
cmake --build "%BUILD_DIR%" --config Release --target leveldb
if errorlevel 1 exit /b 1

set "BUILT_DLL=%BUILD_DIR%\leveldb\Release\LevelDB-MCPE-ARM32.dll"
if not exist "%BUILT_DLL%" (
  echo ERROR: Built DLL not found: %BUILT_DLL%
  exit /b 1
)

copy /Y "%BUILT_DLL%" "%OUT_DLL%" >nul
if errorlevel 1 (
  echo ERROR: Failed to copy DLL to %OUT_DLL%
  exit /b 1
)

set "ZLIB_DLL=%BUILD_DIR%\_deps\zlib-build\Release\zlib.dll"
set "OUT_ZLIB=%ROOT%\..\zlib-arm32.dll"
if exist "%ZLIB_DLL%" (
  copy /Y "%ZLIB_DLL%" "%OUT_ZLIB%" >nul
)
echo.
echo ARM32 LevelDB build succeeded.
echo Output: %OUT_DLL%
exit /b 0
