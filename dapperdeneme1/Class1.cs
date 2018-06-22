using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;

namespace dapperdeneme1.Models
{
    public class UserReportRightResult
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int ReportRightID { get; set; }
        public string CreatedBy { get; set; }

    }
    public class UserReportRight:IDisposable
    {
        public List<UserReportRightResult> GetUserReportRight(string userName)
        {
            string connectionString = "SERVER=(local);UID=sa;PWD=Arvento1;DATABASE=ArmakomComms;Pooling=false";
            using (IDbConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();

                string strSql = "select ID, Username, ReportRightID from USERREPORTRIGHT WHERE USERNAME = @Username";

                //object parameters = new { Username = userName };
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@Username", userName);

                List<UserReportRightResult> result = cn.Query<UserReportRightResult>(strSql, parameters).ToList();
                return result;
            }

        }
        public List<UserReportRightResult> GetUserReportRight()
        {
            string connectionString = "SERVER=(local);UID=sa;PWD=Arvento1;DATABASE=ArmakomComms;Pooling=false";
            using (IDbConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();

                string strSql = "select ID, Username, ReportRightID from USERREPORTRIGHT";

                //object parameters = new { Username = userName };
              //  Dictionary<string, object> parameters = new Dictionary<string, object>();
              //  parameters.Add("@Username", userName);

                List<UserReportRightResult> result = cn.Query<UserReportRightResult>(strSql).ToList();
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
        public void InsertUserReportRight(string userName, int ReportRightID, string CreatedBy)
        {
            string connectionString = "SERVER=(local);UID=sa;PWD=Arvento1;DATABASE=ArmakomComms;Pooling=false";
            using (IDbConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@UserName", userName);
                parameters.Add("@RID", ReportRightID);
                parameters.Add("@CBy", CreatedBy);

                string strSql = "exec acInsertUserReportRight @Username = @UserName, @ReportID = @RID, @CreatedBy = @CBy;";



                cn.Query<UserReportRightResult>(strSql, parameters);
          
            }

        }
          public void DeleteUserReportRight(string UserName, int ReportRightID, string deletedBy) {
            string connectionString = "SERVER=(local);UID=sa;PWD=Arvento1;DATABASE=ArmakomComms;Pooling=false";
            using (IDbConnection cn = new SqlConnection(connectionString))
            {
                cn.Open();
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@UserName", UserName);
                parameters.Add("@RID", ReportRightID);
                parameters.Add("@DBy", deletedBy);
                
                string strSql = "exec acDeleteUserReportRight @UserName = @UserName, @ReportRightID = @RID, @DeletedBy = @DBy;";



                cn.Query<UserReportRightResult>(strSql, parameters);

            }

        }

        public void Dispose()
        {
        }
    }
}