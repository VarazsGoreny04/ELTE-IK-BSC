#Segédlet:
#Helyes típus megadásának kényszerítése:
#$ErrorActionPreference="SilentlyContinue"
$text = Get-Content $args[0];
$lines = $text.Length;

#6/
Write-Output "#1";
Get-ChildItem -Directory;

#Feladatok:
Write-Output "`n#2";
Get-Content $args[0] | Measure-Object -Line | Format-List -Property Lines

Write-Output "`n#3";
Write-Output "A(z) $($args[0]) fájl sorainak száma: $($lines)`n";

Write-Output "#4";
$a = [int]$args[1];
$b = [int]$args[2];
Write-Output "Kiírom az első és második paraméter összegét és szorzatát:`n$($a) és $($b) összege: $($a + $b) és szorzata: $($a * $b)";

Write-Output "`n#5";
foreach ($i in $text)
{
    $array = $i.Split(" ");
    Write-Output $array[1];
}

Write-Output "`n#6";
Write-Output "A paraméterként kapott fájl sorainak 2-4. karaktere:";
foreach ($i in $text)
{
    Write-Output $i.Substring(1,3);
}

Write-Output "`n#7";
Write-Host -NoNewLine "Kérem a kisebb sorszámot: ";
$kicsi = [int](Read-Host);
Write-Host -NoNewLine "Kérem a nagyobb sorszámot: ";
$nagy = [int](Read-Host);
Write-Output "A paraméterként kapott fájl sorainak $($kicsi)-$($nagy). karaktere:";
foreach ($i in $text)
{
    Write-Output $i.Substring($kicsi - 1,$nagy - 1);
}