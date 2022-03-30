using System;

namespace WebApp.Models
{
	public class MeterReading
	{
		public int MeterSerialNumber { get; set; }
		public int Value { get; set; }
		public DateTime CheckDate { get; set; }
	}
}
