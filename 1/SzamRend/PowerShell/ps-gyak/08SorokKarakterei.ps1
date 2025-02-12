Write-Host A paraméterként kapott fájl sorainak 2-4. karaktere:
$file=$args[0]
foreach($i in (Get-Content $file))
{
    $temp=$i.Substring(1,3)
    Write-Host $temp
}