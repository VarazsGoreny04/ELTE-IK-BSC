$a = Read-Host -Prompt "Kérek egy számot"
switch ($a)
{
1 {Get-ChildItem}
2 {    $b = Read-Host -Prompt "Kérek egy másik számot"
        Write-Host Tízszerese: ([int]$b * 10)
  }
3 {Write-Host Köszönöm!}
default {Write-Host nagyobb mint 3}
}