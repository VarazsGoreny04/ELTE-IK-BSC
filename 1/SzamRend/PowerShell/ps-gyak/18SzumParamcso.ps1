$osszeg=0

if(@($input).Count -gt 0)
{
    $input.Reset()
    foreach($i in $input)
    {
        $osszeg=$osszeg+$i
    }
}
else
{
    for($i=0; $i -lt $args.Count; $i++)
    {
        $osszeg=$osszeg+$args[$i]
    }
}
Write-Output "A paraméterek összege: $osszeg"