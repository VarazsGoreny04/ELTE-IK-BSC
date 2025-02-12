Set-Location C:\Users\monde\Documents
Push-Location c:\ #--> csak ideiglenes
Pop-Location


New-Item -ItemType File -name allat.txt -Value "Hehe"
Copy-Item allat.txt -Destination "allat masolata.txt" #recurisve itt is
Rename-Item .\allat.txt -NewName "nincs ebben semmi"
Move-Item '.\nincs ebben semmi' -Destination ".\celmappa\ez is ures"
Remove-Item -Include 1* -Exclude "hah.txt" #-force -> vedett fajlokat is


test-path .\tesztelo #letezik a fajl?
set-content .\1.txt -value kutya # felulirja -nonewline
add-content .\1.txt -value kutya # hozzafuzi
Get-Content .\1.txt #-totalcount -> sor elejetol -tail -> vegetol (-tail es -nonewline)
Get-Content .\allatocslkak.txt | Select-String -Pattern "a$"

Get-Date -Year
(Get-Date).AddDays(5)
Get-ChildItem | Sort-Object LastWriteTime,Name | Select-Object -First 5
Get-ChildItem -Path C:\ -force -file -Recurse #ls -> rejtett fajl, fajl,rekurziv
Get-ChildItem -Path C:\Windows\System32\ | Sort-Object  LastAccessTime -Descending | Format-Table
Get-ChildItem -Recurse| Format-List -Property Name,Length
Get-ChildItem -Recurse| Format-table -Property Name,Length
Get-ChildItem | Sort-Object Mode,Name -Unique| Where-Object Length -GT 0
Get-Content .\1.txt | measure-object -Line -Word -Character
Get-ChildItem | Select-Object -skiplast 2
Get-Member #metodus

Get-Variable #valtozok
Clear-Variable #tartalom torles
Remove-Variable #valtozo torles


$1=0
$1.ToInt32()
$szoveg="hah"
$szoveg.ToCharArray()
$szoveg.ToString()
[math]::PI
"egy,ketto,harom,negy,ot, hat".Split(",")
"egy,ketto,harom,negy,ot, hat".Substring(5,10)
"egy,ketto,harom,negy,ot, hat".Replace(",","es")
Write-Host $MyInvocation.MyCommand.Name #script neve
Write-Host 1,2,3,4,5 -Separator " es " -ForegroundColor Red -BackgroundColor White


$input #csovezetek
@($input).Count
$input.reset()