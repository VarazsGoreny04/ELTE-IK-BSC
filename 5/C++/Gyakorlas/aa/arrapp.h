#ifndef ARRAPP_H
#define ARRAPP_H

#include <list>
#include <vector>
#include <stdexcept>
#include <iterator>
#include <algorithm>

template <typename T>
class array_appender
{
private:
	std::list<T *> data; // A belső tároló

public:
	// Típusdefiniálás iterátorokhoz
	typedef typename std::list<T *>::iterator iterator;
	typedef typename std::list<T *>::const_iterator const_iterator;

	// Konstruktor: inicializálja az adattárolót egy tömbbel
	array_appender(T *input_data, size_t length)
	{
		for (size_t i = 0; i < length; ++i)
			data.push_back(input_data++);
	}

	// Elemek hozzáfűzése egy tömbből
	void append(T *input_data, size_t length)
	{
		for (size_t i = 0; i < length; ++i)
			data.push_back(input_data++);
	}

	// Elemek hozzáfűzése egy std::vector-ból
	void append(std::vector<T> &input_data)
	{
		for (size_t i = 0; i < input_data.size(); ++i)
			data.push_back(&input_data[i]);
	}

	// Méret lekérdezése
	int size() const
	{
		return data.size();
	}

	// Indexelés referencia szerint
	T &at(size_t index) const
	{
		std::list<int> a;

		a.begin();

		if (index >= data.size())
			throw std::out_of_range("Index out of range");

		size_t counter = 0;
		typename std::list<T *>::const_iterator i = data.begin();

		while (counter != index)
		{
			++counter;
			++i;
		}

		return **i;
	}

	/* // Konstans indexelés referencia szerint
	const T &at(size_t index) const
	{
		if (index >= data.size())
			throw std::out_of_range("Index out of range");

		size_t counter = 0;
		std::list<T>::iterator i;

		for (i = data.begin(); counter != index; ++i)
			++counter;

		return i;
	} */

	// Operátor [] referencia szerint
	T &operator[](size_t index)
	{
		return at(index);
	}

	// Konstans operátor [] referencia szerint
	const T &operator[](size_t index) const
	{

		return at(index);
	}

	// Iterátorok
	typename std::list<T *>::iterator begin()
	{
		return data.begin();
	}

	typename std::list<T *>::iterator end()
	{
		return data.end();
	}
};

#endif // ARRAPP_H