function RemoveDirectory
{
    param(
        [Parameter(Mandatory = 1)] [string]$path
    )

    if (Test-Path $path)
    {
        rmdir -r $path
    }
}
