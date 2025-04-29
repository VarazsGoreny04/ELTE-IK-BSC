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
protected:
	TIterable array;

public:
	array_view(typename std::list<T> &list);

	T &at(int index)
	{
		return *array[index];
	}
	
	const T &at(int index) const
	{
		return *array[index];
	}

	T &operator[](int index)
	{
		return at(index);
	}

	/* const T &operator[](int index) const
	{
		return at(index);
	} */
};

template <typename T, typename TIterable>
array_view<T, TIterable>::array_view(std::list<T> &list)
{
	for (typename std::list<T>::iterator it = list.begin(); it != list.end(); ++it)
		array.push_back(it);
}

template <typename T, typename TIterable = std::vector<std::list<int>::iterator> >
class vector_view : public array_view<T, TIterable>
{
private:
	std::list<T> *list;

public:
	vector_view(std::list<T> &list);

	void push_back(T data)
	{
		list->push_back(data);

		typename std::list<T>::iterator a = list->end();

		array_view<T, TIterable>::array.push_back(--a);

		//std::cout << "test - " << (this->at(0)) << &(*list->end()) << std::endl;
	}

	/* void sort()
	{
		int n = array.size();

		for (int i = 0; i < n - 1; ++i)
		{
			for (int j = 0; j < n - i - 1; ++j)
			{
				if (*array[j] > *array[j + 1])
					std::swap(array[j], array[j + 1]);
			}
		}
	} */
};

template <typename T, typename TIterable>
vector_view<T, TIterable>::vector_view(std::list<T> &list) : array_view<T, TIterable>(list)
{
	this->list = &list;
}

#endif