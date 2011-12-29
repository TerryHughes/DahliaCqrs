# TODO: what to do with this?

function Get-FilesToCompile
{
    return $input | CorrectPath | Get-SourceFiles | Remove-SpecFiles | Add-SharedAssemblyInfo | Printable
}

function Printable
{
    return $input | % { $_.FullName }
}

function Add-SharedAssemblyInfo
{
    return $input + ("SharedAssemblyInfo.cs" | CorrectPath | gci)
}

function Remove-NonSpecFiles
{
    return $input | ? { $_ -match "Specs" }
}

function Remove-SpecFiles
{
    return $input | ? { $_ -notmatch "Specs" }
}

function Get-SourceFiles
{
    return $input | gci -i "*.cs" -r
}

function CorrectPath
{
    return $input | % { "src\$_" }
}
