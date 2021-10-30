using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecentlyUsedListTest
{
    public class RecentlyUsedList
    {
        public Stack<string> stack { get; set; }

        public RecentlyUsedList() => stack = new Stack<string>();

        public string stringLookup(int index)
        {
            return stack.ToArray()[index];
        }

        public void add(string item)
        {
            if (!string.IsNullOrEmpty(item))
            {
                if (!stack.Contains(item))
                {
                    stack.Push(item);
                }
                else
                {
                    var list = stack.ToList();
                    list.Remove(item);
                    stack.Clear();
                    foreach (var l in list)
                    {
                        stack.Push(l);
                    }
                    stack.Push(item);
                }
            }
        }
    }
}