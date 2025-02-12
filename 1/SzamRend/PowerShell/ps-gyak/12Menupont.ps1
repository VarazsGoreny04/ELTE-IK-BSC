$a=0
while($a -ne 3)
{
    Write-Output "Kérem válasszon!"
    Write-Output "1. Első menüpont"
    Write-Output "2. Második menüpont"
    Write-Output "Kilépés"
    [int]$a=Read-Host
    if($a -eq 1)
    {
        Write-Output "Ön az első menüpontot választotta"
        Start-Sleep -s 2
        Clear-Host
    }
    elseif($a -eq 2)
    {
        Write-Output "Ön a második menüpontot választotta"
        Start-Sleep -s 2
        Clear-Host
    }
    elseif($a -eq 3)
    {
        Write-Output "Kilépés"
    }
    else
    {
        Write-Output "Hibás választás"
        Start-Sleep -s 2
        Clear-Host
    }
}