using BusinessContracts.Business.Contracts.Monitoring;
using BusinessDomain.Business.Domain.Models.Monitoring;
using Referentiels.Models.Monitoring;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Referentiels.Controllers
{
    public class MonitoringController : Controller
    {
        private readonly IQueryService _queryService;

        public MonitoringController(IQueryService queryService)
        {
            _queryService = queryService;


        }
        // GET: Monitoring
        public ActionResult Index()
        {
            MonitoringViewModel h = new MonitoringViewModel();
            h.QueryAvailable = _queryService.GetQueryAvailable();

            foreach (Query q in h.QueryAvailable)
            {
                _queryService.ExecuteQuery(q);
            }

            Response.AddHeader("Refresh", "300");
            ViewBag.DateRefresh = DateTime.Now.ToShortTimeString();
            return View(h);
        }

        public JsonResult GetResultQuery(string idQuery)
        {
            int i = 0;
            if (idQuery != null && int.TryParse(idQuery, out i))
            {
                Query q = _queryService.GetQueryAvailable().First(x => x.IdQuery.Equals(i));
                _queryService.ExecuteQuery(q);
                return Json(q.ResultQuery.GetResultQuery(), JsonRequestBehavior.AllowGet);
            }

            return Json("", JsonRequestBehavior.AllowGet);
        }
    }
}