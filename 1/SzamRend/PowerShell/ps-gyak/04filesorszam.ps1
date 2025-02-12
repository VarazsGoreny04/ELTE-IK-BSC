# Get-Content $args[0] | Measure-Object -Line | Format-List Lines

$file=$args[0]
$i=0
Write-Host
foreach($e in (Get-Content $file))
{
    $i++;
}
Write-Host Lines : $i