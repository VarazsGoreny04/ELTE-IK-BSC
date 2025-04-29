#include <list>
#include <numeric>
#include <iostream>
#include <deque>
#include "listview.h"
#include <vector>
#include <string>
#include "listview.h"

class test_vector : public std::vector<std::list<int>::iterator>
{

  static int cnt;

public:
  test_vector() {}

  template <class Iterator>
  test_vector(Iterator first, Iterator last) : std::vector<std::list<int>::iterator>(first, last)
  {
  }

  static void reset()
  {
    cnt = 0;
  }

  static int called()
  {
    return cnt;
  }

  std::list<int>::iterator &operator[](int idx)
  {
    ++cnt;
    return std::vector<std::list<int>::iterator>::operator[](idx);
  }

  const std::list<int>::iterator &operator[](int idx) const
  {
    ++cnt;
    return std::vector<std::list<int>::iterator>::operator[](idx);
  }

  std::list<int>::iterator &at(int idx)
  {
    ++cnt;
    return std::vector<std::list<int>::iterator>::at(idx);
  }

  const std::list<int>::iterator &at(int idx) const
  {
    ++cnt;
    return std::vector<std::list<int>::iterator>::at(idx);
  }
};

int test_vector::cnt = 0;

const int max = 1024;

int main()
{
  int your_mark = 1;
  // 2-es
  std::list<int> a;
  a.push_back(4);
  a.push_back(1);
  a.push_back(7);
  a.push_back(5);

  std::list<std::string> b;
  b.push_back("C++");
  b.push_back("C");
  b.push_back("Cobol");

  std::list<int> c;
  c.push_back(3);
  c.push_back(8);
  c.push_back(9);

  const array_view<int, std::vector<std::list<int>::iterator> > av(a);
  array_view<std::string, std::vector<std::list<std::string>::iterator> > bv(b);

  array_view<int, test_vector> cv(c);
  /*
    std::cout << "1. - " << (cv.at(1)) << std::endl;
    std::cout << "2. - " << (cv.at(2)) << std::endl;
    std::cout << "3. - " << (test_vector::called()) << std::endl;
    std::cout << "4. - " << (bv.at(0)) << std::endl;
    std::cout << "5. - " << (&(c.front())) << std::endl;
    std::cout << "6. - " << (&(cv.at(0))) << std::endl;
    std::cout << std::endl; */
  test_vector::reset();

  if (8 == cv.at(1) &&
      9 == cv.at(2) &&
      2 == test_vector::called() &&
      "C++" == bv.at(0) &&
      &(c.front()) == &(cv.at(0)))
  {
    your_mark = av.at(2) - av.at(1) - av.at(0);
  }

  // 3-as
  std::list<int> d;
  for( int i = 0; i < max; ++i )
  {
    d.push_back( i );
  }
  array_view<int, std::deque<std::list<int>::iterator> > dv( d );
  ++dv[ 0 ];
  dv[ 1 ] = 2;
  cv[ 1 ] = 3;

  if( "C" == bv[ 1 ] && dv[ 2 ] == dv.at( 1 ) && 1 == d.front() )
  {
    your_mark = cv[ 1 ];
  }
  
  // 4-es
  std::list<int> n;
  vector_view<int, test_vector> nv( n );
  for( int i = 0; i < max; ++i )
  {
    nv.push_back( i );
  }

  array_view<int, test_vector>* p = &nv;
  p = 0;
  delete p;

  /* std::cout << "1. - " << (n.size()) << std::endl;
  std::cout << "2. - " << (max / 2) << std::endl;
  std::cout << "3. - " << (nv[ max / 2 ]) << std::endl;
  std::cout << "3. - " << (nv[0]) << std::endl;
  std::cout << "3. - " << (nv[1]) << std::endl;
  std::cout << "3. - " << (nv[2]) << std::endl;
  std::cout << "4. - " << (max - 1) << std::endl;
  std::cout << "5. - " << (n.back()) << std::endl;
  std::cout << "6. - " << (max * ( max - 1 ) / 2) << std::endl;
  std::cout << "6. - " << (std::accumulate( n.begin(), n.end(), 0 )) << std::endl; */
  std::cout << std::endl;

  test_vector::reset();

  if( max == n.size() && 
      max / 2 == nv[ max / 2 ] && 
      max - 1 == n.back() &&
      max * ( max - 1 ) / 2 == std::accumulate( n.begin(), n.end(), 0 ) )
  {
    your_mark = test_vector::called() + b.size();
  }
  
  // 5-os
  /* n.clear();
  vector_view<int> nvv( n );
  nvv.push_back( 7 );
  nvv.push_back( 5 );
  nvv.push_back( 8 );
  nvv.sort();

  vector_view<int> avv( a );
  avv.sort( std::greater<int>() );

  if ( 3 == n.size() && 7 == n.front() && 5 == avv[ 1 ] )
  {
    your_mark = nvv[ 0 ];
  } */
  
  std::cout << "Your mark is " << your_mark << std::endl;
}