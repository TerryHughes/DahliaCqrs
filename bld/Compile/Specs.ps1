Include bld\Utilities\Get-FilesToCompile.ps1
Include bld\Utilities\Generic-Compile.ps1

function Compile-Specs
{
    $sourceFiles = "." | CorrectPath | Get-SourceFiles | Remove-NonSpecFiles | Add-SharedAssemblyInfo | Printable

    $referenceAssemblies = @() + `
        "ref\Microsoft ASP.NET\ASP.NET MVC 3\Assemblies\System.Web.Mvc.dll" + `
        "lib\nservicebus\lib\net40\NServiceBus.dll" + `
        "lib\Machine.Specifications\lib\Machine.Specifications.dll" + `
        $frameworkFile + `
        $eventsFile + `
#        $domainFile + `
        $commandsFile + `
        $commandProcessorFile + `
        $webApplicationFile

    Generic-Compile $specsFile $sourceFiles $referenceAssemblies
}
