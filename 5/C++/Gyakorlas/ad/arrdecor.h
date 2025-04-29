#ifndef ARRDECOR__H
#define ARRDECOR__H

#include <vector>
#include <algorithm>

template <typename TIteratable, typename TVariable>
class array_decorator
{
private:
    TIteratable v;

public:
    array_decorator(TVariable *array, unsigned long l);

    const array_decorator &sort()
    {
        std::sort(v.begin(), v.end());
        return *this;
    }
    /* const array_decorator<TIteratable, TVariable> &sort() const
    {
        std::sort(v.begin(), v.end());
        return *this;
    } */

    const array_decorator &reverse()
    {
        std::reverse(v.begin(), v.end());
        return *this;
    }
    /* const array_decorator<TIteratable, TVariable> &reverse() const
    {
        std::reverse(v.begin(), v.end());
        return *this;
    } */

    TIteratable get() const
    {
        return v;
    }
};

template <typename TIteratable, typename TVariable>
array_decorator<TIteratable, TVariable>::array_decorator(TVariable *array, unsigned long l)
{
    for (unsigned long i = 0; i < l; ++i)
        v.push_back(array[i]);
}

#endif