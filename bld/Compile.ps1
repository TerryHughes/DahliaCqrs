pushd
Split-Path $MyInvocation.MyCommand.Path | cd

Include MakeDirectory.ps1
Include GenericCompile.ps1
Include CompileOne.ps1
Include CompileTwo.ps1
Include CompileSource.ps1

popd


$foobar = "comp"
Task Compile -preaction { MakeDirectory "bin" } -depends CompileOne, CompileTwo {
write-host compile says $foobar
    $frameworkFile = "bin\$applicationName.Framework.dll"
    $eventsFile = "bin\$applicationName.Events.dll"
    $commandsFile = "bin\$applicationName.Commands.dll"
    $commandProcessorFile = "bin\$applicationName.CommandProcessor.dll"
    $dataCommonFile = "bin\$applicationName.Data.Common.dll"
    $dataStoreFile = "bin\$applicationName.DataStore.dll"
    $dataSqlClientFile = "bin\$applicationName.Data.SqlClient.dll"
    $dataSqliteFile = "$applicationName.Data.SQLite.dll"
    $webApplicationFile = "bin\$applicationName.WebApplication.dll"
    $specsFile = "bin\$applicationName.Specs.dll"

    $sharedAssemblyFile = "src\SharedAssemblyInfo.cs"

    $frameworkSourceFiles = "Framework" | Get-FilesToCompile
    $eventsSourceFiles = "Events" | Get-FilesToCompile
    $commandsSourceFiles = "Commands" | Get-FilesToCompile
    $commandProcessorSourceFiles = "CommandProcessor" | Get-FilesToCompile
    $dataCommonSourceFiles = "Data", "Data.Common" | Get-FilesToCompile
    $dataStoreSourceFiles = "DataStore" | Get-FilesToCompile
    $dataSqlClientSourceFiles = "Data.SqlClient" | Get-FilesToCompile
    $dataSqliteSourceFiles = "Data.SQLite" | Get-FilesToCompile
    $webApplicationSourceFiles = "Web.Mvc", "Web.Mvc.NServiceBus", "WebApplication" | Get-FilesToCompile
    $specsSourceFiles = "." | CorrectPath | Get-SourceFiles | Remove-NonSpecFiles | Add-SharedAssemblyInfo | Printable

    $version = $null
    $frameworkVersion = $framework.Substring(0, 3)
    switch ($frameworkVersion) {
        "4.0" {
            $version = @("v4.0.30319")
        }
    }

    $bitness = $null
    $nsbBitness = "net40"
    switch ($framework.Substring(3)) {
        "x86" {
            $bitness = "Framework"
            $nsbBitness = "net40\x86"
        }
        "x64" {
            $bitness = "Framework64"
        }
        $null {
            $ptrSize = [System.IntPtr]::Size
            switch ($ptrSize) {
                4 {
                    $bitness = "Framework"
                    $nsbBitness = "net40\x86"
                }
                8 {
                    $bitness = "Framework64"
                }
            }
        }
    }

    $eventsReferenceAssemblies = @() + `
        $frameworkFile + `
        "lib\nservicebus\lib\net40\NServiceBus.dll"

    $commandsReferenceAssemblies = @() + `
        $frameworkFile + `
        "lib\nservicebus\lib\net40\NServiceBus.dll"

    $commandProcessorReferenceAssemblies = @() + `
        $commandsFile + `
        $eventsFile + `
        "lib\nservicebus\lib\net40\NServiceBus.dll" + `
        "lib\nservicebus\lib\net40\NServiceBus.Core.dll" + `
        "lib\nservicebus\lib\net40\NServiceBus.Host.exe"

    $dataCommonReferenceAssemblies = @() + `
        $frameworkFile + `
        "$env:windir\Microsoft.NET\$bitness\$version\System.ComponentModel.Composition.dll"

    $dataStoreReferenceAssemblies = @() + `
        $frameworkFile + `
        $eventsFile + `
        $dataCommonFile + `
        "lib\nservicebus\lib\net40\NServiceBus.dll" + `
        "lib\nservicebus\lib\net40\NServiceBus.Host.exe"

    $dataSqlClientReferenceAssemblies = @() + `
        $frameworkFile + `
        "$env:windir\Microsoft.NET\$bitness\$version\System.ComponentModel.Composition.dll" + `
        $dataCommonFile

    $dataSqliteReferenceAssemblies = @() + `
        $frameworkFile + `
        "$env:windir\Microsoft.NET\$bitness\$version\System.ComponentModel.Composition.dll" + `
        $dataCommonFile

    $dataSqlite86ReferenceAssemblies = @($dataSqliteReferenceAssemblies) + `
        "lib\System.Data.SQLite.x86\lib\net40\System.Data.SQLite.dll"

    $dataSqlite64ReferenceAssemblies = @($dataSqliteReferenceAssemblies) + `
        "lib\System.Data.SQLite.x64\lib\net40\System.Data.SQLite.dll"

    $webApplicationReferenceAssemblies = @() + `
        $commandsFile + `
        "lib\MvcContrib.Mvc3-ci\lib\MvcContrib.dll" + `
        "ref\Microsoft ASP.NET\ASP.NET MVC 3\Assemblies\System.Web.Mvc.dll" + `
        "lib\nservicebus\lib\net40\NServiceBus.Core.dll" + `
        "lib\nservicebus\lib\net40\NServiceBus.dll" + `
        "lib\nservicebus\lib\net40\log4net.dll" + `
        $dataCommonFile + `
        $frameworkFile

    $specsReferenceAssemblies = @() + `
        "lib\Machine.Specifications\lib\Machine.Specifications.dll" + `
        $frameworkFile + `
        $webApplicationFile + `
        "ref\Microsoft ASP.NET\ASP.NET MVC 3\Assemblies\System.Web.Mvc.dll" + `
        $eventsFile + `
        "lib\nservicebus\lib\net40\NServiceBus.dll"


    GenericCompile $frameworkFile $frameworkSourceFiles
    GenericCompile $eventsFile $eventsSourceFiles $eventsReferenceAssemblies
    GenericCompile $commandsFile $commandsSourceFiles $commandsReferenceAssemblies
    GenericCompile $commandProcessorFile $commandProcessorSourceFiles $commandProcessorReferenceAssemblies
    GenericCompile $dataCommonFile $dataCommonSourceFiles $dataCommonReferenceAssemblies
    GenericCompile $dataStoreFile $dataStoreSourceFiles $dataStoreReferenceAssemblies
    GenericCompile $dataSqlClientFile $dataSqlClientSourceFiles $dataSqlClientReferenceAssemblies
    GenericCompile $webApplicationFile $webApplicationSourceFiles $webApplicationReferenceAssemblies

    MakeDirectory "bin\x86"
    MakeDirectory "bin\x64"

    $sqlite = @{}
    $sqlite.sourceFiles = $dataSqliteSourceFiles

    $sqlite.referenceAssemblies = $dataSqlite86ReferenceAssemblies
    $sqlite.outFile = "bin\x86\$dataSqliteFile"
    $frameworkVersion86 = $frameworkVersion + "x86"
    Invoke-psake "bld\BitnessCompile.ps1" "BitnessCompile" $frameworkVersion86 -parameters $sqlite | Out-Null

    $sqlite.referenceAssemblies = $dataSqlite64ReferenceAssemblies
    $sqlite.outFile = "bin\x64\$dataSqliteFile"
    $frameworkVersion64 = $frameworkVersion + "x64"
    Invoke-psake "bld\BitnessCompile.ps1" "BitnessCompile" $frameworkVersion64 -parameters $sqlite | Out-Null

    cpi "lib\System.Data.SQLite.x86\lib\net40\System.Data.SQLite.dll" "bin\x86"
    cpi "lib\System.Data.SQLite.x64\lib\net40\System.Data.SQLite.dll" "bin\x64"

    GenericCompile $specsFile $specsSourceFiles $specsReferenceAssemblies

    Exec { msbuild /t:"TransformWebConfig" /p:"IntermediateOutputPath=bin\" /p:"Configuration=$configuration" /v:"q" /nologo "transform.proj" }

    if ($configuration -eq "Release" -or $views -ne $null) {
        MakeDirectory "src\WebApplication\bin"

        cpi "bin\Dahlia.*.dll" "src\WebApplication\bin" -ex "*Specs*"
        Exec { msbuild /t:"MvcBuildViews" /v:"q" /nologo "tgt\views.proj" }
# need a try catch finally to remove the bin directory?
        RemoveDirectory "src\WebApplication\bin"
    }
}
