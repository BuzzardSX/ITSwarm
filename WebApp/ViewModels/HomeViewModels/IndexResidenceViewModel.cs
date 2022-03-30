using System;

namespace WebApp.ViewModels.HomeViewModels;

public class IndexResidenceViewModel
{
	public string Address { get; init; }
	public string StreetName { get; init; }
	public string StreetNumber { get; init; }
	public string DoorNumber { get; init; }
	public int LastReading { get; init; }
	public DateTime LastCheckDate { get; init; }
}
