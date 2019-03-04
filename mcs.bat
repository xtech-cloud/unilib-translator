@echo off

set libpath=.\_bin\
::----------------------------------
set name=uniTranslator
set depref=
set libref=.\unitysln\Translator\Assets\3rd\uniSimpleJSON-v1.0.dll;
::----------------------------------
MD %libpath%
set outfile=%libpath%\%name%.dll
set srcpath=.\unitysln\Translator\Assets\XTC\Translator\Scripts
call "%UNITY_ROOT%\Editor\Data\Mono\bin\smcs" -target:library -r:"%UNITY_ROOT%\Editor\Data\Managed\UnityEngine.dll";"%UNITY_ROOT%\Editor\Data\UnityExtensions\Unity\GUISystem\UnityEngine.UI.dll" -out:%outfile% -recurse:%srcpath%\*.cs -reference:%depref%;%libref%
echo FINISH
pause
exit