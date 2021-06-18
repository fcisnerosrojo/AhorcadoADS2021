set pwd=%cd%
set proyect=F:\Facultad\ASW\Repositorio GIT\AhorcadoADS2021
set virtualEnv=Microservicios\venv\Scripts
set python_=C:\Users\Cande\AppData\Local\Programs\Python\Python38\python.exe
set singlePlayerService=Microservicios\SingleplayerMatchService\SingleplayerMatchService.py
set levelsService=Microservicios\LevelsService\LevelsService.py
set wordService=Microservicios\WordService\WordService.py


start "WordService" /d %pwd% "%proyect%\%wordService%"
start "MatchService" /d %pwd% "%proyect%\%singlePlayerService%"
start "LevelsService" /d %pwd% "%proyect%\%levelsService%"

@REM start "MatchService" /d %pwd% "cd %pwd%\%virtualEnv% & activate.bat & cd /d %proyect% & python %proyect%\%matchService% "
@REM start "LabelsService" /d %pwd% "cd %pwd%\%virtualEnv% & activate.bat & cd /d %proyect% & python %proyect%\%levelsService% "


@REM  cmd /k "cd /d %pwd%\%virtualEnv% & activate.bat & cd /d %proyect% & python %proyect%\%wordService% "
@REM cmd /k "cd /d %pwd%\%virtualEnv% & activate.bat & cd /d %proyect% & python %proyect%\%matchService% "
@REM cmd /k "cd /d %pwd%\%virtualEnv% & activate.bat & cd /d %proyect% & python %proyect%\%levelsService% "
