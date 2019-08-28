#pragma once
#include <string>
#include <vector>

namespace Kata
{
	class RecentlyUsedList
	{
	public:
		RecentlyUsedList();
		void Add(std::string item);
		std::string At(int i);
		int Count();
	private:
		std::vector<std::string> contents;
		int numContents;
	};
}

