#$ErrorActionPreference="SilentlyContinue"
param
(
[Parameter(Mandatory=$True)][int]$n
)
#Write-Output (-join("Hello ",$szám,"!"))

Write-Output "#5";
$fact = 1;
for ($i = $n; $i -gt 1; --$i)
{
    $fact *= $i;
}
Write-Output "A(z) $($args[1]) faktoriálisa: $($fact)";