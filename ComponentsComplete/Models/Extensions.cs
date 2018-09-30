using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComponentsComplete.Models
{
	class Person
	{
		readonly int _age;
		readonly string _name;

		public Person(int age, string name)
		{
			_age = age;
			_name = name;
		}

		internal string GetName()
		{
			return $" {_name}";
		}

		internal int GetAge()
		{
			return _age;
		}
	}

	static class Extensions
	{
		static Person[] people =
		{
			new Person (4, "Anas 7abeeby"),
			new Person (18, "Koko"),
			new Person(128, "Mr. Majestic")
		};

		public static TResult Aggregate<T, TResult>(
			this IEnumerable<T> sequence,
			TResult seed,
			Func<TResult, T, TResult> aggregator) where T : class
		{
			var result = seed;
			foreach (var item in sequence)
			{
				result = aggregator(result, item);
			}
			return result;
		}

		public static T WithMinumum<T, TKey>(this IEnumerable<T> sequence, Func<T, TKey> func)
			where T : class
			where TKey : IComparable
		{
			var result = sequence.First();
			var min = func(result);
			foreach (var item in sequence)
			{
				var key = func(item);
				if (key.CompareTo(min) < 0)
				{
					result = item;
					min = key;
				}
			}
			return result;
		}

		public static void Test1()
		{
			var koss = people.Aggregate(string.Empty,
				(result, person) =>
					result += person.GetName());

			var moss = Enumerable.Aggregate<Person, string>(people, null, (result, person) => result += person.GetName());

			var finalResult = koss == moss;
		}

		public static void Test2()
		{
			var anas = people.WithMinumum(person => person.GetAge());
			if(anas.GetAge() != 4)
			{
				throw new InvalidOperationException();
			}
		}
	}
}