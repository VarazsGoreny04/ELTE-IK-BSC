$file=$args[0]
if(Test-Path -Path .\PárosSorok.txt)
{
    Remove-Item .\PárosSorok.txt
}
if(Test-Path -Path .\PáratlanSorok.txt)
{
    Remove-Item .\PáratlanSorok.txt
}
New-Item -ItemType File -Name PárosSorok.txt | Out-Null
New-Item -ItemType File -Name PáratlanSorok.txt | Out-Null
$i=1;
foreach($temp in (Get-Content $file))
{
    if($i%2 -eq 0)
    {
        $temp >> .\PárosSorok.txt
    }
    else
    {
        $temp >> .\PáratlanSorok.txt
    }
    $i=$i+1
}