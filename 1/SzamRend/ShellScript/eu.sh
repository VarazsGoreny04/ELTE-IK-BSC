#!/bin/sh
echo első: $1
utolso=`echo $* | cut -f$# -d' '`
echo utolsó: $utolso
echo -n "összegük:"
expr $1 + $utolso