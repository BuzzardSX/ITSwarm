using System;

namespace WebApp.Models
{
	public class Meter
	{
		public int SerialNumber { get; set; }
		public DateTime LastCheckDate { get; set; }
		public DateTime NextCheckDate { get; set; }
	}
}
