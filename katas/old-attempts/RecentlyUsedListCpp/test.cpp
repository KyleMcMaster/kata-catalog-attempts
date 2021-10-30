#include "pch.h"
#include "RecentlyUsedList.h"

namespace Tests 
{
	//TEST(TestCaseName, TestName) {
	//	EXPECT_EQ(1, 1);
	//	EXPECT_TRUE(true);
	//}

	TEST(INITIAL_LIST_IS_EMPTY, RECENTLY_USED_LIST_TESTS) {
		auto sut = Kata::RecentlyUsedList();
		EXPECT_EQ(sut.Count(), 0);
	}

	TEST(LIST_CAN_CONTAIN_ITEM, RECENTLY_USED_LIST_TESTS) {
		auto sut = Kata::RecentlyUsedList();
		std::string value = "first";
		sut.Add(value);

		EXPECT_EQ(sut.Count(), 1);
		EXPECT_EQ(sut.At(0), value);
	}

	TEST(LIST_CAN_CONTAIN_MORE_THAN_ONE_ITEM, RECENTLY_USED_LIST_TESTS) {
		auto sut = Kata::RecentlyUsedList();
		std::string first = "first";
		std::string second = "second";
		sut.Add(first);
		sut.Add(second);

		EXPECT_EQ(sut.Count(), 2);
		EXPECT_EQ(sut.At(0), second);
		EXPECT_EQ(sut.At(1), first);
	}

	TEST(MOST_RECENTLY_ADDED_ITEM_IS_FIRST_IN_LIST, RECENTLY_USED_LIST_TESTS) {
		auto sut = Kata::RecentlyUsedList();
		std::string value = "first";
		sut.Add(value);

		EXPECT_EQ(sut.Count(), 1);
		EXPECT_EQ(sut.At(0), value);
	}

	TEST(MOST_RECENTLY_ADDED_ITEM_IS_FIRST_IN_LIST_WITH_TWO_ITEMS, RECENTLY_USED_LIST_TESTS) {
		auto sut = Kata::RecentlyUsedList();
		std::string first = "first";
		std::string second = "second";
		sut.Add(first);
		sut.Add(second);

		EXPECT_EQ(sut.Count(), 2);
		EXPECT_EQ(sut.At(0), second);
	}
}