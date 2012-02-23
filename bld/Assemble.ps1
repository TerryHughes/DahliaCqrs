Include bld\Assemble\CommandProcessor.ps1
Include bld\Assemble\DataStore.ps1
Include bld\Assemble\RelationalStore.ps1
Include bld\Assemble\WebApplication.ps1
Include bld\Utilities\Make-Directory.ps1

Properties {
    $bitness = $framework.Substring(3)
    if ($bitness -eq "") {
        $ptrSize = [System.IntPtr]::Size
        switch ($ptrSize) {
            4 {
                $bitness = "x86"
            }
            8 {
                $bitness = "x64"
            }
        }
    }
}

Task Assemble {
    Make-Directory "app"

    Assemble-DataStore
    Assemble-RelationalStore
    Assemble-CommandProcessor
    Assemble-WebApplication
}
