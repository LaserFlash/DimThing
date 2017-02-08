@ECHO OFF
SETLOCAL

IF "%PROCESSOR_ARCHITECTURE%"=="x86" (set progfiles86=L:\Program Files) else (set progfiles86=L:\Program Files ^(x86^))
set innosetup="%progfiles86%\Inno Setup 5\ISCC.exe"

if not exist %innosetup% (
  echo Error: Inno is not installed
  goto Quit
)
ECHO Using compiler executable '%innosetup%'.

del Output\*.exe
echo Making Installer

%innosetup% setup.iss
if not "%ERRORLEVEL%"=="0" echo error: innosetup failed & goto Quit

goto Done
:Quit

exit /b 1

:Done