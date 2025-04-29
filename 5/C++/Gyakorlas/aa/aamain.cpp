#include <string>
#include <iostream>
#include <algorithm>
#include <vector>
#include "arrapp.h"

int main()
{
  int max = 1000;
  int your_mark = 1;

  // 2-es
  int s[] = {3, 2};
  array_appender<int> ia(s, sizeof(s) / sizeof(s[0]));
  for (int i = 0; i < max - 1; ++i)
  {
    ia.append(s, sizeof(s) / sizeof(s[0]));
  }

  std::string hw[] = {"Hello", "World"};
  std::string langs[] = {"C++", "Ada", "Brainfuck"};
  std::string x[] = {"Goodbye", "Cruel", "World"};
  array_appender<std::string> sa(hw, sizeof(hw) / sizeof(hw[0]));
  sa.append(langs, sizeof(langs) / sizeof(langs[0]));
  sa.append(x, sizeof(x) / sizeof(x[0]));

  const array_appender<std::string> ha(hw, sizeof(hw) / sizeof(hw[0]));

  std::cout << (max * 2 == ia.size()) << std::endl;
  std::cout << (3 == ia.at(max)) << std::endl;
  std::cout << (2 == ia.at(3)) << std::endl;
  std::cout << (&(s[0]) == &(ia.at(max / 2))) << std::endl;
  std::cout << (2 == ha.size() && 8 == sa.size()) << std::endl;
  std::cout << ("C++" == sa.at(2)) << std::endl;
  std::cout << (7 == sa.at(5).length()) << std::endl;
  std::cout << (&(ha.at(0)) == hw) << std::endl;

  if (max * 2 == ia.size() &&
      3 == ia.at(max) &&
      2 == ia.at(3) &&
      &(s[0]) == &(ia.at(max / 2)) &&
      2 == ha.size() && 8 == sa.size() &&
      "C++" == sa.at(2) &&
      7 == sa.at(5).length() &&
      &(ha.at(0)) == hw)
  {
    your_mark = ia.at(max + 1);
  }
  std::cout << "2: " << your_mark << std::endl;

  // 3-as
  sa[0] = "Hallo";
  ++ia[1];

  std::cout << ('a' == hw[0][1]) << std::endl;
  std::cout << ("Ada" == sa[3]) << std::endl;
  std::cout << ("World" == ha[1]) << std::endl;

  if ('a' == hw[0][1] &&
      "Ada" == sa[3] &&
      "World" == ha[1])
  {
    your_mark = ia[max - 1];
  }
  std::cout << "3: " << your_mark << std::endl;

  // 4-es
  std::vector<int> vi;
  vi.push_back(1);
  ia.append(vi);
  ia[2 * max] = 4;

  std::vector<std::string> vs;
  vs.push_back("Some");
  vs.push_back("Text");

  sa.append(vs);
  sa.append(vs);

  std::cout << (1 + 2 * max == ia.size()) << std::endl;
  std::cout << (12 == sa.size()) << std::endl;
  std::cout << ("Some" == sa[10]) << std::endl;

  if (1 + 2 * max == ia.size() &&
      12 == sa.size() &&
      "Some" == sa[10])
  {
    your_mark = vi[0];
  }
  std::cout << "4: " << your_mark << std::endl;

  // 5-os
  /*
  array_appender<std::string>::iterator i = std::find(sa.begin(), sa.end(), "Hallo");

  std::cout << (1 == std::count(ia.begin(), ia.end(), 4)) << std::endl;
  std::cout << (i == sa.begin()) << std::endl;

  if (1 == std::count(ia.begin(), ia.end(), 4) &&
      i == sa.begin())
  {
    your_mark += std::count(sa.begin(), sa.end(), "C++");
  }
  std::cout << "5: " << your_mark << std::endl;

  std::cout << "Your mark is " << your_mark;
  std::endl(std::cout);
  */
}