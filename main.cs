using System;
using System.Collections.Generic;

class Program
{
    static void print(dynamic message)
    {
        try
        {
            for (int i = 0; i < message.Count; i++)
            {
                Console.WriteLine($"List [{i}] = {message[i]}");
            }
        }
        catch
        {
            Console.WriteLine(message.ToString());
        }
    }

    static int sortedIndex(dynamic items, dynamic item)
    {
        int start = 0;
        int end = items.Count;
        int mid = (start + end) / 2;
        int i = 0;
        double depth = Math.Log(items.Count + 1, 2);
        while (i <= Math.Ceiling(depth))
        {
            mid = (start + end) / 2;
            if (start >= end)
            {
                break;
            }
            if (item == items[mid])
            {
                return mid;
            }
            else if (item > items[mid])
            {
                start = mid + 1;
            }
            else if (item < items[mid])
            {
                end = mid;
            }
        }
        return mid;
    }

    static dynamic sortedInsert(dynamic items, dynamic item)
    {
        items.Insert(sortedIndex(items, item), item);
        return items;
    }

    public static void Main(string[] args)
    {
        var items = new List<int>() { 0, 2, 4 };
        print(sortedIndex(items, 1));
        sortedInsert(items, 1);
    }
}