$file=$args[0]
$a=Read-Host Kérem a kisebb számot
#$a = Read-Host -Prompt "Kérek egy számot"
$b=Read-Host Kérem a nagyobb számot
Write-Host A paraméterként kapott fájl sorainak $a-$b. karaktere:
foreach($i in (Get-Content $file))
{
    $temp=$i.Substring($a-1,$b-1)
    Write-Host $temp
}