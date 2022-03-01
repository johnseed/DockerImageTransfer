# Docker image transfer

Save and load images from the Docker.

### Publish
    $ dotnet publish -c Release -r linux-x64 -p:PublishSingleFile=true -p:PublishTrimmed=true
    $ dotnet publish -c Release -r win-x64 -p:PublishSingleFile=true -p:PublishTrimmed=true -p:IncludeNativeLibrariesForSelfExtract=true  -p:PublishReadyToRun=true -p:PublishReadyToRunComposite=true