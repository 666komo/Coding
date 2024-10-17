@echo off
setlocal enabledelayedexpansion

:menu
cls
echo Windows Control Panel CLI
echo =========================
echo.
echo 1. System and Security
echo 2. Network and Internet
echo 3. Hardware and Sound
echo 4. Programs
echo 5. User Accounts
echo 6. Appearance and Personalization
echo 7. Clock and Region
echo 8. Ease of Access
echo 9. Exit
echo.
set /p choice=Enter your choice (1-9): 

if "%choice%"=="1" goto system_security
if "%choice%"=="2" goto network_internet
if "%choice%"=="3" goto hardware_sound
if "%choice%"=="4" goto programs
if "%choice%"=="5" goto user_accounts
if "%choice%"=="6" goto appearance_personalization
if "%choice%"=="7" goto clock_region
if "%choice%"=="8" goto ease_access
if "%choice%"=="9" goto end
goto menu

:system_security
cls
echo System and Security
echo ===================
echo 1. Windows Update
echo 2. Windows Defender
echo 3. Backup and Restore
echo 4. Power Options
echo 5. Back to Main Menu
set /p ss_choice=Enter your choice (1-5): 
if "%ss_choice%"=="1" call :windows_update
if "%ss_choice%"=="2" call :windows_defender
if "%ss_choice%"=="3" call :backup_restore
if "%ss_choice%"=="4" call :power_options
if "%ss_choice%"=="5" goto menu
goto system_security

:network_internet
cls
echo Network and Internet
echo ====================
echo 1. Network Status
echo 2. WiFi Settings
echo 3. VPN Settings
echo 4. Ethernet
echo 5. Back to Main Menu
set /p ni_choice=Enter your choice (1-5): 
if "%ni_choice%"=="1" call :network_status
if "%ni_choice%"=="2" call :wifi_settings
if "%ni_choice%"=="3" call :vpn_settings
if "%ni_choice%"=="4" call :ethernet_settings
if "%ni_choice%"=="5" goto menu
goto network_internet

:hardware_sound
cls
echo Hardware and Sound
echo ==================
echo 1. Devices and Printers
echo 2. Sound
echo 3. Power Options
echo 4. Display
echo 5. Back to Main Menu
set /p hs_choice=Enter your choice (1-5): 
if "%hs_choice%"=="1" call :devices_printers
if "%hs_choice%"=="2" call :sound_settings
if "%hs_choice%"=="3" call :power_options
if "%hs_choice%"=="4" call :display_settings
if "%hs_choice%"=="5" goto menu
goto hardware_sound

:programs
cls
echo Programs
echo ========
echo 1. Uninstall a Program
echo 2. Programs and Features
echo 3. Default Programs
echo 4. Back to Main Menu
set /p p_choice=Enter your choice (1-4): 
if "%p_choice%"=="1" call :uninstall_program
if "%p_choice%"=="2" call :programs_features
if "%p_choice%"=="3" call :default_programs
if "%p_choice%"=="4" goto menu
goto programs

:user_accounts
cls
echo User Accounts
echo =============
echo 1. Change Account Type
echo 2. Manage Another Account
echo 3. Change User Account Control Settings
echo 4. Back to Main Menu
set /p ua_choice=Enter your choice (1-4): 
if "%ua_choice%"=="1" call :change_account_type
if "%ua_choice%"=="2" call :manage_another_account
if "%ua_choice%"=="3" call :change_uac_settings
if "%ua_choice%"=="4" goto menu
goto user_accounts

:appearance_personalization
cls
echo Appearance and Personalization
echo ==============================
echo 1. Personalization
echo 2. Display
echo 3. Taskbar
echo 4. Back to Main Menu
set /p ap_choice=Enter your choice (1-4): 
if "%ap_choice%"=="1" call :personalization
if "%ap_choice%"=="2" call :display_settings
if "%ap_choice%"=="3" call :taskbar_settings
if "%ap_choice%"=="4" goto menu
goto appearance_personalization

:clock_region
cls
echo Clock and Region
echo ================
echo 1. Date and Time
echo 2. Region
echo 3. Back to Main Menu
set /p cr_choice=Enter your choice (1-3): 
if "%cr_choice%"=="1" call :date_time_settings
if "%cr_choice%"=="2" call :region_settings
if "%cr_choice%"=="3" goto menu
goto clock_region

