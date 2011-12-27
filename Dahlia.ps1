$framework = "4.0"

Properties {
    $applicationName = "Dahlia"

    $configuration = "Debug"

    $commandFile = `
    $commandProcessorFile = `
    $dataFile = `
    $dataCommonFile = `
    $dataStoreFile = `
    $dataSqlClientFile = `
    $dataSqliteFile = `
    $eventFile = `
    $frameworkFile = `
    $repositoryFile = `
    $specFile = `
    $viewModelFile = `
    $webMvcFile = `
    $webMvcNServiceBusFile = `
    $webApplicationFile = `
        "bin\$applicationName"

    $specFile += ".Specs.dll"
}

Include bld\MakeDirectory.ps1
Include bld\GenericCompile.ps1

Task default -depends Clean, Compile, Verify, Publish

Task Publish -preaction {
    if (!(Test-Path app\web))
    {
        mkdir app\web | Out-Null
    }
} {
    gci src\WebApplication -ex *.cs, *.config -r | cpi -des { Join-Path app\web $_.FullName.Substring((rvpa src\WebApplication).Path.Length) }
    gci app\web -r | ? { $_.PSIsContainer } | ? { @(gci $_.FullName -r | ? { !$_.PSIsContainer }).Count -eq 0 } | rmdir -r

    if (!(Test-Path app\web\bin))
    {
        mkdir app\web\bin | Out-Null
    }

    if (!(Test-Path app\data))
    {
        mkdir app\data | Out-Null
    }

    if (!(Test-Path app\cmd))
    {
        mkdir app\cmd | Out-Null
    }

    if (!(Test-Path app\web\Scripts))
    {
        mkdir app\web\Scripts | Out-Null
    }

    cpi bin\Dahlia.ViewModels.dll app\web\bin
    cpi bin\Dahlia.Framework.dll app\web\bin
    cpi bin\Dahlia.Commands.dll app\web\bin
    cpi bin\Dahlia.Repositories.dll app\web\bin
    cpi bin\Dahlia.Web.Mvc.dll app\web\bin
    cpi bin\Dahlia.Web.Mvc.NServiceBus.dll app\web\bin
    cpi bin\Dahlia.WebApplication.dll app\web\bin

    cpi lib\jQuery\Content\Scripts\jquery-1.6.1.min.js app\web\Scripts
    cpi ref\timeago\jquery.timeago.js app\web\Scripts

    cpi bin\Dahlia.Framework.dll app\data
    cpi bin\Dahlia.Events.dll app\data
    cpi bin\Dahlia.Data.dll app\data
    cpi bin\Dahlia.Data.Common.dll app\data
    cpi bin\Dahlia.Data.SqlClient.dll app\data
    cpi lib\nservicebus\lib\net40\log4net.dll app\data
    cpi lib\nservicebus\lib\net40\NServiceBus.Host.exe app\data
    cpi lib\nservicebus\lib\net40\NServiceBus.dll app\data
    cpi lib\nservicebus\lib\net40\NServiceBus.Core.dll app\data
    cpi bin\Dahlia.DataStore.dll app\data
    cpi src\DataStore\App.config app\data\Dahlia.DataStore.dll.config

    cpi bin\Dahlia.Framework.dll app\cmd
    cpi bin\Dahlia.Events.dll app\cmd
    cpi bin\Dahlia.Commands.dll app\cmd
    cpi lib\nservicebus\lib\net40\log4net.dll app\cmd
    cpi lib\nservicebus\lib\net40\NServiceBus.Host.exe app\cmd
    cpi lib\nservicebus\lib\net40\NServiceBus.dll app\cmd
    cpi lib\nservicebus\lib\net40\NServiceBus.Core.dll app\cmd
    cpi bin\Dahlia.CommandProcessor.dll app\cmd
    cpi src\CommandProcessor\App.config app\cmd\Dahlia.CommandProcessor.dll.config

    cpi bin\MvcContrib.dll app\web\bin
    cpi bin\Microsoft.Web.Mvc.dll app\web\bin
    cpi lib\nservicebus\lib\net40\NServiceBus.Core.dll app\web\bin
    cpi lib\nservicebus\lib\net40\log4net.dll app\web\bin
    cpi lib\nservicebus\lib\net40\NServiceBus.dll app\web\bin

    cpi "ref\Microsoft ASP.NET\ASP.NET Web Pages\v1.0\Assemblies\System.Web.Helpers.dll" app\web\bin
    cpi "ref\Microsoft ASP.NET\ASP.NET MVC 3\Assemblies\System.Web.Mvc.dll" app\web\bin
    cpi "ref\Microsoft ASP.NET\ASP.NET Web Pages\v1.0\Assemblies\System.Web.WebPages.dll" app\web\bin
    cpi "ref\Microsoft ASP.NET\ASP.NET Web Pages\v1.0\Assemblies\Microsoft.Web.Infrastructure.dll" app\web\bin
    cpi "ref\Microsoft ASP.NET\ASP.NET Web Pages\v1.0\Assemblies\System.Web.WebPages.Razor.dll" app\web\bin
    cpi "ref\Microsoft ASP.NET\ASP.NET Web Pages\v1.0\Assemblies\System.Web.WebPages.Deployment.dll" app\web\bin
    cpi "ref\Microsoft ASP.NET\ASP.NET Web Pages\v1.0\Assemblies\System.Web.Razor.dll" app\web\bin

    gci bin\TransformWebConfig\transformed\src\WebApplication -r | ? { !$_.PSIsContainer } | cpi -des { Join-Path app\web $_.FullName.Substring((rvpa bin\TransformWebConfig\transformed\src\WebApplication).Path.Length) }
}

Task Verify -depends Compile {
    Exec { lib\Machine.Specifications\tools\mspec-clr4.exe $specFile -s --html bin\mspec.htm }
}

Task Compile -preaction {
    if (!(Test-Path bin))
    {
        mkdir bin | Out-Null
    }
} {
    $commandFile += ".Commands.dll"
    $commandProcessorFile += ".CommandProcessor.dll"
    $dataFile += ".Data.dll"
    $dataCommonFile += ".Data.Common.dll"
    $dataStoreFile += ".DataStore.dll"
    $dataSqlClientFile += ".Data.SqlClient.dll"
    $dataSqliteFile += ".Data.SQLite.dll"
    $eventFile += ".Events.dll"
    $frameworkFile += ".Framework.dll"
    $repositoryFile += ".Repositories.dll"
    $viewModelFile += ".ViewModels.dll"
    $webMvcFile += ".Web.Mvc.dll"
    $webMvcNServiceBusFile += ".Web.Mvc.NServiceBus.dll"
    $webApplicationFile += ".WebApplication.dll"

    $sharedAssemblyInfoFile = "src\SharedAssemblyInfo.cs"

    $specSourceFiles = @(gci src -i *.cs -r | ? { $_ -match "Specs" }) + $sharedAssemblyInfoFile
    $commandSourceFiles = @(gci src\Commands -i *.cs -r | ? { $_ -notmatch "Specs" }) + $sharedAssemblyInfoFile
    $commandProcessorSourceFiles = @(gci src\CommandProcessor -i *.cs -r | ? { $_ -notmatch "Specs" }) + $sharedAssemblyInfoFile
    $dataSourceFiles = @(gci src\Data -i *.cs -r | ? { $_ -notmatch "Specs" }) + $sharedAssemblyInfoFile
    $dataCommonSourceFiles = @(gci src\Data.Common -i *.cs -r | ? { $_ -notmatch "Specs" }) + $sharedAssemblyInfoFile
    $dataStoreSourceFiles = @(gci src\DataStore -i *.cs -r | ? { $_ -notmatch "Specs" }) + $sharedAssemblyInfoFile
    $dataSqlClientSourceFiles = @(gci src\Data.SqlClient -i *.cs -r | ? { $_ -notmatch "Specs" }) + $sharedAssemblyInfoFile
    $dataSqliteSourceFiles = @(gci src\Data.SQLite -i *.cs -r | ? { $_ -notmatch "Specs" }) + $sharedAssemblyInfoFile
    $eventSourceFiles = @(gci src\Events -i *.cs -r | ? { $_ -notmatch "Specs" }) + $sharedAssemblyInfoFile
    $frameworkSourceFiles = @(gci src\Framework -i *.cs -r | ? { $_ -notmatch "Specs" }) + $sharedAssemblyInfoFile
    $repositorySourceFiles = @(gci src\Repositories -i *.cs -r | ? { $_ -notmatch "Specs" }) + $sharedAssemblyInfoFile
    $viewModelSourceFiles = @(gci src\ViewModels -i *.cs -r | ? { $_ -notmatch "Specs" }) + $sharedAssemblyInfoFile
    $webMvcSourceFiles = @(gci src\Web.Mvc -i *.cs -r | ? { $_ -notmatch "Specs" }) + $sharedAssemblyInfoFile
    $webMvcNServiceBusSourceFiles = @(gci src\Web.Mvc.NServiceBus -i *.cs -r | ? { $_ -notmatch "Specs" }) + $sharedAssemblyInfoFile
    $webApplicationSourceFiles = @(gci src\WebApplication -i *.cs -r | ? { $_ -notmatch "Specs" }) + $sharedAssemblyInfoFile

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

    $commandReferences = `
        @() + `
        "lib\nservicebus\lib\net40\NServiceBus.dll" + `
        $frameworkFile
    $eventReferences = `
        @() + `
        "lib\nservicebus\lib\net40\NServiceBus.dll" + `
        $frameworkFile
    $commandProcessorReferences = `
        @($commandReferences) + `
        @($eventReferences) + `
        "lib\nservicebus\lib\net40\NServiceBus.dll" + `
        "lib\nservicebus\lib\net40\NServiceBus.Core.dll" + `
        "lib\nservicebus\lib\net40\NServiceBus.Host.exe" + `
        $commandFile + `
        $eventFile + `
        $frameworkFile
    $dataReferences = `
        @() +`
        $frameworkFile
    $dataCommonReferences = `
        @($dataReferences) + `
        $dataFile + `
        "$env:windir\Microsoft.NET\$bitness\$version\System.ComponentModel.Composition.dll"
    $dataStoreReferences = `
        @($eventReferences) + `
        @($dataCommonReferences) + `
        "lib\nservicebus\lib\net40\NServiceBus.dll" + `
        "lib\nservicebus\lib\net40\NServiceBus.Host.exe" + `
        $eventFile + `
        $dataCommonFile
    $dataSqlClientReferences = `
        @($dataCommonReferences) + `
        $dataCommonFile
    $dataSqliteReferences = `
        @($dataCommonReferences) + `
        $dataCommonFile
    $dataSqlite86References = `
        @($dataSqliteReferences) + `
        "lib\System.Data.SQLite.x86\lib\net40\System.Data.SQLite.dll"
    $dataSqlite64References = `
        @($dataSqliteReferences) + `
        "lib\System.Data.SQLite.x64\lib\net40\System.Data.SQLite.dll"
    $repositoryReferences = `
        @() + `
        $frameworkFile + `
        $viewModelFile
    $webMvcReferences = `
        @() + `
        "ref\Microsoft ASP.NET\ASP.NET MVC 3\Assemblies\System.Web.Mvc.dll"
    $webMvcNServiceBusReferences = `
        @($webMvcReferences) + `
        $webMvcFile + `
        "lib\nservicebus\lib\net40\log4net.dll" + `
        "lib\nservicebus\lib\net40\NServiceBus.Core.dll" + `
        "lib\nservicebus\lib\net40\NServiceBus.dll"
    $webApplicationReferences = `
        @($repositoryReferences) + `
        @($commandReferences) + `
        "lib\MvcContrib.Mvc3-ci\lib\MvcContrib.dll" + `
        "ref\Microsoft ASP.NET\ASP.NET MVC 3\Assemblies\System.Web.Mvc.dll" + `
        "lib\nservicebus\lib\net40\NServiceBus.Core.dll" + `
        "lib\nservicebus\lib\net40\NServiceBus.dll" + `
        "lib\nservicebus\lib\net40\log4net.dll" + `
        $commandFile + `
        $repositoryFile + `
        @($webMvcNServiceBusReferences) + `
        $webMvcNServiceBusFile
    $specReferences = `
        @($webApplicationReferences) + `
        @($repositoryReferences) + `
        @($eventReferences) + `
        @($dataStoreReferences) + `
        @($commandReferences) + `
        "lib\Machine.Specifications\lib\Machine.Specifications.dll" + `
        $webApplicationFile + `
        $repositoryFile + `
        $eventFile + `
        $dataStoreFile + `
        $commandFile

    GenericCompile $frameworkFile $frameworkSourceFiles
    GenericCompile $viewModelFile $viewModelSourceFiles
    GenericCompile $commandFile $commandSourceFiles $commandReferences
    GenericCompile $eventFile $eventSourceFiles $eventReferences
    GenericCompile $commandProcessorFile $commandProcessorSourceFiles $commandProcessorReferences
    GenericCompile $dataFile $dataSourceFiles $dataReferences
    GenericCompile $dataCommonFile $dataCommonSourceFiles $dataCommonReferences
    GenericCompile $repositoryFile $repositorySourceFiles $repositoryReferences
    GenericCompile $dataStoreFile $dataStoreSourceFiles $dataStoreReferences
    GenericCompile $dataSqlClientFile $dataSqlClientSourceFiles $dataSqlClientReferences
    GenericCompile $webMvcFile $webMvcSourceFiles $webMvcReferences
    GenericCompile $webMvcNServiceBusFile $webMvcNServiceBusSourceFiles $webMvcNServiceBusReferences
    GenericCompile $webApplicationFile $webApplicationSourceFiles $webApplicationReferences

    MakeDirectory "bin\x86"
    MakeDirectory "bin\x64"

    $sqlite = @{}
    $sqlite.sourceFiles = $dataSqliteSourceFiles

    $sqlite.referenceAssemblies = $dataSqlite86References
    $sqlite.outFile = "bin\x86\Dahlia.Data.SQLite.dll"
    $frameworkVersion86 = $frameworkVersion + "x86"
    Invoke-psake "bld\BitnessCompile.ps1" "BitnessCompile" $frameworkVersion86 -parameters $sqlite | Out-Null

    $sqlite.referenceAssemblies = $dataSqlite64References
    $sqlite.outFile = "bin\x64\Dahlia.Data.SQLite.dll"
    $frameworkVersion64 = $frameworkVersion + "x64"
    Invoke-psake "bld\BitnessCompile.ps1" "BitnessCompile" $frameworkVersion64 -parameters $sqlite | Out-Null

    cpi "lib\System.Data.SQLite.x86\lib\net40\System.Data.SQLite.dll" "bin\x86"
    cpi "lib\System.Data.SQLite.x64\lib\net40\System.Data.SQLite.dll" "bin\x64"

    GenericCompile $specFile $specSourceFiles $specReferences
} -postaction {
    cpi lib\Machine.Specifications\lib\Machine.Specifications.dll bin
    cpi lib\Mvc3Futures\lib\Microsoft.Web.Mvc.dll bin
    cpi lib\MvcContrib.Mvc3-ci\lib\MvcContrib.dll bin
    cpi lib\nservicebus\lib\net40\NServiceBus.dll bin

    Exec { msbuild /t:TransformWebConfig /p:IntermediateOutputPath=bin\ /p:Configuration=$configuration /v:q /nologo transform.proj }

    if ($configuration -eq "Release" -or $views -ne $null)
    {
        if (!(Test-Path src\WebApplication\bin))
        {
            mkdir src\WebApplication\bin | Out-Null
        }

        cpi bin\Dahlia.*.dll src\WebApplication\bin -ex *Specs*
        Exec { msbuild /t:MvcBuildViews /v:q /nologo tgt\views.proj }
# need a try catch finally to remove the bin directory?
        rmdir -r src\WebApplication\bin
    }
}

Task Clean {
    if (Test-Path app) 
    {
        rmdir -r app
    }

    if (Test-Path bin) 
    {
        rmdir -r bin
    }
}
