#7/
Write-Output "#10";
$text = Get-Content $args[0];
if(Test-Path -Path ./Páratlansorok.txt)
{
    Remove-Item -Path ./Páratlansorok.txt;
}
if(Test-Path -Path ./Párossorok.txt)
{
    Remove-Item -Path ./Párossorok.txt;
}
New-Item -ItemType File -Name "PáratlanSorok.txt";
New-Item -ItemType File -Name "PárosSorok.txt";
for ($i = 0; $i -lt $text.Length; ++$i)
{
    if ($i % 2 -eq 0)
    {
        Add-Content .\PárosSorok.txt -Value $text[$i];
    }
    else
    {
        Add-Content .\PáratlanSorok.txt -Value $text[$i];
    }
}

Write-Output "`n#11";
[int]$szam = Read-Host -Prompt "Írj be egy természetes számot";
if ($szam -gt 0 -and $szam % 1 -eq 0)
{
    $e = 0;
    for ($i = $szam - 1; $i -gt 1; --$i)
    {
        if($szam % $i -eq 0)
        {
            ++$e;
        }
    }
    if ($e -gt 0)
    {
        Write-Output "A szám nem prím.";
    }
    else
    {
        Write-Output "A szám prím.";
    }
}
else
{
        Write-Output "Nem természetes számot írtál be!";
}

Write-Output "`n#12";
[int]$egy = Read-Host -Prompt "Írj be egy egész számot";
[int]$ketto = Read-Host -Prompt "Írj be még egy egész számot";
if ($egy -gt $ketto)
{
    $f = $egy;
    $egy = $ketto;
    $ketto = $f;
}
$oszto = 1;
for ($i = 2; $i -lt $egy; ++$i)
{
    if ($egy % $i -eq 0 -and $ketto % $i -eq 0)
    {
        $oszto = $i;
    }
}
Write-Output "A legnagyobb közös osztójuk: $oszto"