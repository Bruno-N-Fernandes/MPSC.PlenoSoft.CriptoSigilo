using System;
using System.Collections.Generic;
using System.Linq;

namespace CriptoSigilo.Models
{
	public class Filtro
	{
		public Char Key { get; }
		public Char Value { get; }

		public Filtro(char key, char value)
		{
			Key = key;
			Value = value;
		}

		public static IEnumerable<Filtro> Gerar(String key1, String key2)
		{
			var v1 = gerar(key1.ToUpper(), key2.ToUpper());
			var v2 = gerar(key1.ToLower(), key2.ToLower());
			var v3 = gerar(key2.ToUpper(), key1.ToUpper());
			var v4 = gerar(key2.ToLower(), key1.ToLower());
			return v1.Union(v2).Union(v3).Union(v4).ToArray();
		}

		private static IEnumerable<Filtro> gerar(String key1, String key2)
		{
			return key1.Select((c, i) => new Filtro(c, key2[i]));
		}
	}

}