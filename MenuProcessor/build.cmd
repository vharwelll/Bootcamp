@echo off

rem this was causing some platform build errors for me, so turning it off to be safe
set platform=

msbuild /nologo /v:normal /t:Clean,Rebuild /p:Configuration=Release
if errorlevel 1 goto BUILD_ERROR

mstest /testcontainer:MenuProcessorUnitTests/bin/Release/MenuProcessorUnitTests.dll
if errorlevel 1 goto TEST_ERROR

goto END

:BUILD_ERROR
echo
echo Errors in build; stopping
goto END

:TEST_ERROR
echo
echo Errors in unit testing; stopping
goto END

:END