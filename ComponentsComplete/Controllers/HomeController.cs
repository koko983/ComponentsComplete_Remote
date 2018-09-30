using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ComponentsComplete.Models;

namespace ComponentsComplete.Controllers
{
	public class HomeController : Controller
	{
		Lazy<string> _lazyBoy = new Lazy<string>(() => "initial value");
		public string LazyBoy { get {
				return _lazyBoy.Value;
			} }

		public ActionResult Index()
		{
			//Extensions.Test2();
			ViewBag.MrLazy = LazyBoy;
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}