Include bld\CompileSource.ps1
Include bld\GenericCompile.ps1

function Compile-Specs
{
    $sourceFiles = "." | CorrectPath | Get-SourceFiles | Remove-NonSpecFiles | Add-SharedAssemblyInfo | Printable

    $referenceAssemblies = @() + `
        "ref\Microsoft ASP.NET\ASP.NET MVC 3\Assemblies\System.Web.Mvc.dll" + `
        "lib\nservicebus\lib\net40\NServiceBus.dll" + `
        "lib\Machine.Specifications\lib\Machine.Specifications.dll" + `
        $frameworkFile + `
        $eventsFile + `
        $webApplicationFile

    GenericCompile $specsFile $sourceFiles $referenceAssemblies
}
