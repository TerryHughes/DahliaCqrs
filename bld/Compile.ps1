Include bld\Compile\CommandProcessor.ps1
Include bld\Compile\Commands.ps1
Include bld\Compile\DataCommon.ps1
Include bld\Compile\DataSqlClient.ps1
Include bld\Compile\DataSqlite.ps1
Include bld\Compile\DataStore.ps1
Include bld\Compile\Domain.ps1
Include bld\Compile\Events.ps1
Include bld\Compile\EventStores.ps1
Include bld\Compile\Framework.ps1
Include bld\Compile\Specs.ps1
Include bld\Compile\WebApplication.ps1
Include bld\Utilities\Make-Directory.ps1

Properties {
    $sharedAssemblyFile = "src\SharedAssemblyInfo.cs"

    $commandsFile = "bin\$applicationName.Commands.dll"
    $commandProcessorFile = "bin\$applicationName.CommandProcessor.dll"
    $dataCommonFile = "bin\$applicationName.Data.Common.dll"
    $dataSqlClientFile = "bin\$applicationName.Data.SqlClient.dll"
    $dataSqliteFile = "$applicationName.Data.SQLite.dll"
    $dataStoreFile = "bin\$applicationName.DataStore.dll"
    $domainFile = "bin\$applicationName.Domain.dll"
    $eventsFile = "bin\$applicationName.Events.dll"
    $eventStoresFile = "bin\$applicationName.EventStores.dll"
    $frameworkFile = "bin\$applicationName.Framework.dll"
    $specsFile = "bin\$applicationName.Specs.dll"
    $webApplicationFile = "bin\$applicationName.WebApplication.dll"
}

Properties {
    $versionDirectory = $null
    $frameworkVersion = $framework.Substring(0, 3)
    switch ($frameworkVersion) {
        "4.0" {
            $versionDirectory = @("v4.0.30319")
        }
    }

    $frameworkDirectory = $null
    switch ($framework.Substring(3)) {
        "x86" {
            $frameworkDirectory = "Framework"
        }
        "x64" {
            $frameworkDirectory = "Framework64"
        }
        $null {
            $ptrSize = [System.IntPtr]::Size
            switch ($ptrSize) {
                4 {
                    $frameworkDirectory = "Framework"
                }
                8 {
                    $frameworkDirectory = "Framework64"
                }
            }
        }
    }

    $compositionFile = "$env:windir\Microsoft.NET\$frameworkDirectory\$versionDirectory\System.ComponentModel.Composition.dll"
}

Task Compile {
    Make-Directory "bin"

    Compile-Framework
    Compile-DataCommon
    Compile-Commands
    Compile-Events
    Compile-Domain
    Compile-EventStores
    Compile-DataSqlClient
    Compile-DataSqlite
    Compile-DataStore
    Compile-CommandProcessor
    Compile-WebApplication
    Compile-Specs
}
