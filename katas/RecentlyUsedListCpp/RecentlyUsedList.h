#pragma once
#include <string>
#include <vector>

namespace Kata
{
	class RecentlyUsedList
	{
	public:
		RecentlyUsedList();
		int Count();
		void Add(std::string item);
		std::string At(int i);
	private:
		int numContents;
		std::vector<std::string> contents;
	};
}

