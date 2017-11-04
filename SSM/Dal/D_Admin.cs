using Model.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Dal
{
    public class D_Admin
    {
        #region --对数据进行操作的Dal语句--
        /// <summary>  
        /// 定义连接的字符串  
        /// </summary>  
        public static readonly string constr = ConfigurationManager.ConnectionStrings["DataConnStr"].ConnectionString;
        public string Scan_Account(T_Admin AdminMode)
        {
            string result = "false";
            using (SqlConnection conn = new SqlConnection(constr))
            {
                try
                {
                    conn.Open();
                }
                catch(Exception ex)
                {
                    result = "数据库打开失败！";
                }
                string sqlstr_scan_account = @"
                                                SELECT *
                                                FROM dbo.T_Admin
                                                WHERE UserName = @UserName
                                                  AND PassWord = @PassWord
                                            ";
                using (SqlCommand com = new SqlCommand())
                {
                    com.Connection = conn;
                    com.CommandText = sqlstr_scan_account;
                    com.Parameters.Add(new SqlParameter("@UserName", AdminMode.UserName));
                    com.Parameters.Add(new SqlParameter("@PassWord",AdminMode.PassWord));
                    try
                    {
                        SqlDataReader dr = com.ExecuteReader();
                        List<T_Admin> adminlist = new List<T_Admin>();
                        while(dr.Read())
                        {
                            T_Admin adminmode = new T_Admin();
                            adminmode.UserName = dr["UserName"].ToString();
                            adminmode.PassWord = dr["PassWord"].ToString();
                            adminlist.Add(adminmode);
                        }
                        dr.Close();

                        if (adminlist.Count>0)
                        {
                            result = "true";
                        }
                        else
                        {
                            result = "false";
                        }
                    }
                    catch(Exception ex)
                    {
                        result = "数据库操作执行出现异常，原因：" + ex.Message;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            return result;
        }

       
        #endregion
    }
}
