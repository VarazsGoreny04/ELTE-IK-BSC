#param
#(
#    [Parameter(Mandatory=$True)][int]$szám
#)
#Write-Output (-join("Hello",$szám,"!"))

$a=5
foreach ($i in 1,2,3,4,5)
{
    Write-host $i "Hajrá magyarok!"
}