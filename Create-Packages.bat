@echo off

mkdir nuget-packages

cd Sdm
nuget pack Sdm.fsproj -Build -Symbols
copy /Y *.nupkg ..\nuget-packages\

cd ..
