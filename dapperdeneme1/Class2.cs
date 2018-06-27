using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using Dapper;

namespace dapperdeneme1.Models
{
    public class ReportRightResult
    {
        public int Id { get; set; }
        public string ReportName { get; set; }
        public string CreatedBy { get; set; }
        public string ReportNameValue { get; set; }

    }
    public class ReportRight
    {
        //public ReportRightResult GetReportRight(string userName)
        //{
        //    string connectionString = "SERVER=(local);UID=sa;PWD=Arvento1;DATABASE=ArmakomComms;Pooling=false";
        //    using (IDbConnection cn = new SqlConnection(connectionString))
        //    {
        //        cn.Open();

        //        string strSql = "select ID, Username, ReportRightID from USERREPORTRIGHT WHERE USERNAME = @Username";

        //        //object parameters = new { Username = userName };
        //        Dictionary<string, object> parameters = new Dictionary<string, object>();
        //        parameters.Add("@Username", userName);

        //        UserReportRightResult result = cn.Query<UserReportRightResult>(strSql, parameters).FirstOrDefault();
        //        return result;
        //    }

        //}
        public List<ReportRightResult> GetReportRights()
        {
            string connectionString = "SERVER=(local);UID=sa;PWD=Arvento1;DATABASE=ArmakomComms;Pooling=false";
            using (IDbConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();

                string strSql = "select ID, ReportName, CreatedBy from REPORTRIGHT";

                //object parameters = new { Username = userName };
                //  Dictionary<string, object> parameters = new Dictionary<string, object>();
                //  parameters.Add("@Username", userName);

                string englishReportNamesXML  = HttpContext.Current.Server.MapPath("../Constants/englishReportNamesXML.xml");
                    //HttpContext.Current.Server.MapPath("/dapperdeneme1/englishReportNamesXML.xml");
                var xdoc = XDocument.Load(englishReportNamesXML);
                var map = (from c in xdoc.Root.Elements()
                            select new { Key = c.FirstAttribute.Value, Value = c.Value });
                Dictionary<string, string> mappingList = new Dictionary<string, string>();
                foreach (var item in map)

                {
                    mappingList.Add(item.Key, item.Value);

                }
              //  return mappingList;


                List<ReportRightResult> result = cn.Query<ReportRightResult>(strSql).ToList();
                for(int i = 0; i< result.Count; i++)
                {
                    result[i].ReportNameValue = mappingList[result[i].ReportName];
                }
                return result;

            }

        }
        public ReportRightResult GetReportRight(int ReportRightID)
        {
            string connectionString = "SERVER=(local);UID=sa;PWD=Arvento1;DATABASE=ArmakomComms;Pooling=false";
            string englishReportNamesXML = HttpContext.Current.Server.MapPath("../Constants/englishReportNamesXML.xml");
            using (IDbConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();

                string strSql = "select ID, ReportName, CreatedBy from REPORTRIGHT WHERE ID = @RID";

               // object parameters = new { Username = userName };
                  Dictionary<string, object> parameters = new Dictionary<string, object>();
                  parameters.Add("@RID", ReportRightID);
                string englishReportNamesXML2 = HttpContext.Current.Server.MapPath("../Constants/englishReportNamesXML.xml");
                //HttpContext.Current.Server.MapPath("/dapperdeneme1/englishReportNamesXML.xml");
                var xdoc = XDocument.Load(englishReportNamesXML2);
                var map = (from c in xdoc.Root.Elements()
                           select new { Key = c.FirstAttribute.Value, Value = c.Value });
                Dictionary<string, string> mappingList = new Dictionary<string, string>();
                foreach (var item in map)

                {
                    mappingList.Add(item.Key, item.Value);

                }

                ReportRightResult result = cn.Query<ReportRightResult>(strSql,parameters).FirstOrDefault();
               
                    result.ReportNameValue = mappingList[result.ReportName];
                
                return result;
              

            }

        }
        //public UserReportRightResult InsertUserReportRight(string userName, int ReportRightID, string CreatedBy = "SYSTEM")
        //{
        //    string connectionString = "SERVER=(local);UID=sa;PWD=Arvento1;DATABASE=ArmakomComms;Pooling=false";
        //    using (IDbConnection cn = new SqlConnection(connectionString))
        //    {
        //        cn.Open();
        //        Dictionary<string, object> parameters = new Dictionary<string, object>();
        //        parameters.Add("@UserName", userName);
        //        parameters.Add("@ReportRightID", ReportRightID);
        //        parameters.Add("@CBy", CreatedBy);
        //        string strSql = "exec acInsertUserReportRight @Username = @UserName, @ReportID = @ReportRightID, @CreatedBy = @Cby;";



        //        UserReportRightResult result = cn.Query<UserReportRightResult>(strSql, parameters).FirstOrDefault();
        //        return result;
        //    }

        //}


    }
}