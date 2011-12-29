Include bld\RemoveDirectory.ps1

Task Clean {
    RemoveDirectory "app"
    RemoveDirectory "bin"
}
