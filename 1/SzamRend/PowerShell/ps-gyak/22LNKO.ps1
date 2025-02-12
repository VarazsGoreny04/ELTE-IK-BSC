[int]$a=Read-Host "Kérem az első számot"
[int]$b=Read-Host "Kérem a második számot"

$a_array=@()
$b_array=@()


if ($a -lt 0)
{
 $a = ((-1) * $a)
}

if ($b -lt 0)
{
 $b = ((-1) * $b)
}

for($i=$a; $i -gt 0; $i--)
{
    if($a%$i -eq 0)
    {
        $a_array+=$i
    }
}

for($i=$b; $i -gt 0; $i--)
{
    if($b%$i -eq 0)
    {
        $b_array+=$i
    }
}

$oszto=0;
if($a -gt $b)
{
    for($i=0; $i -lt $a; $i++)
{
    if($b_array.Contains($a_array[$i]))
    {
        $oszto=$a_array[$i]
        break
    }
}
}
elseif($b -gt $a)
{
    for($i=0; $i -lt $b; $i++)
{
    if($a_array.Contains($b_array[$i]))
    {
        $oszto=$b_array[$i]
        break
    }
}
}
else
{
for($i=0; $i -lt $a; $i++)
{
    if($a_array.Contains($b_array[$i]))
    {
        $oszto=$b_array[$i]
        break
    }
}
}
Write-Host "Legnagyobb közös osztójuk: $oszto"