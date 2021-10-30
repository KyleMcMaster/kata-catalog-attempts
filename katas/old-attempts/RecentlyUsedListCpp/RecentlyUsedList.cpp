#include "pch.h"
#include "RecentlyUsedList.h"

namespace Kata
{
	RecentlyUsedList::RecentlyUsedList()
	{
		this->numContents = 0;
		this->contents = std::vector<std::string>();
	}

	int RecentlyUsedList::Count()
	{
		return numContents;
	}

	void RecentlyUsedList::Add(std::string item)
	{
		this->numContents++;
		this->contents.push_back(item);
	}

	std::string RecentlyUsedList::At(int i)
	{
		int end = this->contents.size() - 1;
		return this->contents.at(end - i);
	}
}