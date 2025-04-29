#ifndef VECTOR__H
#define VECTOR__H

template <class T>
class Vector
{
	int cap, s;
	T *p;

public:
	typedef T *iterator;

	Vector(int);
	~Vector();
	Vector(const Vector<T> &);
	Vector<T> &operator=(const Vector<T> &);

	int size() const
	{
		return s;
	}

	void push_back(const T &);

	const T &operator[](int idx) const;
	T &operator[](int idx);

	iterator begin()
	{
		return p;
	}

	iterator end()
	{
		return p + s;
	}
};

template <class T>
Vector<T>::Vector(int c)
{
	cap = c;
	s = 0;
	p = new T[cap];
}

template <class T>
Vector<T>::~Vector()
{
	delete[] p;
}

template <class T>
Vector<T>::Vector(const Vector<T> &rhs)
{
	cap = rhs.cap;
	s = rhs.s;
	p = new T[cap];
	for (int i = 0; i < rhs.size(); ++i)
	{
		p[i] = rhs[i];
	}
}

template <class T>
Vector<T> &Vector<T>::operator=(const Vector<T> &rhs)
{
	if (this != &rhs)
	{
		delete[] p;
		cap = rhs.cap;
		s = rhs.size();
		p = new T[cap];
		for (int i = 0; i < rhs.size(); ++i)
		{
			p[i] = rhs[i];
		}
	}
	return *this;
}

template <class T>
void Vector<T>::push_back(const T &t)
{
	if (cap == s)
	{
		cap *= 2;
		T *q = new T[cap];
		for (int i = 0; i < s; ++i)
		{
			q[i] = p[i];
		}
		delete[] p;
		p = q;
	}
	p[s++] = t;
}

template <class T>
const T &Vector<T>::operator[](int idx) const
{
	return p[idx];
}

template <class T>
T &Vector<T>::operator[](int idx)
{
	return p[idx];
}

#endif