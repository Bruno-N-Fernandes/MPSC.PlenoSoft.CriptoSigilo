using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CriptoSigilo.Models
{
	public enum Operacao
	{
		Decriptar = 1,
		Encriptar = 2,
	}

	public class MensagemSigilosa
	{
		private static IEnumerable<Operacao> SourceOperacoes
		{
			get { yield return Operacao.Decriptar; yield return Operacao.Encriptar; }
		}

		public IEnumerable<SelectListItem> Operacoes =>
			SourceOperacoes.Select(o => new SelectListItem(o.ToString(), Convert.ToInt32(o).ToString(), o == Operacao));


		public String Key1 { get; set; }
		public String Key2 { get; set; }

		public Operacao Operacao { get; set; }

		public String Mensagem1 { get; set; }
		public String Mensagem2 { get; set; }

		public void Processar()
		{
			if (Operacao == Operacao.Encriptar)
				Mensagem2 = Criptografia.Encriptar(Mensagem1, Key1, Key2);
			else
				Mensagem2 = Criptografia.Decriptar(Mensagem1, Key1, Key2);
		}
	}
}
