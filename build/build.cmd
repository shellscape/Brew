@echo Off
set config=%1
set startdir = %cd%
if "%config%" == "" (
   set config=Debug
)

pushd ..\grunt\
call grunt.cmd

pushd ..\.nuget
call nuget.cmd %config%

popd
popd