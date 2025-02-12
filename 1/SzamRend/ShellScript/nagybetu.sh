#!/bin/sh

echo -n "Kérem a szöveget: "
read a
echo -n "Nagybetűkkel:     "
echo $a | tr "a-záéíóöőúüű" "A-ZÁÉÍÓÖŐÚÜŰ"