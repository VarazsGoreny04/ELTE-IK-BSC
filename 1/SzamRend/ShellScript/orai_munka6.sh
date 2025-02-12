#!/bin/sh

i=1
szum=0
while [ $i -le 5 ]
do
echo -n "Kérem adjon meg egy számot: "
read a
szum=`expr $szum + $a`
i=`expr $i + 1`
done
echo "A beírt sztámok összege: $szum"