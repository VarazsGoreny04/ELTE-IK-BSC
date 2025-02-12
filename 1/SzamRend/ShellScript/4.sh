#!/bin/sh

valos=e
if [ $1 -ge 0 -a $1 -lt 10 ]; then
valos=$1
elif [ $1 = "A" ]; then
valos=10
elif [ $1 = "B" ]; then
valos=11
elif [ $1 = "C" ]; then
valos=12
elif [ $1 = "D" ]; then
valos=13
elif [ $1 = "E" ]; then
valos=14
elif [ $1 = "F" ]; then
valos=15
fi
if [ "$valos" = "e" ]; then
echo "Nem hexadecimális számot adott meg!"
else
echo $valos
fi



