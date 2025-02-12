#!/bin/sh

echo -n "Kérek egy számot: "
read a
if [ $a -gt 999 -o $a -lt -999 ]; then
echo "A szám háromnál több jegyű"
elif [ $a -gt 99 -o $a -lt -99 ]; then
echo "A szám háromjegyű"
elif [ $a -gt 9 -o $a -lt -9 ]; then
echo "A szám kétjegyű"
else
echo "A szám egyjegyű"
fi