:ease_access
cls
echo Ease of Access
echo ==============
echo 1. Ease of Access Center
echo 2. Narrator
echo 3. Magnifier
echo 4. On-Screen Keyboard
echo 5. Back to Main Menu
set /p ea_choice=Enter your choice (1-5): 
if "%ea_choice%"=="1" call :ease_of_access_center
if "%ea_choice%"=="2" call :narrator_settings
if "%ea_choice%"=="3" call :magnifier_settings
if "%ea_choice%"=="4" call :on_screen_keyboard
if "%ea_choice%"=="5" goto menu
goto ease_access

:end
echo Exiting Windows Control Panel CLI...
exit /b

:windows_update
echo Configuring Windows Update...
powershell -Command "Start-Process ms-settings:windowsupdate -Verb RunAs"
pause
goto :eof

:windows_defender
echo Configuring Windows Defender...
powershell -Command "Start-Process windowsdefender: -Verb RunAs"
pause
goto :eof

:backup_restore
echo Configuring Backup and Restore...
powershell -Command "Start-Process sdclt -Verb RunAs"
pause
goto :eof

:power_options
echo Configuring Power Options...
powershell -Command "Start-Process powercfg.cpl -Verb RunAs"
pause
goto :eof

:network_status
echo Viewing Network Status...
powershell -Command "Start-Process ms-settings:network-status -Verb RunAs"
pause
goto :eof

:wifi_settings
echo Configuring WiFi Settings...
powershell -Command "Start-Process ms-settings:network-wifi -Verb RunAs"
pause
goto :eof

:vpn_settings
echo Configuring VPN Settings...
powershell -Command "Start-Process ms-settings:network-vpn -Verb RunAs"
pause
goto :eof

:ethernet_settings
echo Configuring Ethernet Settings...
powershell -Command "Start-Process ncpa.cpl -Verb RunAs"
pause
goto :eof

:devices_printers
echo Managing Devices and Printers...
powershell -Command "Start-Process control printers -Verb RunAs"
pause
goto :eof

:sound_settings
echo Configuring Sound Settings...
powershell -Command "Start-Process mmsys.cpl -Verb RunAs"
pause
goto :eof

:display_settings
echo Configuring Display Settings...
powershell -Command "Start-Process desk.cpl -Verb RunAs"
pause
goto :eof

:uninstall_program
echo Uninstalling Programs...
powershell -Command "Start-Process appwiz.cpl -Verb RunAs"
pause
goto :eof

:programs_features
echo Managing Programs and Features...
powershell -Command "Start-Process control appwiz.cpl -Verb RunAs"
pause
goto :eof

:default_programs
echo Setting Default Programs...
powershell -Command "Start-Process control /name Microsoft.DefaultPrograms -Verb RunAs"
pause
goto :eof

:change_account_type
echo Changing Account Type...
powershell -Command "Start-Process netplwiz -Verb RunAs"
pause
goto :eof

:manage_another_account
echo Managing Another Account...
powershell -Command "Start-Process control userpasswords -Verb RunAs"
pause
goto :eof

:change_uac_settings
echo Changing User Account Control Settings...
powershell -Command "Start-Process UserAccountControlSettings -Verb RunAs"
pause
goto :eof

:personalization
echo Configuring Personalization...
powershell -Command "Start-Process ms-settings:personalization -Verb RunAs"
pause
goto :eof

:taskbar_settings
echo Configuring Taskbar...
powershell -Command "Start-Process ms-settings:taskbar -Verb RunAs"
pause
goto :eof

:date_time_settings
echo Configuring Date and Time...
powershell -Command "Start-Process timedate.cpl -Verb RunAs"
pause
goto :eof

:region_settings
echo Configuring Region...
powershell -Command "Start-Process intl.cpl -Verb RunAs"
pause
goto :eof

:ease_of_access_center
echo Opening Ease of Access Center...
powershell -Command "Start-Process ms-settings:easeofaccess -Verb RunAs"
pause
goto :eof

:narrator_settings
echo Configuring Narrator...
powershell -Command "Start-Process Narrator -Verb RunAs"
pause
goto :eof

:magnifier_settings
echo Configuring Magnifier...
powershell -Command "Start-Process Magnify -Verb RunAs"
pause
goto :eof

:on_screen_keyboard
echo Opening On-Screen Keyboard...
powershell -Command "Start-Process osk -Verb RunAs"
pause
goto :eof
