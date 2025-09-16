@echo off

REM Location of your SpaceEngineers.exe
mklink /J Bin64 "D:\SteamLibrary\steamapps\common\SpaceEngineers\Bin64"

REM Location of your workshop
mklink /J workshop "D:\SteamLibrary\steamapps\workshop"

pause
