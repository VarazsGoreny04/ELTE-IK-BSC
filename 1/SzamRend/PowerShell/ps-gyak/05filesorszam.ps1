$file=$args[0]
$i=0

Write-Host
foreach($e in (Get-Content $file))
{
    $i++;
}
Write-Host Az $file fájl sorainak száma: $i