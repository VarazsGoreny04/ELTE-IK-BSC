[int]$a=Read-Host "Írj be egy természetes számot"
if($a -lt 0)
{
    Write-Host Nem természetes számot írtál be
}

$count = 0
for($i = $a; $i -ge 1; $i--)
{
    if (($a %  $i) -eq 0)
    {
        $count++
    }
}


switch ($count)
{
    1 {"A szám se nem prím se nem összetett!"}
    2 {"A szám prím!"}
    Default {"A szám nem prím!"}
}