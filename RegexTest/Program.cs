using System;
using System.Text.RegularExpressions;
using System.Threading;

namespace RegexTest
{
	class Program
	{
		static void Main(string[] args)
		{
			string chars = "abcdefghijklmnopqrstuvwxyz";

			for (var i = 0; ; i++)
			{
				var regex = string.Concat(chars[i % chars.Length], chars[2 * i % chars.Length], chars[3 * i % chars.Length]);

				// Use different constructors of the Regex type.
				var re = new Regex(regex + "1");
				var re2 = new Regex(regex + "2", RegexOptions.Compiled);
				var re3 = new Regex(regex + "3", RegexOptions.Compiled, TimeSpan.FromDays(1));

				Thread.Sleep(1000);

				Console.WriteLine(i);

				// Use constructed regexes.
				GC.KeepAlive(re);
				GC.KeepAlive(re2);
				GC.KeepAlive(re3);
			}
		}
	}
}
