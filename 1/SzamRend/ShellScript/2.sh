#!/bin/sh

kivon=0
for i in $*
do
if [ $i -gt 0 ]; then
kivon=`expr $kivon + $i`
fi
done
eredmeny=`expr 100 - $kivon`
echo "A pozitív értékeket 100-ból kivonva az eredmény: $eredmeny"