Include bld\Utilities\Get-FilesToCompile.ps1
Include bld\Utilities\Generic-Compile.ps1

function Compile-EventStores
{
    $sourceFiles = "EventStores" | Get-FilesToCompile

    $referenceAssemblies = @() + `
        "lib\nservicebus\lib\net40\NServiceBus.dll" + `
        $eventsFile + `
        $domainFile

    Generic-Compile $eventStoresFile $sourceFiles $referenceAssemblies
}
