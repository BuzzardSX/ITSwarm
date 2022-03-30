using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;
using WebApp.RequestModels.HomeRequestModels;
using WebApp.ViewModels.HomeViewModels;

namespace WebApp.Controllers
{
	public class HomeController : Controller
	{
		readonly ApplicationContext _app;
		public HomeController(ApplicationContext app) => _app = app;
		public IActionResult Index([FromQuery] string address = "")
		{
			var residences = (
				from r in _app.Residences
				join r0 in (
					from n in _app.MeterReadings.Select(r => r.MeterSerialNumber).Distinct()
					from r in _app.MeterReadings.Where(r => r.MeterSerialNumber == n).OrderByDescending(r => r.CheckDate).Take(1)
					select new
					{
						r.MeterSerialNumber,
						r.Value,
						r.CheckDate
					}
				)
					on r.MeterSerialNumber equals r0.MeterSerialNumber
				select new
				{
					r.Address,
					r0.Value,
					r0.CheckDate
				}
			);

			var residenceForm = new IndexResidenceFormViewModel();

			var residence = _app.Residences.Find(address);

			if (residence != null)
			{
				var addressParts = residence.Address.Split('/');

				residenceForm.StreetName = addressParts[0];
				residenceForm.StreetNumber = addressParts[1];
				residenceForm.DoorNumber = addressParts[2];
			}

			var model = new IndexViewModel();

			model.Residences = residences.ToList()
				.Select(r =>
				{
					var addressParts = r.Address.Split('/');

					return new IndexResidenceViewModel
					{
						Address = r.Address,
						StreetName = addressParts[0],
						StreetNumber = addressParts[1],
						DoorNumber = addressParts[2],
						LastReading = r.Value,
						LastCheckDate = r.CheckDate
					};
				});

			model.ResidenceForm = residenceForm;

			return View(model);
		}
		[HttpPost]
		public IActionResult Index(string streetName, string streetNumber)
		{
			Console.WriteLine(streetName == null);
			// var address = string.Join('/', request.StreetName, request.StreetNumber, request.DoorNumber);

			// var residence = _app.Residences.Find(address);

			// if (residence != null)
			// {
			// 	residence.Address = address;
			// 	_app.Residences.Update(residence);
			// }
			// else
			// {
			// 	residence = new Residence
			// 	{
			// 		Address = address
			// 	};
			// 	_app.Residences.Add(residence);
			// }
			// _app.SaveChanges();
			// return Index();
			return Ok();
		}
		[NonAction]
		public IQueryable<int> IndexIdleMetersQueryable() => (
			from r in _app.MeterReadings
			join r0 in _app.Residences
				on r.MeterSerialNumber equals r0.MeterSerialNumber into rs
			from r0 in rs.DefaultIfEmpty()
			where r0 == null
			select r.MeterSerialNumber
		);
	}
}
