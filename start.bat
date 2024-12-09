@echo off
echo Starting Angular frontend and C# backend...

:: Przejdź do katalogu frontend
cd /d "TredersToDoListApp\ClientApp"
echo Starting Angular frontend...
start cmd /k "ng serve"

:: Otwórz przeglądarkę z adresem http://localhost:4200
timeout /t 5 > nul
start http://localhost:4200

:: Przejdź do katalogu backend
cd /d ".."
echo Starting C# backend...
start cmd /k "dotnet run"

echo Both frontend and backend are starting...
pause
