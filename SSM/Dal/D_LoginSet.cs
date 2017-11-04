using Model.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class D_LoginSet
    {

        /// <summary>  
        /// 定义连接的字符串  
        /// </summary>  
        public static readonly string constr = ConfigurationManager.ConnectionStrings["DataConnStr"].ConnectionString;
        /// <summary>
        /// 添加之前的验证是否存在
        /// </summary>
        /// <param name="DBIP"></param>
        /// <param name="DBName"></param>
        /// <returns></returns>
        public string LoginSetCheck_Query(string DBIP, string DBName)
        {
            string result = "NULL";
            using (SqlConnection con = new SqlConnection(constr))
            {
                #region --数据库打开异常处理
                try
                {
                    con.Open();
                }
                catch (Exception ex)
                {
                    result = "数据库打开失败！";
                    return result;
                }
                #endregion
                string sqlstr_loginsetcheckquery = @" SELECT *
                                                      FROM  T_LoginSet
                                                      WHERE DataBaseIP=@DataBaseIP 
                                                        AND DataBaseName =@DataBaseName
                                      ";
                using (SqlCommand com = new SqlCommand())
                {
                    com.Connection = con;  //对应连接数据库连接
                    com.CommandText = sqlstr_loginsetcheckquery; //对应数据库SQL操作语句
                    com.Parameters.Add(new SqlParameter("@DataBaseIP", DBIP));
                    com.Parameters.Add(new SqlParameter("@DataBaseName", DBName));
                    try
                    {
                        SqlDataReader dr = com.ExecuteReader();//执行SQL语句
                        List<T_LoginSet> Dmode = new List<T_LoginSet>();//定义一个集合
                        while (dr.Read())
                        {
                            T_LoginSet modell = new T_LoginSet();
                            modell.ID =  Convert.ToInt32(dr["ID"].ToString());
                            modell.DataBaseIP = dr["DataBaseIP"].ToString();
                            modell.DataBaseInstance = dr["DataBaseInstance"].ToString();
                            modell.DataBaseName = dr["DataBaseName"].ToString();
                            modell.DataBaseUser = dr["DataBaseUser"].ToString();
                            modell.DataBasePassword = dr["DataBasePassword"].ToString();
                            Dmode.Add(modell);
                        }
                        if (Dmode.Count < 1)
                        {
                            result = "Null";
                        }
                        else
                        {
                            result = "exist";
                        }
                        dr.Close();//关闭执行
                        return result;
                    }
                    catch (Exception ex)
                    {
                        result = "数据库操作失败！";
                        return result;

                    }
                    finally
                    {
                        con.Close();//关闭数据库 
                    }
                }
            }
        }
        /// <summary>
        /// 添加操作
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool LoginSetCheck_Add(T_LoginSet model)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                try
                {
                    conn.Open();
                }
                catch(Exception ex)
                {

                }
                string sqlstr_loginsetadd = @"
                                INSERT INTO dbo.T_LoginSet
                                        ( DataBaseIP ,
                                          DataBaseInstance ,
                                          DataBaseName ,
                                          DataBaseUser ,
                                          DataBasePassword
                                        )
                                VALUES  ( @DataBaseIP,
                                          @DataBaseInstance,
                                          @DataBaseName,
                                          @DataBaseUser,
                                          @DataBasePassword
                                        )
                            ";
                using (SqlCommand com = new SqlCommand())
                {
                    com.Connection =conn;
                    com.CommandText = sqlstr_loginsetadd;
                    com.Parameters.Add(new SqlParameter("@DataBaseIP",model.DataBaseIP));
                    com.Parameters.Add(new SqlParameter("@DataBaseInstance", model.DataBaseInstance));
                    com.Parameters.Add(new SqlParameter("@DataBaseName", model.DataBaseName));
                    com.Parameters.Add(new SqlParameter("@DataBaseUser", model.DataBaseUser));
                    com.Parameters.Add(new SqlParameter("@DataBasePassword", model.DataBasePassword));
                    try
                    {
                        result = com.ExecuteNonQuery() > 0;
                        return result;
                    }
                    catch(Exception ex)
                    {
                        return result;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }
    }
}
