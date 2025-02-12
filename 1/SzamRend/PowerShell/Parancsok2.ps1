$text = Get-Content $args[0];

#7/
Write-Output "#1";
Write-Host -NoNewLine "Kérem a kisebb sorszámot: ";
$kicsi = [int](Read-Host);
Write-Host -NoNewLine "Kérem a nagyobb sorszámot: ";
$nagy = [int](Read-Host);
if ($kicsi -gt $nagy)
{
    Write-Output "Hibás sorszámmegadás!";
}
else
{
    Write-Output "A paraméterként kapott fájl sorainak $($kicsi)-$($nagy). karaktere:";
    foreach ($i in $text)
    {
        Write-Output $i.Substring($kicsi - 1,$nagy - 1);
    }
}

Write-Output "`n#2";
Write-Host -NoNewLine "Kérem a kisebb sorszámot: ";
$kicsi = [int](Read-Host);
Write-Host -NoNewLine "Kérem a nagyobb sorszámot: ";
$nagy = [int](Read-Host);
if ($kicsi -gt $nagy)
{
    Write-Output "A paraméterként kapott fájl sorainak $($nagy)-$($kicsi). karaktere:"
    foreach ($i in $text)
    {
        Write-Output $i.Substring($nagy - 1,$kicsi - 1);
    }
}
else
{
    Write-Output "A paraméterként kapott fájl sorainak $($kicsi)-$($nagy). karaktere:";
    foreach ($i in $text)
    {
        Write-Output $i.Substring($kicsi - 1,$nagy - 1);
    }
}
Read-Host;

Write-Output "`n#3";
$valasz = "";
while ($valasz -ne "3")
{
    Clear-Host;
    Write-Output "Kérem válasszon!`n1. Első menüpont`n2. Második menüpont`n3. Kilépés";
    switch ($valasz = Read-Host)
    {
        "1" { Write-Output "Ön az első menüpontot választotta!" }
        "2" { Write-Output "Ön a második menüpontot választotta!" }
        "3" { Write-Output "Kilépés..." }
        default { Write-Output "Hibás választás!" }
    }
    Start-Sleep -Seconds 2;
}

Write-Output "`n#4";
$fact = 1;
if ($args.Length -eq 3)
{
    for ($i = $args[1]; $i -gt 1; --$i)
    {
        $fact *= $i;
    }
    Write-Output "A(z) $($args[1]) faktoriálisa: $($fact)";
}
else
{
    Write-Output "Pontosan három paraméter kell! A parancs helyes használata: $($MyInvocation.MyCommand.Name) <fájlnév> <szám> <szám>";
}