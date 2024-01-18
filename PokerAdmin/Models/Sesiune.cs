using System;
using System.ComponentModel.DataAnnotations;

namespace PokerAdmin.Models
{
	public class Sesiune
	{
		public int Id { get; set; }

        [Display(Name = "Oras")]
        public int? OrasId { get; set; }
		public Oras Oras { get; set; }

        [Display(Name = "Club")]
        public int? ClubId { get; set; }
		public Club Club { get; set; }

        [Display(Name = "Joc")]
        public int? JocId { get; set; }
		public Joc Joc { get; set; }

        [Required(ErrorMessage = "Please enter a result.")]
        [Display(Name = "Rezultat")]
        public int Rezultat { get; set; }

        [Display(Name = "Jucator")]
        public int JucatorId { get; set; }
        public Jucator Jucator { get; set; }

        public Sesiune()
		{
		}
	}
}

