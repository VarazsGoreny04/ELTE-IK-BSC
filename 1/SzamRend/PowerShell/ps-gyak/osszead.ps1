$a=0;

if(@($input).Count -ne 0)
{
    $input.Reset();
    foreach($i in $input)
    {
        $a+=$i;
    }
}
else
{
    foreach($i in $args)
    {
        $a+=$i;
    }
}
Write-Host $a