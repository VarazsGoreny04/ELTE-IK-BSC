$sum = 0;
if (@($input).Count -gt 0)
{
    $input.Reset();
    foreach ($i in $input)
    {
        $sum += $i;
    }
}
else
{
    foreach ($i in $args)
    {
        $sum += $i;
    }
}
Write-Host $sum;