pushd
Split-Path $MyInvocation.MyCommand.Path | cd

Include RemoveDirectory.ps1

popd


Task Clean {
    RemoveDirectory "app"
    RemoveDirectory "bin"
}
