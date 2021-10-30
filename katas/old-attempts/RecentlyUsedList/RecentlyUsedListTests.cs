using System.Linq;
using Xunit;

namespace RecentlyUsedListTest
{
    public class RecentlyUsedListTests
    {
        [Fact]
        public void constructor_initializes_instance_of_class()
        {
            var sut = new RecentlyUsedList();

            Assert.NotNull(sut);
        }

        [Fact]
        public void initial_list_is_empty()
        {
            var sut = new RecentlyUsedList();

            Assert.Empty(sut.stack);
        }

        [Fact]
        public void most_recently_added_item_is_first()
        {
            var sut = new RecentlyUsedList();
            string first = "first";

            sut.stack.Push(first);

            Assert.Equal(first, sut.stack.Peek());
        }

        [Fact]
        public void most_recently_added_item_is_first_with_two_items()
        {
            var sut = new RecentlyUsedList();
            string first = "first";
            string second = "second";

            sut.stack.Push(first);
            sut.stack.Push(second);

            Assert.Equal(second, sut.stack.Peek());
        }

        [Fact]
        public void least_recently_added_item_is_last()
        {
            var sut = new RecentlyUsedList();
            string first = "first";
            string second = "second";

            sut.stack.Push(first);
            sut.stack.Push(second);
            var array = sut.stack.ToArray();
            string actual = array[1];

            Assert.Equal(first, actual);
        }

        [Fact]
        public void item_can_be_looked_up_by_index()
        {
            var sut = new RecentlyUsedList();
            string first = "first";

            sut.stack.Push(first);
            var actual = sut.stringLookup(0);

            Assert.Equal(first, actual);
        }

        [Fact]
        public void items_can_be_looked_up_by_index()
        {
            var sut = new RecentlyUsedList();
            string first = "first";
            string second = "second";
            string third = "third";


            sut.stack.Push(first);
            sut.stack.Push(second);
            sut.stack.Push(third);

            var actual = sut.stringLookup(0);

            Assert.Equal(third, actual);
        }

        [Fact]
        public void test_add_function()
        {
            var sut = new RecentlyUsedList();
            string first = "first";

            sut.add(first);

            Assert.Single(sut.stack);
        }

        [Fact]
        public void items_in_the_list_are_unique_when_contents_are_unique()
        {
            var sut = new RecentlyUsedList();
            string first = "first";
            string second = "second";

            sut.add(first);
            sut.add(second);
            var actual = sut.stack.Select(s => s).Distinct().Count();

            Assert.Equal(sut.stack.Count(), actual);
        }

        [Fact]
        public void items_in_the_list_are_unique_when_we_try_to_add_duplicates()
        {
            var sut = new RecentlyUsedList();
            string first = "first";
            string second = "second";

            sut.add(first);
            sut.add(second);
            sut.add(first);
            var actual = sut.stack.Select(s => s).Distinct().Count();

            Assert.Equal(sut.stack.Count(), actual);
        }

        [Fact]
        public void duplicate_item_is_moved_to_Top()
        {
            var sut = new RecentlyUsedList();
            string first = "first";
            string second = "second";

            sut.add(first);
            sut.add(second);
            sut.add(first);
            var actualCount = sut.stack.Select(s => s).Distinct().Count();

            Assert.Equal(first, sut.stack.Peek());
            Assert.Equal(sut.stack.Count(), actualCount);
        }
    }
}
