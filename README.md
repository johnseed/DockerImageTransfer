# Docker image transfer

Save and load docker images in bulk.

### Publish
    $ dotnet publish -c Release -r linux-x64 -p:PublishSingleFile=true --self-contained -p:PublishTrimmed=true -p:PublishReadyToRun=true -p:PublishReadyToRunComposite=true
    $ dotnet publish -c Release -r win-x64 -p:PublishSingleFile=true -p:PublishTrimmed=true -p:IncludeNativeLibrariesForSelfExtract=true  -p:PublishReadyToRun=true -p:PublishReadyToRunComposite=true
    $ dotnet publish -c Release -r osx.11.0-arm64 --no-self-contained -p:PublishSingleFile=true
