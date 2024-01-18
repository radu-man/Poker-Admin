using System;
using System.ComponentModel.DataAnnotations;

namespace PokerAdmin.Models
{
	public class Oras
	{
		public int Id { get; set; }
        public string Nume { get; set; }

        public ICollection<Club>? Cluburi { get; set; }

        public Oras()
		{
		}
	}
}

