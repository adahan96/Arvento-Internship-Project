using dapperdeneme1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace dapperdeneme1.Controllers
{
    [RoutePrefix("api")]
    public class ReportRightController : ApiController
    {
        // GET api/values
        // public IEnumerable<string> Get()
        //{
        //   return new string[] { "value1", "value2" };
        // }

        // GET api/values/5
        // [HttpGet]
        // [Route("get")]
        

        [HttpGet]
        [Route("GetReportRightResults")]
        public List<ReportRightResult> Get()
        {
            ReportRight rr = new ReportRight();
            List<ReportRightResult> result = rr.GetReportRights();
            return result;

        }
        [HttpGet]
        [Route("GetReportRightResult")]
        public ReportRightResult Get(int ReportRightID)
        {
            ReportRight rr = new ReportRight();
            ReportRightResult result = rr.GetReportRight(ReportRightID);
            return result;

        }
        
    }
}