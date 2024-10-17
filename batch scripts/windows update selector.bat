@echo off
:: BatchGotAdmin
:-------------------------------------
REM  --> Check for permissions
    IF "%PROCESSOR_ARCHITECTURE%" EQU "amd64" (
>nul 2>&1 "%SYSTEMROOT%\SysWOW64\cacls.exe" "%SYSTEMROOT%\SysWOW64\config\system"
) ELSE (
>nul 2>&1 "%SYSTEMROOT%\system32\cacls.exe" "%SYSTEMROOT%\system32\config\system"
)

REM --> If error flag set, we do not have admin.
if '%errorlevel%' NEQ '0' (
    echo Requesting administrative privileges...
    goto UACPrompt
) else ( goto gotAdmin )

:UACPrompt
    echo Set UAC = CreateObject^("Shell.Application"^) > "%temp%\getadmin.vbs"
    set params= %*
    echo UAC.ShellExecute "cmd.exe", "/c ""%~s0"" %params:"=""%", "", "runas", 1 >> "%temp%\getadmin.vbs"

    "%temp%\getadmin.vbs"
    del "%temp%\getadmin.vbs"
    exit /B

:gotAdmin
    pushd "%CD%"
    CD /D "%~dp0"
:--------------------------------------

:menu
cls
echo Windows Update Settings Selector
echo ================================
echo Current configuration:
for /f "tokens=3" %%a in ('reg query "HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\WindowsUpdate\Auto Update" /v AUOptions 2^>nul') do set "current_setting=%%a"
if "%current_setting%"=="1" (
    echo Updates are currently disabled
) else if "%current_setting%"=="3" (
    echo All updates are currently enabled
) else if "%current_setting%"=="4" (
    echo Security updates only are currently enabled
) else (
    echo Unable to determine current update settings
)
echo.
echo Available options:
echo 1. Enable all updates
echo 2. Enable security updates only
echo 3. Disable all updates
echo.
set /p choice=Enter your choice (1-3): 

if "%choice%"=="1" goto all_updates
if "%choice%"=="2" goto security_updates
if "%choice%"=="3" goto no_updates
goto menu

:all_updates
echo Enabling all updates...
reg add "HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\WindowsUpdate\Auto Update" /v AUOptions /t REG_DWORD /d 3 /f
echo All updates have been enabled.
pause
goto end

:security_updates
echo Enabling security updates only...
reg add "HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\WindowsUpdate\Auto Update" /v AUOptions /t REG_DWORD /d 4 /f
reg add "HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU" /v UseWUServer /t REG_DWORD /d 1 /f
reg add "HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU" /v AUOptions /t REG_DWORD /d 4 /f
echo Security updates have been enabled.
pause
goto end

:no_updates
echo WARNING: Disabling all updates can leave your system vulnerable to security threats.
echo Are you sure you want to proceed? (Y/N)
set /p confirm=
if /i "%confirm%" neq "Y" goto menu
echo Disabling all updates...
reg add "HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\WindowsUpdate\Auto Update" /v AUOptions /t REG_DWORD /d 1 /f
echo All updates have been disabled.
echo REMINDER: Your system is now at risk. Enable updates as soon as possible.
pause
goto end

:end
echo Script execution completed.
exit
