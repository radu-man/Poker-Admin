using System;

namespace PokerAdmin.Models
{
	public class Sesiune
	{
		public int Id { get; set; }
		public int? OrasId { get; set; }
		public int? ClubId { get; set; }
		public int? JocId { get; set; }

        public int JucatorId { get; set; }
        public Jucator Jucator { get; set; }

        public Sesiune()
		{
		}
	}
}

