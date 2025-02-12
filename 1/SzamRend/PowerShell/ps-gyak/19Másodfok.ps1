Write-Output "Másodfokú egyenlet megoldó program"
$a=Read-Host 'Írd be az "a" eggyütthatót'
#$a = Read-Host -Prompt "Kérek egy számot"
$b=Read-Host 'Írd be az "b" eggyütthatót'
$c=Read-Host 'Írd be az "c" eggyütthatót'
Write-Host "Az egyenlet: $a*x2+$b*x+$c=0"

$egyenlet = (($b * $b) - (4 * ($a * $c)))

if ($egyenlet -lt 0)
{
    Write-Host Nincs megoldás
}

$sqrt = [math]::Sqrt($egyenlet)

if ($egyenlet -eq 0)
{
    Write-Host Egy megoldás van: (((-1) * $b) / (2 * $a))
} else
{
    $result1 = ((((-1) * $b) + $sqrt) / (2 * $a))
    $result2 = ((((-1) * $b) - $sqrt) / (2 * $a))
    Write-Host Az egyenlet megoldásai: $result1 és $result2
}