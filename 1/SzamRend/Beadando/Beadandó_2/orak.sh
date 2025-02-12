#!/bin/sh

#Fájl bekérése
text=`cat $1`
#Közös értékek
IFS=',
'
counter=0
teacher=""
#a feladat
szTeacher=""
szNull=0
#b feladat
numOfClasses=0
everyone=""
#c feladat
first=""
activationKey=0

#a és b feladat számítása
for i in $text
do
    if [ `expr $counter % 6` -eq 0 ]; then
	teacher=$i
    else
	if [ "$i" = " Sz" ]; then
	    szTeacher="$szTeacher\n$teacher"
	    szNull=`expr $szNull + 1`
	fi
	IFS=' '
	for j in $i
	do
	    if [ "$j" != "H" -a "$j" != "K" -a "$j" != "Sz" -a "$j" != "Cs" -a "$j" != "P" ]; then
	    numOfClasses=`expr $numOfClasses + 1`
	    fi
	done
	IFS=',
'
    fi
    counter=`expr $counter + 1`
    if [ `expr $counter % 6` -eq 0 ]; then
	everyone="$everyone\n$teacher: $numOfClasses"
	numOfClasses=0
    fi
done

#a és b feladat kiíratása
echo -n "\na feladat:"
if [ $szNull -gt 0 ]; then
    echo "$szTeacher"
else
    echo "NINCS"
fi
echo "\nb feladat:$everyone"

#c feladat számítása (és adatbekérés)
echo "\nc feladat:"
IFS=',
'
read day
counter=0
for i in $text
do
    if [ `expr $counter % 6` -eq 0 ]; then
	teacher=$i
    else
	IFS=' '
	for j in $i
	do
	    if [ "$j" = "$day" ]; then
		activationKey=1
	    else
		if [ $activationKey -eq 1 -a "$j" != "1" ]; then
		    first="$first$teacher\n"
		fi
		activationKey=0
	    fi
	done
    IFS=',
'
    fi
    counter=`expr $counter + 1`
done

#c feladat kiíratása
if [ -z "$first" ]; then
    echo "NINCS\n"
else
    echo "$first"
fi