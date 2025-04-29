#ifndef ARERASE__H
#define ARERASE__H

#include <list>
#include <iostream>

template <typename T>
class array_eraser
{
private:
	T *data;
	int length;

public:
	array_eraser(T *input_data, int input_length);

	void erase(T smt)
	{
		for (int i = 0; i < length; ++i)
		{
			if (data[i] == smt)
			{
				for (int j = i; j < length - 1; ++j)
					data[j] = data[j + 1];

				--length;
				--i;
			}
		}
	}

	int size() const
	{
		return length;
	}

	void erase_index(int index)
	{
		for (int i = index; i < length - 1; ++i)
			data[i] = data[i + 1];

		--length;
	}

	int count(T smt) const
	{
		int counter = 0;

		for (int i = 0; i < length; ++i)
		{
			if (data[i] == smt)
				++counter;
		}

		return counter;
	}

	void print() const
	{
		std::cout << "[ ";
		for (int j = 0; j < length; ++j)
			std::cout << data[j] << " ";
		std::cout << "]" << std::endl;
	}
};

template <typename T>
array_eraser<T>::array_eraser(T *input_data, int input_length)
{
	data = input_data;
	length = input_length;
}

#endif