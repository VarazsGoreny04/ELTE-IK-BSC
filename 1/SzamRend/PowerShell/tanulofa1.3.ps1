#1 feladat
param
(
[Parameter(Mandatory=$true)]$Fajl
)
Write-Host "Kerem a kisebb sorszamot: " -NoNewline
$1=Read-Host
Write-Host "Kerem a nagyobb sorszamot: " -NoNewline
$2=Read-Host

if($2 -lt $1)
{
    Write-Host "Hibas sorszammegadas!"
}
else
{
$seged=$2-$1+1
foreach($i in (get-content $Fajl).Split("\n"))
{
    Write-Host $i.Substring($1-1,$seged)
}
}




#2. feladat
(
[Parameter(Mandatory=$true)]$Fajl
)
Write-Host "Kerem a kisebb sorszamot: " -NoNewline
$1=Read-Host
Write-Host "Kerem a nagyobb sorszamot: " -NoNewline
$2=Read-Host

if($2 -lt $1)
{
    $seged=$1-$2+1
    foreach($i in (get-content $Fajl).Split("\n"))
{
    Write-Host $i.Substring($2-1,$seged)
}
}
else
{
$seged=$2-$1+1
foreach($i in (get-content $Fajl).Split("\n"))
{
    Write-Host $i.Substring($1-1,$seged)
}
}




#3.feladat
param
(
[Parameter(Mandatory=$true)]$Fajl
)

Write-Host "Kerem valasszon!"
Write-Host "1. Elso menupont!"
Write-Host "2. Masodik menupont!"
Write-Host "3. Kilepes"

$1=Read-Host
if($1 -eq 1)
{
    Write-Host "On az elso menupontot valasztotta"
    Start-Sleep 2
    Clear-Host
}
elseif($1 -eq 2)
{
    Write-Host "On a masodik menupontot valasztotta"
    Start-Sleep 2
    Clear-Host
}
elseif($1 -eq 3)
{
    Write-Host "On a kilepest valasztotta"
    Start-Sleep 2
    Clear-Host
}
else
{
    Write-Host "Hibas valasztas!"
    Start-Sleep 2
    Clear-Host
}




#4.feladat
if($args.Count -eq 1)
{
    $i=$args[0]
    $tarolo=1
    while($i -ne 1)
    {
        $tarolo=$tarolo*$i
        $i--
    }
    write-host "A(z) $args[0] faktorialisa: $tarolo"
}
else
{
    Write-Host "Pontosan egy parameter kell! A parancs helyes hasznalata: tanulofajl2.ps1 <szam>"
}




#5. feladat
param
(
[Parameter(Mandatory=$true)][int]$n
)

$tarolo=1
while($n -ne 1)
{
    $tarolo=$tarolo*$n
    $n--
}
write-host "A(z) $n faktorialisa: $tarolo"




#6.feladat
$szam=$args.Count
$sum=0
foreach($i in $args)
{
    $sum+=$i
}
write-host "A parameterek osszege: $sum"




#7.feladat
$szam=$args.Count
$sum=0
for($i=0; $i -lt $szam; $i++)
{
    $sum+=$args[$i]
}
write-host "A parameterek osszege: $sum"




#8.feladat
$szam=$args.Count
$szam2=@($input).Count
$sum=0


if($szam2 -eq 0)
{
    for($i=0; $i -lt $szam; $i++)
    {
        $sum+=$args[$i]
    }

}


elseif($szam2 -ne 0)
{
    $input.reset()
    foreach($i in $input)
    {
        $sum+=$i
    }
}
write-host "A parameterek osszege: $sum"




#9.feladat
$1="""a"""
$2="""b"""
$3="""c"""

write-host "Masodfoku egyenlet megoldo program"
[int]$a=read-host -Prompt "Ird be az $1 egyuthatot"
[int]$b=read-host -Prompt "Ird be az $2 egyuthatot"
[int]$c=read-host -Prompt "Ird be az $3 egyuthatot"
write-host "Az egyenlet: $a*x2+$b*x+$c=0"

$megoldas1=((-1)*$b+[math]::Sqrt((($b*$b)-(4*$a*$c))))/(2*$a)
$megoldas2=((-1)*$b-[math]::Sqrt((($b*$b)-(4*$a*$c))))/(2*$a)

if($megoldas1 -eq $megoldas2)
{
    write-host "Egy megoldas van: $megoldas1"
}

elseif($megoldas1 -gt $megoldas2 -or $megoldas1 -lt $megoldas2)
{
    write-host "Az egyenlet megoldasai:  $megoldas1 es $megoldas2"
}

else
{
    write-host "Nincs megoldas"
}




#10.feladat
if(Test-Path -Path ./Páratlansorok.txt)
{
    Remove-Item -Path ./Páratlansorok.txt
}
if(Test-Path -Path ./Párossorok.txt)
{
     Remove-Item -Path ./Párossorok.txt
}

New-Item -ItemType File -Name "Páratlansorok.txt"
New-Item -ItemType File -Name "Párossorok.txt"

$a=1
foreach($i in (Get-Content $args).split("\n"))
{
    if($a % 2 -eq 0)
    {
        Add-Content -Value $i -Path .\Párossorok.txt
    }
    elseif($a % 2 -ne 0)
    {
        Add-Content -Value $i -Path .\Páratlansorok.txt
    }
    $a++
}




#11.feladat
[int]$szam=Read-Host -Prompt "Irj be egy termeszetes szamot"
if($szam -eq 0)
{
    Write-Host "A szam nem prim"
}
elseif($szam -lt 0)
{
    Write-Host "Nem termeszetes szamot irtal be!"
}

else
{
    for($i=1; $i -le $szam; $i++)
    {
        if($szam % $i -eq 0)
        {
            $szamlalo++
        }
    }
    if($szamlalo -lt 2)
    {
        Write-Host "A szam sem nem prim, sem nem osszetett."
    }
    elseif($szamlalo -gt 2)
    {
        Write-Host "A szam nem prim."
    }
    elseif($szamlalo -eq 2)
    {
        Write-Host "A szam prim."
    }
}




#12.feladat
[int]$szam1=Read-Host -Prompt "Kerem az elso szamot"
[int]$szam2=Read-Host -Prompt "Kerem a masodik szamot"

if($szam1 -lt 0)
{
    $szam1=(-1)*$szam1
}
if($szam2 -lt 0)
{
    $szam2=(-1)*$szam2
}

if($szam1 -gt $szam2)
{
   $kisebb = $szam2;
   $nagyobb = $szam1
}

else
{
  $kisebb = $szam1;
  $nagyobb = $szam2
}

$max=0
for ([int] $i = $kisebb; $i -gt 0; $i--)
{
    if ($kisebb % $i -eq 0 -and $max -lt $i -and $nagyobb % $i -eq 0)
    {
        $max=$i
    }
}
Write-Host "A legnagyobb kozos osztojuk: $max"
