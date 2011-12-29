Include bld\CompileSource.ps1
Include bld\Generic-Compile.ps1

function Compile-CommandProcessor
{
    $sourceFiles = "CommandProcessor" | Get-FilesToCompile

    $referenceAssemblies = @() + `
        "lib\nservicebus\lib\net40\NServiceBus.dll" + `
        "lib\nservicebus\lib\net40\NServiceBus.Core.dll" + `
        "lib\nservicebus\lib\net40\NServiceBus.Host.exe" + `
        $commandsFile + `
        $eventsFile

    Generic-Compile $commandProcessorFile $sourceFiles $referenceAssemblies
}
