Write-Host A paraméterként kapott fájl sorainak második szavai:
$file=$args[0]
foreach($i in (Get-Content $file))
{
    $temp=$i.Split(" ")
    Write-Host $temp[1]
}