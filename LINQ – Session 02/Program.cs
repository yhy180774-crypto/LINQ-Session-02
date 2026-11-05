namespace LINQ___Session_02 { 
    using System;
using System.Linq;
using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {


            // Question 1

            var q1 = products
                .OrderByDescending(p => p.UnitPrice)
                .Take(3);


            // Question 2

            var q2 = products
                .Skip(5)
                .Take(5);


            // Question 3

            var q3 = products
                .OrderBy(p => p.UnitPrice)
                .TakeWhile(p => p.UnitPrice < 25);


            // Question 4

            bool q4 = products
                .Where(p => p.Category.CategoryName == "Seafood")
                .All(p => p.UnitsInStock > 0);


            // Question 5

            int[] ids = { 3, 9, 13, 18 };

            bool q5 = ids.Contains(9);


            // Question 6

            var q6 = products
                .GroupBy(p => p.Category.CategoryName);

            foreach (var group in q6)
            {
                Console.WriteLine(group.Key + " : " + group.Count());
            }


            // Question 7

            var q7 = products
                .GroupBy(p => p.Category.CategoryName)
                .Select(g => new
                {
                    Category = g.Key,
                    ProductNames = g.Select(p => p.ProductName)
                });

            foreach (var group in q7)
            {
                Console.WriteLine(group.Category);

                foreach (var name in group.ProductNames)
                {
                    Console.WriteLine(name);
                }
            }


            // Question 8

            var q8 = products
                .GroupBy(p => p.Category.CategoryName)
                .Where(g => g.Count() > 3);


            // Question 9

            var q9 =
                from c in customers
                group c by c.Country into g
                select new
                {
                    Country = g.Key,
                    Count = g.Count(),
                    TotalOrderValue = g
                        .SelectMany(c => c.Orders)
                        .SelectMany(o => o.Order_Details)
                        .Sum(d => d.UnitPrice * d.Quantity * (1 - d.Discount))
                };


            // Question 10

            int q10 = products.Sum(p => p.UnitsInStock);


            // Question 11

            var cheapest = products.Min(p => p.UnitPrice);

            var expensive = products.Max(p => p.UnitPrice);


            // Question 12

            var q12 = products
                .Select(p => p.Category.CategoryName)
                .Distinct();


            // Question 13

            int[] setA = { 1, 3, 5, 7, 9, 11, 13 };

            int[] setB = { 3, 6, 9, 12, 15, 13 };

            var q13 = setA.Except(setB);


            // Question 14

            string[] list1 = { "Germany", "France", "UK", "Spain" };

            string[] list2 = { "france", "SPAIN", "Italy" };

            var q14 = list1.Except(
                list2,
                StringComparer.OrdinalIgnoreCase
            );


            // Question 15

            Dictionary<int, Product> q15 = products
                .ToDictionary(p => p.ProductID);

            var product = q15[18];

            Console.WriteLine(product.ProductName);


            // Question 16

            var q16 = products
                .First(p => p.UnitPrice > 50);


            // Question 17
           

            var q17 = products
                .FirstOrDefault(p => p.UnitPrice > 500);


            // Question 18

            var q18 = Enumerable.Range(1, 10)
                .Select(i => 7 * i);


            // Question 19

            var q19 = Enumerable.Range(1, 30)
                .Where(n => n % 2 == 0);


            // Question 20
            

            var q20 = products
                .Take(3)
                .Select(p => p.ProductName)
                .Concat(
                    customers
                        .Take(3)
                        .Select(c => c.CompanyName)
                );


            // Question 21
            

            var q21 = products.Zip(
                customers,
                (p, c) => p.ProductName + " sold to " + c.CompanyName
            );




        }
    }
}
