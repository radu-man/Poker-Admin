using System;
namespace PokerAdmin.Models
{
	public class Club
	{
		public int Id { get; set; }
		public string Nume { get; set; }

		public int? LocatieId { get; set; }
		public Oras? Oras { get; set; }

		public Club()
		{
		}
	}
}

