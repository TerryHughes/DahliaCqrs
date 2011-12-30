Include bld\Utilities\Make-Directory.ps1

function Assemble-WebApplication {
    Make-Directory "app\web"

    gci "src\WebApplication" -ex "*.cs", "*.config" -r | cpi -des { Join-Path "app\web" $_.FullName.Substring((rvpa "src\WebApplication").Path.Length) }
    # removes empty folders
    gci "app\web" -r | ? { $_.PSIsContainer } | ? { @(gci $_.FullName -r | ? { !$_.PSIsContainer }).Count -eq 0 } | rmdir -r

    gci "bin\TransformWebConfig\transformed\src\WebApplication" -r | ? { !$_.PSIsContainer } | cpi -des { Join-Path "app\web" $_.FullName.Substring((rvpa "bin\TransformWebConfig\transformed\src\WebApplication").Path.Length) }

    Make-Directory "app\web\Scripts"

    cpi "lib\jQuery\Content\Scripts\jquery-1.6.1.min.js" "app\web\Scripts"
    cpi "ref\timeago\jquery.timeago.js" "app\web\Scripts"

    Make-Directory "app\web\bin"

    cpi "bin\Dahlia.Framework.*" "app\web\bin"
    cpi "bin\Dahlia.Commands.*" "app\web\bin"
    cpi "bin\Dahlia.Data.Common.*" "app\web\bin"
    cpi "bin\Dahlia.Data.SqlClient.*" "app\web\bin"
    cpi "bin\$bitness\*.Data.SQLite.*" "app\web\bin" -ex "*Specs*"
    cpi "bin\Dahlia.WebApplication.*" "app\web\bin"
    cpi "lib\Mvc3Futures\lib\Microsoft.Web.Mvc.dll" "app\web\bin"
    cpi "lib\MvcContrib.Mvc3-ci\lib\MvcContrib.dll" "app\web\bin"
    cpi "lib\nservicebus\lib\net40\log4net.dll" "app\web\bin"
    cpi "lib\nservicebus\lib\net40\NServiceBus.Core.dll" "app\web\bin"
    cpi "lib\nservicebus\lib\net40\NServiceBus.dll" "app\web\bin"
#    cpi "ref\Microsoft ASP.NET\ASP.NET Web Pages\v1.0\Assemblies\System.Web.Helpers.dll" "app\web\bin"
#    cpi "ref\Microsoft ASP.NET\ASP.NET MVC 3\Assemblies\System.Web.Mvc.dll" "app\web\bin"
#    cpi "ref\Microsoft ASP.NET\ASP.NET Web Pages\v1.0\Assemblies\System.Web.WebPages.dll" "app\web\bin"
#    cpi "ref\Microsoft ASP.NET\ASP.NET Web Pages\v1.0\Assemblies\Microsoft.Web.Infrastructure.dll" "app\web\bin"
#    cpi "ref\Microsoft ASP.NET\ASP.NET Web Pages\v1.0\Assemblies\System.Web.WebPages.Razor.dll" "app\web\bin"
#    cpi "ref\Microsoft ASP.NET\ASP.NET Web Pages\v1.0\Assemblies\System.Web.WebPages.Deployment.dll" "app\web\bin"
#    cpi "ref\Microsoft ASP.NET\ASP.NET Web Pages\v1.0\Assemblies\System.Web.Razor.dll" "app\web\bin"
}
