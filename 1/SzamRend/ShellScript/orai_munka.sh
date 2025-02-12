#!/bin/sh

echo -n "Kérek egy számot: "
read a
if [ $a -le 10 ]
then
echo "A szám kisebb mint 10"
elif [ $a -ge 10 ]
then
echo "A szám nagyobb mint 10"
else
echo "A szám egyenlő 10-zel"
fi