#$ErrorActionPreference="SilentlyContinue"
param
(
[Parameter(Mandatory=$True)][string]$szám
)
Write-Output (-join("Hello ",$szám,"!"))