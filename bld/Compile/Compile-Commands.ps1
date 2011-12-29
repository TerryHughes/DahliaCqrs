Include bld\CompileSource.ps1
Include bld\GenericCompile.ps1

function Compile-Commands
{
    $sourceFiles = "Commands" | Get-FilesToCompile

    $referenceAssemblies = @() + `
        "lib\nservicebus\lib\net40\NServiceBus.dll" + `
        $frameworkFile

    GenericCompile $commandsFile $sourceFiles $referenceAssemblies
}
