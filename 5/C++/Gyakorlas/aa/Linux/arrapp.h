#ifndef ARRAPP_H
#define ARRAPP_H

#include <vector>
#include <stdexcept>
#include <iterator>
#include <algorithm>

template <typename T>
class array_appender
{
private:
	std::vector<T> data; // A belső tároló

public:
	// Típusdefiniálás iterátorokhoz
	typedef typename std::vector<T>::iterator iterator;
    typedef typename std::vector<T>::const_iterator const_iterator;

	// Konstruktor: inicializálja az adattárolót egy tömbbel
	array_appender(const T *input_data, size_t length)
	{
		data.insert(data.end(), input_data, input_data + length);
	}

	// Elemek hozzáfűzése egy tömbből
	void append(const T *input_data, size_t length)
	{
		data.insert(data.end(), input_data, input_data + length);
	}

	// Elemek hozzáfűzése egy std::vector-ból
	void append(const std::vector<T> &input_data)
	{
		data.insert(data.end(), input_data.begin(), input_data.end());
	}

	// Méret lekérdezése
	size_t size() const
	{
		return data.size();
	}

	// Indexelés referencia szerint
	T &at(size_t index)
	{
		if (index >= data.size())
		{
			throw std::out_of_range("Index out of range");
		}
		return data[index];
	}

	// Konstans indexelés referencia szerint
	const T &at(size_t index) const
	{
		if (index >= data.size())
		{
			throw std::out_of_range("Index out of range");
		}
		return data[index];
	}

	// Operátor [] referencia szerint
	T &operator[](size_t index)
	{
		return data[index];
	}

	// Konstans operátor [] referencia szerint
	const T &operator[](size_t index) const
	{
		return data[index];
	}

	// Iterátorok
	iterator begin()
	{
		return data.begin();
	}

	const_iterator begin() const
	{
		return data.begin();
	}

	iterator end()
	{
		return data.end();
	}

	const_iterator end() const
	{
		return data.end();
	}
};

#endif // ARRAPP_H