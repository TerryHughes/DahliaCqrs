pushd
Split-Path $MyInvocation.MyCommand.Path | cd

Include MakeDirectory.ps1

popd


Task Assemble -preaction { MakeDirectory "app" } {
    MakeDirectory "app\web"

    gci "src\WebApplication" -ex "*.cs", "*.config" -r | cpi -des { Join-Path "app\web" $_.FullName.Substring((rvpa "src\WebApplication").Path.Length) }
    # removes empty folders
    gci "app\web" -r | ? { $_.PSIsContainer } | ? { @(gci $_.FullName -r | ? { !$_.PSIsContainer }).Count -eq 0 } | rmdir -r

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
    cpi "bin\Dahlia.Data.dll" "app\web\bin"
    cpi "bin\Dahlia.Data.pdb" "app\web\bin"
    cpi "bin\Dahlia.Data.Common.*" "app\web\bin"
    cpi "bin\Dahlia.Data.SqlClient.*" "app\web\bin"
    cpi "bin\Dahlia.Web.Mvc.*" "app\web\bin"
#    cpi "bin\Dahlia.Web.Mvc.NServiceBus.*" "app\web\bin"
    cpi "bin\Dahlia.WebApplication.*" "app\web\bin"
#    cpi "bin\$bitness\*.*" "app\web\bin" -ex "*Specs*"
    cpi "lib\Mvc3Futures\lib\Microsoft.Web.Mvc.dll" "bin"
    cpi "lib\MvcContrib.Mvc3-ci\lib\MvcContrib.dll" "bin"
    cpi "lib\nservicebus\lib\$nsbBitness\log4net.dll" "app\web\bin"
    cpi "lib\nservicebus\lib\$nsbBitness\NServiceBus.Core.dll" "app\web\bin"
    cpi "lib\nservicebus\lib\$nsbBitness\NServiceBus.dll" "app\web\bin"
#    cpi "ref\Microsoft ASP.NET\ASP.NET Web Pages\v1.0\Assemblies\System.Web.Helpers.dll" "app\web\bin"
#    cpi "ref\Microsoft ASP.NET\ASP.NET MVC 3\Assemblies\System.Web.Mvc.dll" "app\web\bin"
#    cpi "ref\Microsoft ASP.NET\ASP.NET Web Pages\v1.0\Assemblies\System.Web.WebPages.dll" "app\web\bin"
#    cpi "ref\Microsoft ASP.NET\ASP.NET Web Pages\v1.0\Assemblies\Microsoft.Web.Infrastructure.dll" "app\web\bin"
#    cpi "ref\Microsoft ASP.NET\ASP.NET Web Pages\v1.0\Assemblies\System.Web.WebPages.Razor.dll" "app\web\bin"
#    cpi "ref\Microsoft ASP.NET\ASP.NET Web Pages\v1.0\Assemblies\System.Web.WebPages.Deployment.dll" "app\web\bin"
#    cpi "ref\Microsoft ASP.NET\ASP.NET Web Pages\v1.0\Assemblies\System.Web.Razor.dll" "app\web\bin"

    MakeDirectory "app\web\Scripts"

    cpi "lib\jQuery\Content\Scripts\jquery-1.6.1.min.js" "app\web\Scripts"
    cpi "ref\timeago\jquery.timeago.js" "app\web\Scripts"

    # only needed when we update the build script to use view content but there isnt any
#    MakeDirectory "app\web\Views"

    gci "bin\TransformWebConfig\transformed\src\WebApplication" -r | ? { !$_.PSIsContainer } | cpi -des { Join-Path "app\web" $_.FullName.Substring((rvpa "bin\TransformWebConfig\transformed\src\WebApplication").Path.Length) }


    MakeDirectory "app\data"

    cpi "bin\Dahlia.Framework.*" "app\data"
    cpi "bin\Dahlia.Events.*" "app\data"
    cpi "bin\Dahlia.Data.Common.*" "app\data"
    cpi "bin\Dahlia.Data.SqlClient.*" "app\data"
    cpi "bin\Dahlia.DataStore.dll" "app\data"
    cpi "src\DataStore\App.config" "app\data\Dahlia.DataStore.dll.config"
    cpi "lib\nservicebus\lib\$nsbBitness\log4net.dll" "app\data"
    cpi "lib\nservicebus\lib\$nsbBitness\NServiceBus.dll" "app\data"
    cpi "lib\nservicebus\lib\$nsbBitness\NServiceBus.Core.dll" "app\data"
    cpi "lib\nservicebus\lib\$nsbBitness\NServiceBus.Host.exe" "app\data"


    MakeDirectory "app\cmd"

    cpi "bin\Dahlia.Framework.*" "app\cmd"
    cpi "bin\Dahlia.Events.*" "app\cmd"
    cpi "bin\Dahlia.Commands.*" "app\cmd"
    cpi "bin\Dahlia.CommandProcessor.dll" "app\cmd"
    cpi "src\CommandProcessor\App.config" "app\cmd\Dahlia.CommandProcessor.dll.config"
    cpi "lib\nservicebus\lib\$nsbBitness\log4net.dll" "app\cmd"
    cpi "lib\nservicebus\lib\$nsbBitness\NServiceBus.dll" "app\cmd"
    cpi "lib\nservicebus\lib\$nsbBitness\NServiceBus.Core.dll" "app\cmd"
    cpi "lib\nservicebus\lib\$nsbBitness\NServiceBus.Host.exe" "app\cmd"
}
