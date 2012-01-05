Include bld\Utilities\Get-FilesToCompile.ps1
Include bld\Utilities\Generic-Compile.ps1

function Compile-CommandProcessor
{
    $sourceFiles = "CommandProcessor" | Get-FilesToCompile

    $referenceAssemblies = @() + `
        "lib\nservicebus\lib\net40\NServiceBus.dll" + `
        "lib\nservicebus\lib\net40\NServiceBus.Core.dll" + `
        "lib\nservicebus\lib\net40\NServiceBus.Host.exe" + `
        $commandsFile + `
        $eventsFile + `
        $domainFile + `
        $eventStoresFile + `
        $frameworkFile + `
        $dataCommonFile

    Generic-Compile $commandProcessorFile $sourceFiles $referenceAssemblies
}
