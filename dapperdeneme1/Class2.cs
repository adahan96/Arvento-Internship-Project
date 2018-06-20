using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;

namespace dapperdeneme1.Models
{
    public class ReportRightResult
    {
        public int Id { get; set; }
        public string ReportName { get; set; }
        public string CreatedBy { get; set; }

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

                List<ReportRightResult> result = cn.Query<ReportRightResult>(strSql).ToList();
                return result;

            }

        }
        public ReportRightResult GetReportRight(int ReportRightID)
        {
            string connectionString = "SERVER=(local);UID=sa;PWD=Arvento1;DATABASE=ArmakomComms;Pooling=false";
            using (IDbConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();

                string strSql = "select ID, ReportName, CreatedBy from REPORTRIGHT WHERE ID = @RID";

               // object parameters = new { Username = userName };
                  Dictionary<string, object> parameters = new Dictionary<string, object>();
                  parameters.Add("@RID", ReportRightID);

                ReportRightResult result = cn.Query<ReportRightResult>(strSql,parameters).FirstOrDefault();
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