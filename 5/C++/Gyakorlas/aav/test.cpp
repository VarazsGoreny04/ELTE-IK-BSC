#include <iostream>
#include <vector>
#include <list>

template <typename T>
class Alma
{
private:
    std::vector<T> x;

public:
    Alma();

    T &set(int ind)
    {
        return x.at(ind);
    }

    void add(T input_data)
    {
        x.push_back(input_data);
    }
};

template <typename T>
Alma<T>::Alma() {}

int main()
{
    std::vector<int> x;

    // std::vector<int> x = {10, 6, 21};

    x.push_back(10);
    x.push_back(6);
    x.push_back(21);

    Alma<int> a;

    a.add(10);
    a.add(6);
    a.add(21);

    // Value of x is now changed to 20
    a.set(1) = 20;
    for (int xi : x)
        std::cout << "xi = " << xi << std::endl;

    // Value of x is now changed to 30
    // x[1] = 30;
    // std::cout << "ref = " << ref << std::endl;

    return 0;
}
