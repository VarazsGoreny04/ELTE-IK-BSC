#1.feladat
Write-Host "Kiirom az aktualis konyvtar fajljait"
Get-ChildItem -File



#2.feladat
$a = (Get-Content $args[0]).Length
Write-Host "Lines: $a"
Get-Content $args| Measure-Object -Line| Format-List



#3.feladat
$a=0
foreach($i in (Get-Content $args).Split("\n"))
{
    $a++
}
Write-Host "A(z) $args fajl sorainak szama: $a"



#4.feladat
Write-Host "Kiiratom az elso es masodik parameter osszeget es szorzatat"
$szam1=$args[0]
$szam2=$args[1]
$szorzat=$szam1*$szam2
$osszeg=$szam1+$szam2
Write-Host "$szam1 es $szam2 osszege: $osszeg es szorzata: $szorzat"

#5.feladat
foreach($i in get-content $args)
{
    Write-Host $i.split(" ")[1]

}


#6.feladat

foreach($i in Get-Content $args)
{
    $seged=$i.substring(1,3)
    Write-Host $seged
}

#7.feladat
$ErrorActionPreference="SilentlyContinue"
Write-Host "Kerem a kisebb sorszamot: " -NoNewline
$1=Read-Host
Write-Host "Kerem a nagyobb sorszamot: " -NoNewline
$2=Read-Host
$seged=$2-$1+1
foreach($i in (Get-Content $args).Split("\n"))
{
    write-host $i.Substring($1-1,$seged)
}
-ErrorAction SilentlyContinue