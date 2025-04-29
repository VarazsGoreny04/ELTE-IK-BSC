#ifndef ARRACCVIEW_H
#define ARRACCVIEW_H

#include <vector>

template <typename T, typename Op = std::plus<T>>
class array_accumulate_view
{
private:
	std::vector<T *> data;

public:
	array_accumulate_view(T *input_data);
	array_accumulate_view(T *input_data, unsigned long length);
	T operator[](int index);
	const T &operator[](int index) const;
	void operator+=(T *input_data);

	int size() const
	{
		return data.size();
	}

	T at(size_t index) const
	{
		Op op;
		T result = *data[0];

		for (size_t i = 1; i < data.size() && i <= index; ++i)
			result = op.operator()(result, *data[i]);

		return result;
	}

	void add(T *input_data)
	{
		while (input_data)
			data.push_back(input_data++);
	}

	void add(T *input_data, int length)
	{
		for (int i = 0; i < length; ++i)
			data.push_back(input_data++);
	}
};

template <typename T, typename Op>
array_accumulate_view<T, Op>::array_accumulate_view(T *input_data)
{
	add(input_data);
}

template <typename T, typename Op>
array_accumulate_view<T, Op>::array_accumulate_view(T *input_data, unsigned long length)
{
	add(input_data, length);
}

template <typename T, typename Op>
T array_accumulate_view<T, Op>::operator[](int index)
{
	return at(index);
}

template <typename T, typename Op>
const T &array_accumulate_view<T, Op>::operator[](int index) const
{
	return *data[index];
}

template <typename T, typename Op>
void array_accumulate_view<T, Op>::operator+=(T *input_data)
{
	while (input_data)
		data.push_back(input_data++);
}

#endif // ARRACCVIEW_H