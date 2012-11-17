@echo off
setlocal
set BUILD_TARGET=%~1
if "%BUILD_TARGET%"=="" set /p BUILD_TARGET="Build Target: "
if not "%BUILD_TARGET%"=="" set BUILD_TARGET="/target:%BUILD_TARGET%"
msbuild40 build.xml %BUILD_TARGET%
endlocal
if errorlevel 1 pause