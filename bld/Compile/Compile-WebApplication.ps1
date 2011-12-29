Include bld\CompileSource.ps1
Include bld\GenericCompile.ps1
Include bld\Make-Directory.ps1

function Compile-WebApplication
{
    $sourceFiles = "Web.Mvc", "Web.Mvc.NServiceBus", "WebApplication" | Get-FilesToCompile

    $referenceAssemblies = @() + `
        "ref\Microsoft ASP.NET\ASP.NET MVC 3\Assemblies\System.Web.Mvc.dll" + `
        "lib\MvcContrib.Mvc3-ci\lib\MvcContrib.dll" + `
        "lib\nservicebus\lib\net40\log4net.dll" + `
        "lib\nservicebus\lib\net40\NServiceBus.dll" + `
        "lib\nservicebus\lib\net40\NServiceBus.Core.dll" + `
        $frameworkFile + `
        $dataCommonFile + `
        $commandsFile

    GenericCompile $webApplicationFile $sourceFiles $referenceAssemblies

# TODO: clean up post compile stuff
    Exec { msbuild /t:"TransformWebConfig" /p:"IntermediateOutputPath=bin\" /p:"Configuration=$configuration" /v:"q" /nologo "transform.proj" }

    if ($configuration -eq "Release" -or $views -ne $null) {
        Make-Directory "src\WebApplication\bin"

        cpi "bin\Dahlia.*.dll" "src\WebApplication\bin" -ex "*Specs*"
        Exec { msbuild /t:"MvcBuildViews" /v:"q" /nologo "tgt\views.proj" }
# need a try catch finally to remove the bin directory?
        RemoveDirectory "src\WebApplication\bin"
    }
}
