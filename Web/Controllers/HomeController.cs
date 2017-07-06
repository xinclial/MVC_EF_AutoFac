using CTMMIS.IBLL.IService;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.App_Start;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        //1.从容器中拿
        private IService_T_Case_Main StaffService = AutoFacConfig.Resolve<IService_T_Case_Main>();

        //2.构造函数注入
        //IService_T_Case_Main service;
        //public HomeController(IService_T_Case_Main service)
        //{
        //    this.service = service;
        //}

        public ActionResult Index()
        {
            //Array s = new int[]{ 1, 2, 3, 4, 5 };
            //ArrayList

            var list = StaffService.GetModels(a => a.UserName.Equals("艾静")).Take(10).ToList();

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