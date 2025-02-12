#7/
Write-Output "#6";
$sum = 0;
foreach ($i in $args)
{
    $sum += [int] $i;
}
Write-Output "A paraméterek összege: $sum";

Write-Output "`n#7";
$sum = 0;
for ($i = 0; $i -lt $args.Length; ++$i)
{
    $sum += $args[$i];
}
Write-Output "A paraméterek összege: $sum";

Write-Output "`n#8";
$sum = 0;
if (@($input).Count -gt 0)
{
    $input.Reset();
    foreach ($i in $input)
    {
        $sum += $i;
    }
}
else
{
    foreach ($i in $args)
    {
        $sum += $i;
    }
}
Write-Host "A paraméterek összege: $sum";

Write-Output "`n#9";
Write-Output "Másodfokú egyenletrendszert megoldó program:"
[double]$a = Read-Host -Prompt 'Írd be az "a" együtthatót';
[double]$b = Read-Host -Prompt 'Írd be a "b" együtthatót';
[double]$c = Read-Host -Prompt 'Írd be a "c" együtthatót';
Write-Output "Az egyenlet: $a*x2+$b*x+$c=0"
$res = ($b * $b) - (4 * $a * $c)
if ($res -gt 0)
{
    $res = [math]::Sqrt($res)
    Write-Output "Két megoldása van: $((-$b + $res)/(2*$a)) és $((-$b - $res)/(2*$a))"
}
elseif ($res -eq 0)
{
    Write-Output "Egy megoldása van: $(-$b/(2*$a))"
}
else
{
    Write-Output "Nincs megoldás"
}