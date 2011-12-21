pushd
Split-Path $MyInvocation.MyCommand.Path | cd

Include MakeDirectory.ps1
Include GenericCompile.ps1

popd


Task Compile -preaction { MakeDirectory "bin" } {
    $frameworkFile = "$applicationName.Framework.dll"
    $eventsFile = "$applicationName.Events.dll"
    $commandsFile = "$applicationName.Commands.dll"
    $commandProcessorFile = "$applicationName.CommandProcessor.dll"
    $dataFile = "$applicationName.Data.dll"
    $dataCommonFile = "$applicationName.Data.Common.dll"
    $dataStoreFile = "$applicationName.DataStore.dll"
    $dataSqlClientFile = "$applicationName.Data.SqlClient.dll"
    $dataSqliteFile = "$applicationName.Data.SQLite.dll"
    $webMvcFile = "$applicationName.Web.Mvc.dll"
    $webMvcNServiceBusFile = "$applicationName.Web.Mvc.NServiceBus.dll"
    $webApplicationFile = "$applicationName.WebApplication.dll"
    $specsFile = "$applicationName.Specs.dll"

    $sharedAssemblyFile = "src\SharedAssemblyInfo.cs"

    $frameworkSourceFiles = @(gci "src\Framework" -i "*.cs" -r | ? { $_ -notmatch "Specs" }) + $sharedAssemblyFile
    $eventsSourceFiles = @(gci "src\Events" -i "*.cs" -r | ? { $_ -notmatch "Specs" }) + $sharedAssemblyFile
    $commandsSourceFiles = @(gci "src\Commands" -i "*.cs" -r | ? { $_ -notmatch "Specs" }) + $sharedAssemblyFile
    $commandProcessorSourceFiles = @(gci "src\CommandProcessor" -i "*.cs" -r | ? { $_ -notmatch "Specs" }) + $sharedAssemblyFile
    $dataSourceFiles = @(gci "src\Data" -i "*.cs" -r | ? { $_ -notmatch "Specs" }) + $sharedAssemblyFile
    $dataCommonSourceFiles = @(gci "src\Data.Common" -i "*.cs" -r | ? { $_ -notmatch "Specs" }) + $sharedAssemblyFile
    $dataStoreSourceFiles = @(gci "src\DataStore" -i "*.cs" -r | ? { $_ -notmatch "Specs" }) + $sharedAssemblyFile
    $dataSqlClientSourceFiles = @(gci "src\Data.SqlClient" -i "*.cs" -r | ? { $_ -notmatch "Specs" }) + $sharedAssemblyFile
    $dataSqliteSourceFiles = @(gci "src\Data.SQLite" -i "*.cs" -r | ? { $_ -notmatch "Specs" }) + $sharedAssemblyFile
    $webMvcSourceFiles = @(gci "src\Web.Mvc" -i "*.cs" -r | ? { $_ -notmatch "Specs" }) + $sharedAssemblyFile
    $webMvcNServiceBusSourceFiles = @(gci "src\Web.Mvc.NServiceBus" -i "*.cs" -r | ? { $_ -notmatch "Specs" }) + $sharedAssemblyFile
    $webApplicationSourceFiles = @(gci "src\WebApplication" -i "*.cs" -r | ? { $_ -notmatch "Specs" }) + $sharedAssemblyFile
    $specsSourceFiles = @(gci "src" -i "*.cs" -r | ? { $_ -match "Specs" }) + $sharedAssemblyFile

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

    $eventsReferenceAssemblies = `
        @() + `
        "bin\$frameworkFile" + `
        "lib\nservicebus\lib\net40\NServiceBus.dll"

    $commandsReferenceAssemblies = `
        @() + `
        "bin\$frameworkFile" + `
        "lib\nservicebus\lib\net40\NServiceBus.dll"

    $commandProcessorReferenceAssemblies = `
        @($commandsReferenceAssemblies) + `
        "bin\$commandsFile" + `
        @($eventsReferenceAssemblies) + `
        "bin\$eventsFile" + `
        "lib\nservicebus\lib\net40\NServiceBus.Core.dll" + `
        "lib\NServiceBus.Host\lib\$nsbBitness\NServiceBus.Host.exe"

    $dataReferenceAssemblies = `
        @() + `
        "bin\$frameworkFile"

    $dataCommonReferenceAssemblies = `
        @($dataReferenceAssemblies) + `
        "bin\$dataFile" + `
        "$env:windir\Microsoft.NET\$bitness\$version\System.ComponentModel.Composition.dll"

    $dataStoreReferenceAssemblies = `
        @($eventsReferenceAssemblies) + `
        "bin\$eventsFile" + `
        @($dataCommonReferenceAssemblies) + `
        "bin\$dataCommonFile" + `
        "lib\NServiceBus.Host\lib\$nsbBitness\NServiceBus.Host.exe"

    $dataSqlClientReferenceAssemblies = `
        @($dataCommonReferenceAssemblies) + `
        "bin\$dataCommonFile"

    $dataSqliteReferenceAssemblies = `
        @($dataCommonReferenceAssemblies) + `
        "bin\$dataCommonFile"

    $dataSqlite86ReferenceAssemblies = `
        @($dataSqliteReferenceAssemblies) + `
        "lib\System.Data.SQLite.x86\lib\net40\System.Data.SQLite.dll"

    $dataSqlite64ReferenceAssemblies = `
        @($dataSqliteReferenceAssemblies) + `
        "lib\System.Data.SQLite.x64\lib\net40\System.Data.SQLite.dll"

    $webMvcReferenceAssemblies = `
        @() + `
        "ref\Microsoft ASP.NET\ASP.NET MVC 3\Assemblies\System.Web.Mvc.dll"

    $webMvcNServiceBusReferenceAssemblies = `
        @($webMvcReferenceAssemblies) + `
        "bin\$webMvcFile" + `
        "lib\log4net\lib\2.0\log4net.dll" + `
        "lib\nservicebus\lib\net40\NServiceBus.Core.dll" + `
        "lib\nservicebus\lib\net40\NServiceBus.dll"

    $webApplicationReferenceAssemblies = `
        @($webMvcNServiceBusReferenceAssemblies) + `
        "bin\$webMvcNServiceBusFile" + `
        @($commandsReferenceAssemblies) + `
        "bin\$commandsFile" + `
        @($dataCommonReferenceAssemblies) + `
        "bin\$dataCommonFile" + `
        "lib\MvcContrib.Mvc3-ci\lib\MvcContrib.dll"

    $specsReferenceAssemblies = `
        @($dataSqlClientReferenceAssemblies) + `
        "bin\$dataSqlClientFile" + `
        @($dataSqlite64ReferenceAssemblies) + `
        "bin\x64\$dataSqliteFile" + `
        @($webApplicationReferenceAssemblies) + `
        "bin\$webApplicationFile"

    GenericCompile "bin\$frameworkFile" $frameworkSourceFiles
    GenericCompile "bin\$eventsFile" $eventsSourceFiles $eventsReferenceAssemblies
    GenericCompile "bin\$commandsFile" $commandsSourceFiles $commandsReferenceAssemblies
    GenericCompile "bin\$commandProcessorFile" $commandProcessorSourceFiles $commandProcessorReferenceAssemblies
    GenericCompile "bin\$dataFile" $dataSourceFiles $dataReferenceAssemblies
    GenericCompile "bin\$dataCommonFile" $dataCommonSourceFiles $dataCommonReferenceAssemblies
    GenericCompile "bin\$dataStoreFile" $dataStoreSourceFiles $dataStoreReferenceAssemblies
    GenericCompile "bin\$dataSqlClientFile" $dataSqlClientSourceFiles $dataSqlClientReferenceAssemblies
    GenericCompile "bin\$webMvcFile" $webMvcSourceFiles $webMvcReferenceAssemblies
    GenericCompile "bin\$webMvcNServiceBusFile" $webMvcNServiceBusSourceFiles $webMvcNServiceBusReferenceAssemblies
    GenericCompile "bin\$webApplicationFile" $webApplicationSourceFiles $webApplicationReferenceAssemblies

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

    GenericCompile "bin\$specsFile" $specsSourceFiles $specsReferenceAssemblies

    cpi "lib\Machine.Specifications\lib\Machine.Specifications.dll" "bin"

    cpi "lib\Mvc3Futures\lib\Microsoft.Web.Mvc.dll" "bin"
    cpi "lib\MvcContrib.Mvc3-ci\lib\MvcContrib.dll" "bin"

    cpi "lib\log4net\lib\2.0\log4net.dll" "bin"
    cpi "lib\nservicebus\lib\net40\NServiceBus.Core.dll" "bin"
    cpi "lib\nservicebus\lib\net40\NServiceBus.dll" "bin"

    Exec { msbuild /t:"TransformWebConfig" /p:"IntermediateOutputPath=bin\" /p:"Configuration=$configuration" /v:"q" /nologo "transform.proj" }

    if ($configuration -eq "Release" -or $views -ne $null) {
        MakeDirectory "src\WebApplication\bin"

        cpi "bin\Dahlia.*.dll" "src\WebApplication\bin" -ex "*Specs*"
        Exec { msbuild /t:"MvcBuildViews" /v:"q" /nologo "tgt\views.proj" }
        RemoveDirectory "src\WebApplication\bin"
    }
}
