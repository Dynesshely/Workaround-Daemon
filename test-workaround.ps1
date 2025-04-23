$UtilsPath = "./Workaround/bin/Debug/net8.0/Utils"

if (!(Test-Path -Path $UtilsPath)) {
    New-Item -ItemType Directory -Path $UtilsPath
}

$UtilsPath = Resolve-Path -Path $UtilsPath

Push-Location ./Workaround.Utils

Get-ChildItem -Directory | ForEach-Object {
    Write-Host "Entering: $_"

    $dirName = $_.Name
    Write-Host "Directory Name: $dirName"

    Push-Location $_.FullName

    Write-Host "Executing: dotnet build"
    dotnet build

    Push-Location ./bin/Debug/net8.0

    Copy-Item -Path "$dirName.dll" -Destination $UtilsPath
    Write-Host "Copied file: $dirName.dll to $UtilsPath"

    Pop-Location

    Pop-Location
}

Pop-Location

Write-Host "All done."
