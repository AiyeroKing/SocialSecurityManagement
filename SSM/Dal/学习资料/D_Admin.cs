//using Model.Models;
//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Data.SqlClient;

//namespace Dal
//{

//    public class Result<T>
//    {
//        /// <summary>
//        /// 结果标识 -1:失败  1:成功
//        /// </summary>
//        public int Flag { get; set; } = -1;

//        /// <summary>
//        /// 结果信息
//        /// </summary>
//        public string Info { get; set; }

//        /// <summary>
//        /// 返回的数据信息
//        /// </summary>
//        public T Data { get; set; }
//    }


//    public class Dal
//    {
//        /// <summary>  
//        /// 定义连接的字符串  
//        /// </summary>  
//        public static readonly string constr = ConfigurationManager.ConnectionStrings["DataConnStr"].ConnectionString;
//        public Result<List<T_LoginSet>> LoginSetCheck_Query(string DBIP, string DBName)
//        {
//            Result<List<T_LoginSet>> result = new Result<List<T_LoginSet>>();

//            string sqlstr_loginsetcheckquery = @" SELECT *
//                                                      FROM  T_LoginSet
//                                                      WHERE DataBaseIP=@DataBaseIP 
//                                                        AND DataBaseName =@DataBaseName
//                                      ";

//            using (SqlConnection con = new SqlConnection(constr))
//            {
//                try
//                {
//                    con.Open();

//                    //如果有需要用到事务
//                    SqlTransaction tran = con.BeginTransaction();

//                    try
//                    {
//                        SqlCommand com = new SqlCommand();
//                        com.Connection = con;  //对应连接数据库连接
//                        com.CommandText = sqlstr_loginsetcheckquery; //对应数据库SQL操作语句
//                        com.Parameters.Add(new SqlParameter("@DataBaseIP", DBIP));
//                        com.Parameters.Add(new SqlParameter("@DataBaseName", DBName));

//                        SqlDataReader dr = com.ExecuteReader();//执行SQL语句
//                        result.Data = new List<T_LoginSet>();//定义一个集合
//                        while (dr.Read())
//                        {
//                            T_LoginSet modell = new T_LoginSet();
//                            modell.ID = Convert.ToInt32(dr["ID"].ToString());
//                            modell.DataBaseIP = dr["DataBaseIP"].ToString();
//                            modell.DataBaseInstance = dr["DataBaseInstance"].ToString();
//                            modell.DataBaseName = dr["DataBaseName"].ToString();
//                            modell.DataBaseUser = dr["DataBaseUser"].ToString();
//                            modell.DataBasePassword = dr["DataBasePassword"].ToString();
//                            result.Data.Add(modell);
//                        }

//                    }
//                    finally
//                    {
//                        if (result.Flag < 0)
//                        {
//                            //失败 回滚
//                            tran.Rollback();
//                        }
//                        else if (result.Flag > 0)
//                        {
//                            //成功 提交
//                            tran.Commit();
//                        }

//                        if (con.State == System.Data.ConnectionState.Open)
//                        {
//                            con.Close();
//                        }
//                    }

//                }
//                catch (Exception ex)
//                {
//                    result.Flag = -1;
//                    //if (ex.HResult = )  //判断数据库连接失败标识  这里写常量  或者定义一个故障常量类 直接判定
//                    //{
//                    //    result.Info = "数据库连接失败！";
//                    //}
//                    //else
//                    //{
//                    result.Info = ex.Message;
//                    //}
//                }


//            }

//            return result;
//        }
//    }
//}
