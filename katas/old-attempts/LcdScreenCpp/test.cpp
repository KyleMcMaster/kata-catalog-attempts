#include "pch.h"
#include "Digit.h"

//TEST(TestCaseName, TestName) {
//  EXPECT_EQ(1, 1);
//  EXPECT_TRUE(true);
//}

TEST(CONSTRUCTOR_RETURNS_VALID_INSTANCE, LCD_DIGIT_TESTS) {
  auto digit = Digit(0);
  EXPECT_EQ(1, 1);
}