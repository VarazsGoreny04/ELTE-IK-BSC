#include <vector>

using namespace std;

template <typename T>
class array_appender
{
private:
	vector<T *> data;

public:
	array_appender(T *input_data, unsigned long length);
	~array_appender();

	void append(T *input_data, int length)
	{
		for (int i = 0; i < length; ++i)
		{
			data.push_back(input_data + i);
		}
	}

	int size() const
	{
		return data.size();
	}

	T &at(int index) const
	{
		return *(data.at(index));
	}
};

template <typename T>
array_appender<T>::array_appender(T *input_data, unsigned long length)
{
	append(input_data, length);
}

template <typename T>
array_appender<T>::~array_appender()
{
	for (int i = 0; i < static_cast<int>(data.size()); ++i)
	{
		delete data[i];
	}
}