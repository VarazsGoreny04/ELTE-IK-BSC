#$fakt=0;
#Write-Host -NoNewline "n: "
Param
(
    [Parameter(Mandatory=$True)][int]$n
)

$i=1
$temp=$n
while($i -lt $n)
{
    $temp=$temp*$i
    $i=$i+1
}
Write-Host "A(z) $n faktoriálisa: $temp"