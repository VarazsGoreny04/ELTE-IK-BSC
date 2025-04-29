#include <vector>
#include <stdexcept>

template <typename T>
class array_accumulate_view
{
private:
	std::vector<T *> data;

public:
	array_accumulate_view(T *input_data, unsigned long length);
	const T &operator[](int index) const;
	T operator[](int index);

	int size() const
	{
		return data.size();
	}

	T at(size_t index) const
	{
		T result = *data[0];

		for (size_t i = 1; i < data.size() && i <= index; ++i)
			result += *data[i];

		return result;
	}

	void add(T *input_data, int length)
	{
		for (int i = 0; i < length; ++i)
			data.push_back(input_data++);
	}
};

template <typename T>
array_accumulate_view<T>::array_accumulate_view(T *input_data, unsigned long length)
{
	add(input_data, length);
}

template <typename T>
const T &array_accumulate_view<T>::operator[](int index) const
{
	return *data[index];
}

template <typename T>
T array_accumulate_view<T>::operator[](int index)
{
	return at(index);
}