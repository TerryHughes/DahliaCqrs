Include bld\Giles.ps1

Task Verify -Depends Giles {
# TODO: no quotes around the pathing
    Exec { lib\Machine.Specifications\tools\mspec-clr4.exe tst\Dahlia.Specs.dll -s --html tst\ }
}
