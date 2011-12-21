pushd
Split-Path $MyInvocation.MyCommand.Path | cd

Include MakeDirectory.ps1

popd


Task Assemble -preaction { MakeDirectory "app" } {
    MakeDirectory "app\web"

    gci "src\WebApplication" -ex "*.cs", "*.config" -r | cpi -des { Join-Path "app\web" $_.FullName.Substring((rvpa "src\WebApplication").Path.Length) }
    # removes empty folders
    gci "app\web" -r | ? { $_.PSIsContainer -eq $true } | ? { @(gci $_.FullName -r | ? { $_.PSIsContainer -eq $false }).Count -eq 0 } | rmdir -r

    MakeDirectory "app\web\bin"

    $bitness = $framework.Substring(3)
    $nsbBitness = "net40"
    if ($bitness -eq "") {
        $ptrSize = [System.IntPtr]::Size
        switch ($ptrSize) {
            4 {
                $bitness = "x86"
                $nsbBitness = "net40\x86"
            }
            8 {
                $bitness = "x64"
            }
        }
    }

    cpi "bin\Dahlia.Framework.*" "app\web\bin"
    cpi "bin\Dahlia.Commands.*" "app\web\bin"
    cpi "bin\Dahlia.Data.*" "app\web\bin"
    cpi "bin\Dahlia.Web.Mvc.*" "app\web\bin"
    cpi "bin\Dahlia.WebApplication.*" "app\web\bin"
    cpi "bin\$bitness\*.*" "app\web\bin" -ex "*Specs*"
    cpi "bin\Microsoft.Web.Mvc.dll" "app\web\bin"
    cpi "bin\MvcContrib.dll" "app\web\bin"
    cpi "bin\log4net.dll" "app\web\bin"
    cpi "bin\NServiceBus.Core.dll" "app\web\bin"
    cpi "bin\NServiceBus.dll" "app\web\bin"

    # only needed when we update the build script to use view content but there isnt any
#    MakeDirectory "app\web\Views"

    gci "bin\TransformWebConfig\transformed\src\WebApplication" -r | ? { $_.PSIsContainer -eq $false } | cpi -des { Join-Path "app\web" $_.FullName.Substring((rvpa "bin\TransformWebConfig\transformed\src\WebApplication").Path.Length) }


    MakeDirectory "app\data"

    cpi "bin\Dahlia.Framework.*" "app\data"
    cpi "bin\Dahlia.Events.*" "app\data"
    cpi "bin\NServiceBus.dll" "app\data"
    cpi "bin\log4net.dll" "app\data"
    cpi "bin\NServiceBus.Core.dll" "app\data"
    cpi "lib\NServiceBus.Host\lib\$nsbBitness\NServiceBus.Host.exe" "app\data"
    cpi "bin\Dahlia.DataStore.dll" "app\data"
    cpi "src\DataStore\App.config" "app\data\Dahlia.DataStore.dll.config"


    MakeDirectory "app\cmd"

    cpi "bin\Dahlia.Framework.*" "app\cmd"
    cpi "bin\Dahlia.Events.*" "app\cmd"
    cpi "bin\Dahlia.Commands.*" "app\cmd"
    cpi "bin\NServiceBus.dll" "app\cmd"
    cpi "bin\log4net.dll" "app\cmd"
    cpi "bin\NServiceBus.Core.dll" "app\cmd"
    cpi "lib\NServiceBus.Host\lib\$nsbBitness\NServiceBus.Host.exe" "app\cmd"
    cpi "bin\Dahlia.CommandProcessor.dll" "app\cmd"
    cpi "src\CommandProcessor\App.config" "app\cmd\Dahlia.CommandProcessor.dll.config"
}
