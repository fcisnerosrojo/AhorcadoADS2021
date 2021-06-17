set pwd=%cd%
set proyect=C:\Users\Cande\PROYECTOS\AhorcadoADS2021
set virtualEnv=Microservicios\venv\Scripts
set levelsService=Microservicios\LevelsService\LevelsService.py

@echo off

cmd /k "cd /d %pwd%\%virtualEnv% & activate.bat & cd /d %proyect% & python %proyect%\%levelsService% "
