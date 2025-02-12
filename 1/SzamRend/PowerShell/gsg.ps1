if($args.Count -gt 2)
{
    Write-Host Több mint 2 paramétert adott meg!
}
elseif($args.Count -eq 1)
{
    [int]$b=Read-Host -Prompt "Kérem az osztó értékét"
    $p1=$args[0]
    $r=$p1/$b
    Write-Host $p1/$b=$r
}
elseif($args.Count -eq 2)
{
    $p1=$args[0]
    $p2=$args[1]
    $r=$p1/$p2
    Write-Host $p1/$p2=$r
}
else
{
    [int]$a=Read-Host -Prompt "Kérem az osztandó értékét"
    [int]$b=Read-Host -Prompt "Kérem az osztó értékét"
    $r=$a/$b
    Write-Host $a/$b=$r
}











if(@($input).Count -ne 0)
{
    $input.Reset()
    [int]$max=-10
    foreach($i in $input)
    {
        if([int]$i -gt $max)
        {
            $max=$i
        }
    }
    Write-Host A legnagyobb érték: $max
}
elseif($args.Count -ne 0)
{
    [int]$max=$args[0]
    foreach($i in $args)
    {
        if([int]$i -gt $max)
        {
            $max=$i
        }
    }
    Write-Host A legnagyobb érték: $max
}






param
(
  [Parameter(Mandatory=$true)][int]$N
)

Get-ChildItem -Path C:\Windows\System32\ | Sort-Object  LastAccessTime -Descending | Format-Table





do
{
    $a=Read-Host -Prompt "Írj be egy hexadecimális számjegyet"

    if($a -eq 'A')
    {
        Write-Host 10
    }
    elseif($a -eq 'B')
    {
        Write-Host 11
    }
    elseif($a -eq 'C')
    {
        Write-Host 12
    }
    elseif($a -eq 'D')
    {
        Write-Host 13
    }
    elseif($a -eq 'E')
    {
        Write-Host 14
    }
    elseif($a -eq 'F')
    {
        Write-Host 15
    }
    elseif($a -eq 0)
    {
        Write-Host 0
    }
    elseif($a -eq 1)
    {
        Write-Host 1
    }
    elseif($a -eq 2)
    {
        Write-Host 2
    }
    elseif($a -eq 3)
    {
        Write-Host 3
    }
    elseif($a -eq 4)
    {
        Write-Host 4
    }
    elseif($a -eq 5)
    {
        Write-Host 5
    }
    elseif($a -eq 6)
    {
        Write-Host 6
    }
    elseif($a -eq 7)
    {
        Write-Host 7
    }
    elseif($a -eq 8)
    {
        Write-Host 8
    }
    elseif($a -eq 9)
    {
        Write-Host 9
    }
    elseif($a -eq "vége")
    {
        #exit
    }
    else
    {
        Write-Host Nem hexadecimális számjegyet írtál be!
    }
}
while($a -ne "vége")