#!/bin/sh
szam=1
until [ $szam -eq 0 ]
do
echo "Hány felhasználót listázzak ki?"
read szam
who | head -n $szam
done