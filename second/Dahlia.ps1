$framework = "4.0"

Properties {
    $applicationName = "Dahlia"

    $configuration = "Debug"

    $commandFile = `
    $commandHandlerFile = `
    $dataStoreFile = `
    $eventFile = `
    $frameworkFile = `
    $repositoryFile = `
    $specFile = `
    $viewModelFile = `
    $webMvcFile = `
        "bin\$applicationName"

    $specFile += ".Specs.dll"
}

Task default -depends Clean, Compile, Verify, Publish

Task Publish -preaction {
    if (!(Test-Path app\web))
    {
        mkdir app\web | Out-Null
    }
} {
    gci src\Web.Mvc -ex *.cs, *.config -r | cpi -des { Join-Path app\web $_.FullName.Substring((rvpa src\Web.Mvc).Path.Length) }
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

    cpi lib\jQuery\Content\Scripts\jquery-1.6.1.min.js app\web\Scripts
    cpi ref\timeago\jquery.timeago.js app\web\Scripts

    cpi bin\Dahlia.Framework.dll app\data
    cpi bin\Dahlia.Events.dll app\data
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
    cpi bin\Dahlia.CommandHandlers.dll app\cmd
    cpi src\CommandHandlers\App.config app\cmd\Dahlia.CommandHandlers.dll.config

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

    gci bin\TransformWebConfig\transformed\src\Web.Mvc -r | ? { !$_.PSIsContainer } | cpi -des { Join-Path app\web $_.FullName.Substring((rvpa bin\TransformWebConfig\transformed\src\Web.Mvc).Path.Length) }
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
    $commandHandlerFile += ".CommandHandlers.dll"
    $dataStoreFile += ".DataStore.dll"
    $eventFile += ".Events.dll"
    $frameworkFile += ".Framework.dll"
    $repositoryFile += ".Repositories.dll"
    $viewModelFile += ".ViewModels.dll"
    $webMvcFile += ".Web.Mvc.dll"

    $sharedAssemblyInfoFile = "src\SharedAssemblyInfo.cs"

    $specSourceFiles = @(gci src -i *.cs -r | ? { $_ -match "Specs" }) + $sharedAssemblyInfoFile
    $commandSourceFiles = @(gci src\Commands -i *.cs -r | ? { $_ -notmatch "Specs" }) + $sharedAssemblyInfoFile
    $commandHandlerSourceFiles = @(gci src\CommandHandlers -i *.cs -r | ? { $_ -notmatch "Specs" }) + $sharedAssemblyInfoFile
    $dataStoreSourceFiles = @(gci src\DataStore -i *.cs -r | ? { $_ -notmatch "Specs" }) + $sharedAssemblyInfoFile
    $eventSourceFiles = @(gci src\Events -i *.cs -r | ? { $_ -notmatch "Specs" }) + $sharedAssemblyInfoFile
    $frameworkSourceFiles = @(gci src\Framework -i *.cs -r | ? { $_ -notmatch "Specs" }) + $sharedAssemblyInfoFile
    $repositorySourceFiles = @(gci src\Repositories -i *.cs -r | ? { $_ -notmatch "Specs" }) + $sharedAssemblyInfoFile
    $viewModelSourceFiles = @(gci src\ViewModels -i *.cs -r | ? { $_ -notmatch "Specs" }) + $sharedAssemblyInfoFile
    $webMvcSourceFiles = @(gci src\Web.Mvc -i *.cs -r | ? { $_ -notmatch "Specs" }) + $sharedAssemblyInfoFile

    $commandReferences = `
        @() + `
        "lib\nservicebus\lib\net40\NServiceBus.dll" + `
        $frameworkFile
    $eventReferences = `
        @() + `
        "lib\nservicebus\lib\net40\NServiceBus.dll" + `
        $frameworkFile
    $commandHandlerReferences = `
        @($commandReferences) + `
        @($eventReferences) + `
        "lib\nservicebus\lib\net40\NServiceBus.dll" + `
        "lib\nservicebus\lib\net40\NServiceBus.Core.dll" + `
        "lib\nservicebus\lib\net40\NServiceBus.Host.exe" + `
        $commandFile + `
        $eventFile + `
        $frameworkFile
    $dataStoreReferences = `
        @($eventReferences) + `
        "lib\nservicebus\lib\net40\NServiceBus.dll" + `
        "lib\nservicebus\lib\net40\NServiceBus.Host.exe" + `
        $eventFile
    $repositoryReferences = `
        @() + `
        $frameworkFile + `
        $viewModelFile
    $webMvcReferences = `
        @($repositoryReferences) + `
        @($commandReferences) + `
        "lib\MvcContrib.Mvc3-ci\lib\MvcContrib.dll" + `
        "ref\Microsoft ASP.NET\ASP.NET MVC 3\Assemblies\System.Web.Mvc.dll" + `
        "lib\nservicebus\lib\net40\NServiceBus.Core.dll" + `
        "lib\nservicebus\lib\net40\NServiceBus.dll" + `
        "lib\nservicebus\lib\net40\log4net.dll" + `
        $commandFile + `
        $repositoryFile
    $specReferences = `
        @($webMvcReferences) + `
        @($repositoryReferences) + `
        @($eventReferences) + `
        @($dataStoreReferences) + `
        @($commandReferences) + `
        "lib\Machine.Specifications\lib\Machine.Specifications.dll" + `
        $webMvcFile + `
        $repositoryFile + `
        $eventFile + `
        $dataStoreFile + `
        $commandFile

    GenericCompile $frameworkFile -source $frameworkSourceFiles
    GenericCompile $viewModelFile -source $viewModelSourceFiles
    GenericCompile $commandFile $commandReferences $commandSourceFiles
    GenericCompile $eventFile $eventReferences $eventSourceFiles
    GenericCompile $commandHandlerFile $commandHandlerReferences $commandHandlerSourceFiles
    GenericCompile $dataStoreFile $dataStoreReferences $dataStoreSourceFiles
    GenericCompile $repositoryFile $repositoryReferences $repositorySourceFiles
    GenericCompile $webMvcFile $webMvcReferences $webMvcSourceFiles
    GenericCompile $specFile $specReferences $specSourceFiles
} -postaction {
    cpi lib\Machine.Specifications\lib\Machine.Specifications.dll bin
    cpi lib\Mvc3Futures\lib\Microsoft.Web.Mvc.dll bin
    cpi lib\MvcContrib.Mvc3-ci\lib\MvcContrib.dll bin
    cpi lib\nservicebus\lib\net40\NServiceBus.dll bin

    Exec { msbuild /t:TransformWebConfig /p:IntermediateOutputPath=bin\ /p:Configuration=$configuration /v:q /nologo transform.proj }

    if ($configuration -eq "Release" -or $views -ne $null)
    {
        if (!(Test-Path src\Web.Mvc\bin))
        {
            mkdir src\Web.Mvc\bin | Out-Null
        }

        cpi bin\Dahlia.*.dll src\Web.Mvc\bin -ex *Specs*
        Exec { msbuild /t:MvcBuildViews /v:q /nologo tgt\views.proj }
# need a try catch finally to remove the bin directory?
        rmdir -r src\Web.Mvc\bin
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

function GenericCompile
{
    [CmdletBinding()]
    param(
        [Parameter(Position=0,Mandatory=1)] [string]$outFile = $null,
        [Parameter(Position=1,Mandatory=0)] [string[]]$references = @(),
        [Parameter(Position=2,Mandatory=1)] [string[]]$sourceFiles = @()
    )

    if ($configuration -eq "Debug")
    {
        $emitDebugInformation = "/debug+"
        $debugType = "full"
        $optimize = "/o-"
        $defineConstants = "DEBUG;TRACE;"
    }

    if ($configuration -eq "Release")
    {
        $emitDebugInformation = "/debug-"
        $debugType = "pdbonly"
        $optimize = "/o+"
        $defineConstants = "TRACE;"
    }

    Exec { csc /out:$outFile /t:library ($references | % { "/r:" + $_ }) $emitDebugInformation /debug:$debugType $optimize /d:$defineConstants /nologo $sourceFiles }
}
