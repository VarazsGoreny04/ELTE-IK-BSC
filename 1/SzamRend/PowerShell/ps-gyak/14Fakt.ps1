if($args.Count -ne 1)
{
Write-Host "Pontosan egy paraméter kell! A parancs helyes használata: 14Fakt.ps1 <szám>"
}
else
{
$fakt=$args[0]
$i=1
while($i -lt $args[0])
{
    $fakt=$fakt*$i
    $i=$i+1
}
Write-Host "A(z) $args faktoriálisa: $fakt"
}