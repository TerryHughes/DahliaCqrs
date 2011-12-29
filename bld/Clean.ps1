Include bld\Remove-Directory.ps1

Task Clean {
    Remove-Directory "app"
    Remove-Directory "bin"
}
