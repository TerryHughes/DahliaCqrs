function MakeDirectory
{
    param(
        [Parameter(Mandatory = 1)] [string]$path
    )

    if (Test-Path $path)
    {
        return;
    }

    mkdir $path | Out-Null
}
