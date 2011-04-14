pushd bin\NuGet\Funq
..\..\..\packages\NuGet.CommandLine.1.2.20401.11\Tools\NuGet.exe pack Funq.nuspec -OutputDirectory ..\..
popd
pushd bin\NuGet\Funqlet
..\..\..\packages\NuGet.CommandLine.1.2.20401.11\Tools\NuGet.exe pack Funqlet.nuspec -OutputDirectory ..\..
popd
