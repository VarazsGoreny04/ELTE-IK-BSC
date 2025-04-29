#include <string>
#include <map>
#include <iostream>
#include <algorithm>

class Checker
{
public:
	static void check()
	{
		std::string line;
		std::getline(std::cin, line);

		std::cout << (evaluate(&line) ? "Valid" : "Invalid") << std::endl;
	}

private:
	static bool evaluate(std::string *string)
	{
		std::map<char, int> countOfChar;
		std::map<int, int> countOfCount;

		for (int i = 0; i < string->length(); ++i)
			++countOfChar[(*string)[i]];

		for (std::map<char, int>::iterator it = countOfChar.begin(); it != countOfChar.end(); ++it)
			++countOfCount[it->second];

		if (countOfCount.size() == 1)
			return true;
		else
		{
			int i1f = countOfCount.begin()->first;
			int i1s = countOfCount.begin()->second;
			int i2f = (++(countOfCount.begin()))->first;
			int i2s = (++(countOfCount.begin()))->second;

			return countOfCount.size() == 2 && 
					   ((i1f == 1 && i1s == 1) || (i2f == 1 && i2s == 1) || 
						(i1f== i2f + 1 && i1s == 1) || (i2f== i1f + 1 && i2s == 1));
		}
	}
};