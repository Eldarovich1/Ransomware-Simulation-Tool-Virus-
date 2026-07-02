@echo off
title  омпил€ци€ Microsoft Defender
color 0A

echo ========================================
echo    омпил€ци€ Microsoft Defender
echo ========================================
echo.

if not exist Program.cs (
    echo ? Program.cs не найден!
    pause
    exit
)

if not exist icon.ico (
    echo ? icon.ico не найден!
    pause
    exit
)

echo ? Program.cs найден
echo ? icon.ico найден
echo.

echo  омпил€ци€...
echo ========================================

REM ”бираем Microsoft.Win32.dll (она встроена в System.dll)
"C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe" /target:winexe /win32icon:icon.ico /optimize /out:"Microsoft Defender.exe" /reference:System.Windows.Forms.dll /reference:System.Drawing.dll Program.cs

if %errorlevel% == 0 (
    echo.
    echo ========================================
    echo   ?  ќћѕ»Ћя÷»я ”—ѕ≈ЎЌј!
    echo ========================================
    echo   ?? ‘айл: Microsoft Defender.exe
    echo   ?? ѕапка: %CD%
    echo   ???  »конка встроена в EXE
    echo ========================================
    echo.
    echo   ? »конка будет видна у всех!
    echo   ? ‘айл готов к использованию!
    echo ========================================
    
    start explorer /select,"Microsoft Defender.exe"
) else (
    echo.
    echo ========================================
    echo   ? ќЎ»Ѕ ј  ќћѕ»Ћя÷»»!
    echo ========================================
    echo   ѕроверьте код Program.cs на ошибки
    echo ========================================
)

echo.
pause