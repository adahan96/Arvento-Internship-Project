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
    public class ValuesController : ApiController
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
        [Route("GetUserReportRightResult")]
        public List<UserReportRightResult> Get(string userName)
        {
            UserReportRight urr = new UserReportRight();
            List<UserReportRightResult> result = urr.GetUserReportRight(userName);
            return result;
     
        }

        [HttpGet]
        [Route("GetUserReportRightResults")]
        public List<UserReportRightResult> Get()
        {
            UserReportRight urr = new UserReportRight();
            List<UserReportRightResult> result = urr.GetUserReportRight();
            return result;

        }


        // POST api/values
        
        [HttpPost]
        [Route("insertUserRight")]
        public void Post(UserReportRightResult result)
        {

            UserReportRight urr = new UserReportRight();
            urr.InsertUserReportRight(result.UserName, result.ReportRightID, result.CreatedBy);
            
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
