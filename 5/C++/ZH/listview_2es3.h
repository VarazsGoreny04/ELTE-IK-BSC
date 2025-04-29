/*
	array_view
	- tömbként működik
	- listaként van implementálva
	- at, [] műveletek
	- tömbben tároljuk el a lista elemeinek pointereit
	- array_view<T, TIterable>
 */
/*
	vector_view
	- push_back, sort, sort(felhaszálói_rendezés)
	- A SORT NEM RENDEZI A LISTÁBAN LÉVŐ ADATOKAT, CSAK A NÉZET LÁTJA ÚGY
	- kibővítése az array_view-nak (öröklődéssel)
 */

#ifndef ARRDECOR__H
#define ARRDECOR__H

#include <list>
#include <vector>
#include <iostream>

template <typename T, typename TIterable>
class array_view
{
private:
	TIterable array;

public:
	array_view(typename std::list<T> &list);

	// Indexelés referencia szerint
	T &at(int index) const
	{
		return *array[index];
	}

	T &operator[](int index)
	{
		return at(index);
	}

	const T &operator[](int index) const
	{
		return at(index);
	}
};

template <typename T, typename TIterable>
array_view<T, TIterable>::array_view(std::list<T> &list)
{
	for (typename std::list<T>::iterator it = list.begin(); it != list.end(); ++it)
		array.push_back(it);
}

/* template <typename T, typename TIterable>
class array_view
{
private:
public:
};

template <typename T, typename TIterable>
array_view<T, TIterable>::array_view()
{
} */

#endif