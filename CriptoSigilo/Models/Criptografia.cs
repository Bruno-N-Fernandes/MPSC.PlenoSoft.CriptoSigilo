using System;
using System.Collections.Generic;
using System.Linq;

namespace CriptoSigilo.Models
{
	public class Criptografia
	{
		public static String Encriptar(String texto, String key1, String key2)
		{
			var filtros = Filtro.Gerar(key1, key2);
			var textoBase64 = texto.ToBase64();
			var textoCriptografado = Encode(textoBase64, filtros);
			return textoCriptografado.ToBase64();
		}

		public static String Decriptar(String texto, String key1, String key2)
		{
			var filtros = Filtro.Gerar(key1, key2);
			var textoBase64 = texto.FromBase64();
			var textoCriptografado = Encode(textoBase64, filtros);
			return textoCriptografado.FromBase64();
		}


		private static String Encode(String textoBase64, IEnumerable<Filtro> filtros)
		{
			var retorno = String.Empty;
			foreach (var c in textoBase64)
				retorno += filtros.FirstOrDefault(f => f.Key == c)?.Value ?? c;
			return retorno;
		}
	}
}