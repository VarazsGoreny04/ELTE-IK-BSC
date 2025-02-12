#!/bin/sh

atfogo=$1
befogo=$2
if [ $# -lt 2 ]; then
if [ $# -lt 1 ]; then
echo -n "Kérem az átfogó értékét: "
read a
atfogo=$a
else
atfogo=$1
fi
echo -n "Kérem a befogó értékét: "
read b
befogo=$b
else
befogo=$2
fi

if [ $# -gt 2 ]; then
echo "Több mint 2 paramétert adott meg!"
else
masikbefogo=`expr $atfogo \* $atfogo - $befogo \* $befogo`
echo "A másik befogó hosszának négyzete: ($atfogo*$atfogo-$befogo*$befogo)=$masikbefogo"
fi