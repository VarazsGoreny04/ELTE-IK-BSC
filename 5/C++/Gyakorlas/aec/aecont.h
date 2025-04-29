#ifndef AECONT__H
#define AECONT__H

#include <vector>
#include <iterator>
#include <list>
#include <set>
#include <iostream>

template <typename T>
class alternating_endpoint_container
{
private:
	std::vector<T> data;

	int index_calc(int index) const
	{
		int temp = (data.size() + 1) / 2;

		return (index < temp) ? (temp - index - 1) * 2 : (index - temp) * 2 + 1;
	}

public:
	typedef typename std::vector<T>::iterator iterator;
	typedef typename std::list<int>::iterator lIterator;
	typedef typename std::set<double>::iterator sIterator;

	alternating_endpoint_container();
	alternating_endpoint_container(lIterator a, lIterator b);
	alternating_endpoint_container(sIterator a, sIterator b);

	/* void insert(const T &smt)
	{
		if (data.size() % 2 == 0)
		{
			data.push_back(data[data.size() - 1]);

			for (int i = static_cast<int>(data.size()) - 2; i > 0; --i)
				data[i] = data[i - 1];

			data[0] = smt;
		}
		else
			data.push_back(smt);
	} */

	void insert(const T &smt)
	{
		data.push_back(smt);
	}

	void erase()
	{
		data.pop_back();
	}

	/* void erase()
	{
		if (data.size() == 0)
			return;

		std::vector<T> temp;
		iterator b = data.begin(), e = data.end();

		(data.size() % 2 == 0) ? --e : ++b;

		for (iterator i = b; i != e; ++i)
			temp.push_back(*i);
	} */

	int size() const
	{
		return data.size();
	}

	const T &at(int index) const
	{
		return data[index];
	}

	T &operator[](int index)
	{
		return data[index_calc(index)];
	}

	const T &operator[](int index) const
	{
		return data[index_calc(index)];
	}

	iterator begin()
	{
		return data.begin();
	}

	iterator end()
	{
		return data.end();
	}
};

template <typename T>
alternating_endpoint_container<T>::alternating_endpoint_container() {}

template <typename T>
alternating_endpoint_container<T>::alternating_endpoint_container(lIterator a, lIterator b)
{
	for (lIterator i = a; i != b; ++i)
	{
		std::cout << *i << std::endl;
		data.push_back(*i);
	}
}

template <typename T>
alternating_endpoint_container<T>::alternating_endpoint_container(sIterator a, sIterator b)
{
	for (sIterator i = a; i != b; ++i)
	{
		std::cout << *i << std::endl;
		data.push_back(*i);
	}
}

#endif