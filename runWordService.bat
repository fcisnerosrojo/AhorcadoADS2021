set pwd=%cd%
set proyect=F:\Facultad\ASW\Repositorio_GIT\AhorcadoADS2021
set virtualEnv=Microservicios\venv\Scripts
set wordService=Microservicios\WordService\WordService.py

@echo off

cmd /k "cd /d %pwd%\%virtualEnv% & activate.bat & cd /d %proyect% & python %proyect%\%wordService% "
