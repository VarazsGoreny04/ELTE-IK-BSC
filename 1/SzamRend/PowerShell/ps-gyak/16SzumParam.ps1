$osszeg=0
foreach($i in $args)
{
    $osszeg=$osszeg+$i
}
Write-Output "A paraméterek összege: $osszeg"