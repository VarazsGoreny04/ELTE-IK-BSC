$osszeg=0
for($i=0; $i -lt $args.Count; $i++)
{
    $osszeg=$osszeg+$args[$i]
}
Write-Output "A paraméterek összege: $osszeg"