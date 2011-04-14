$apiKey = Get-Content apikey.txt
$packageFiles = (Get-ChildItem -Filter *.nupkg -Path Funq.NuGet\bin)
$packageFiles | %{ Funq.NuGet\packages\NuGet.CommandLine.1.2.20401.11\Tools\NuGet.exe push -source http://packages.nuget.org/v1/ $_.FullName $apiKey }
