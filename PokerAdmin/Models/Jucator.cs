using System;
using System.Collections.Generic;
namespace PokerAdmin.Models
{
	public class Jucator
	{
		public int Id { get; set; }
		public string Nume { get; set; }
		public string Prenume { get; set; }
		public string? Porecla { get; set; }

        public string FullName => $"{Prenume} {Nume}";

        public ICollection<Sesiune> Sesiuni { get; set; } = new List<Sesiune>();

        public Jucator()
		{
		}
	}
}

