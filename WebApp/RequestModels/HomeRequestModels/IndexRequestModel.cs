using Microsoft.AspNetCore.Mvc;

namespace WebApp.RequestModels.HomeRequestModels;

public class IndexRequestModel
{
	public string StreetName { get; set; }
	public string StreetNumber { get; set; }
	public string DoorNumber { get; set; }
}
