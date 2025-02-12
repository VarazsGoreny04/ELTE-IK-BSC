#Sorok beolvasása:
$szoveg = Get-Content $args[0];

#Változók:
$bekes = 0; $orok = 0; $maxeroszak = 0;

#Feladatok elvégzése:
Write-Output "`nEroszakmentes munkahelyek:"
foreach ($i in $szoveg)
{
    $sor = $i.Split(",");
    if ($sor[2] -eq " 0")
    {
        #Erőszakmentes munkahelyek kiírása:
        Write-Output $sor[0];
        $bekes++;
    }
    #Őrök számának összeadása:
    $orok += [int] $sor[3]
    #Legtöbb erőszak számának keresése:
    $eroszakszam = [int] $sor[2];
    if ($eroszakszam -gt $maxeroszak)
    {
        $maxeroszak = $eroszakszam;
    }
}
#Ha nem volt erőszakmentes munkahely:
if ($bekes -eq 0)
{
    Write-Output "NINCS";
}
#Őrök számának kiírása:
Write-Output "`nOrok szam: $orok`n`nLegtobb eroszak:";
#Ha nem volt erőszakos munkahely:
if($maxeroszak -eq 0)
{
    Write-Output "NINCS"
}
#Egyébként az összes legerőszakosabb munkahely:
else
{
    foreach ($i in $szoveg)
    {
        $sor = $i.Split(",");
        if ([int] $sor[2] -eq $maxeroszak)
        {
            Write-Output "$($sor[0]) :$($sor[1])";
        }
    }
}