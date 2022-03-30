using System.Collections.Generic;
using WebApp.Models;

namespace WebApp.ViewModels.HomeViewModels
{
	public class IndexViewModel
	{
		public IEnumerable<Meter> Meters { get; set; }
		public IEnumerable<IndexResidenceViewModel> Residences { get; set; }
		public IndexResidenceFormViewModel ResidenceForm { get; set; }
	}
}
