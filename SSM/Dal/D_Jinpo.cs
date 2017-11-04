using Model.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    #region --对主界面面板进行数据操作
    public class D_Jinpo
    {
        /// <summary>  
        /// 定义连接的字符串  
        /// </summary>  
        public static readonly string constr = ConfigurationManager.ConnectionStrings["DataConnStr"].ConnectionString;

        #region --主界面
        /// <summary>
        /// 主界面背景数据查询
        /// </summary>
        /// <returns></returns>
        public List<T_Jinpo> BlackGroundData_Query()
        {
            List<T_Jinpo> modelist = new List<T_Jinpo>();

            using (SqlConnection con = new SqlConnection(constr))
            {
                try
                {
                    con.Open();
                }
                catch (Exception ex)
                {

                }
                string sqlstr_blackgrounddata_query = @"
                                                        SELECT *
                                                        FROM  dbo.T_Jinpo
                                                      ";

                using (SqlCommand com = new SqlCommand())
                {
                    com.Connection = con;
                    com.CommandText = sqlstr_blackgrounddata_query;
                    try
                    {
                        SqlDataReader dr = com.ExecuteReader();
                        while (dr.Read())
                        {
                            T_Jinpo mode = new T_Jinpo();
                            mode.ID = Convert.ToInt32(dr["ID"]);
                            mode.JinpoName = dr["JinpoName"].ToString();
                            mode.JinpoID = dr["JinpoID"].ToString();
                            mode.JinpoIDCar = dr["JinpoIDCar"].ToString();
                            mode.JinpoManey = Convert.ToInt32(dr["JinpoManey"]);
                            mode.JinpoPhone = dr["JinpoPhone"].ToString();
                            mode.JinpoPayState = dr["JinpoPayState"].ToString();
                            mode.JinpoAttendState = dr["JinpoAttendState"].ToString();
                            modelist.Add(mode);
                        }
                    }
                    catch (Exception ex)
                    { }
                    finally
                    {
                        con.Close();
                    }
                }

            }
            return modelist;
        }
        /// <summary>
        /// 主界面查询按钮
        /// </summary>
        /// <param name="select"></param>
        /// <param name="inputstr"></param>
        /// <returns></returns>
        public List<T_Jinpo> BlackGroundData_Btn_Query(string select, string inputstr)
        {
            List<T_Jinpo> modellist = new List<T_Jinpo>();
            using (SqlConnection conn = new SqlConnection(constr))
            {
                try
                {

                    conn.Open();


                }
                catch (Exception ex)
                {

                }
                string sqlstr_name = @"
                                  SELECT *
                                  FROM  dbo.T_Jinpo
                                  WHERE JinpoName = @JinpoName
                        ";
                string sqlstr_ID = @"
                                  SELECT *
                                  FROM  dbo.T_Jinpo
                                  WHERE ID = @ID
                        ";

                using (SqlCommand com = new SqlCommand())
                {
                    com.Connection = conn;
                    if (select == "个人编号")//ID
                    {
                        com.CommandText = sqlstr_ID;
                        com.Parameters.Add(new SqlParameter("@ID", inputstr));
                    }
                    else//姓名Name
                    {
                        com.CommandText = sqlstr_name;
                        com.Parameters.Add(new SqlParameter("@JinpoName", inputstr));
                    }
                    try
                    {
                        SqlDataReader dr = com.ExecuteReader();
                        while (dr.Read())
                        {
                            T_Jinpo mode = new T_Jinpo();
                            mode.ID = Convert.ToInt32(dr["ID"]);
                            mode.JinpoName = dr["JinpoName"].ToString();
                            mode.JinpoID = dr["JinpoID"].ToString();
                            mode.JinpoIDCar = dr["JinpoIDCar"].ToString();
                            mode.JinpoManey = Convert.ToInt32(dr["JinpoManey"]);
                            mode.JinpoPhone = dr["JinpoPhone"].ToString();
                            mode.JinpoPayState = dr["JinpoPayState"].ToString();
                            mode.JinpoAttendState = dr["JinpoAttendState"].ToString();
                            modellist.Add(mode);
                        }
                        dr.Close();
                    }
                    catch (Exception ex)
                    {

                    }
                    finally
                    {
                        conn.Close();
                    }

                }
            }
            return modellist;
        }
        /// <summary>
        /// 查找一个对象model
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T_Jinpo scanmodelData(int id)
        {
            T_Jinpo tmodel = new T_Jinpo();
            using (SqlConnection conn = new SqlConnection(constr))
            {
                try
                {
                    conn.Open();
                }
                catch (Exception e)
                {

                }
                string sqlstr_scanmodeldata = @"
                                                SELECT *
                                                FROM  dbo.T_Jinpo
                                                WHERE ID = @ID
                                              ";
                using (SqlCommand com = new SqlCommand())
                {
                    com.Connection = conn;
                    com.CommandText = sqlstr_scanmodeldata;
                    com.Parameters.Add(new SqlParameter("@ID", id));
                    try
                    {
                        SqlDataReader dr = com.ExecuteReader();
                        while (dr.Read())
                        {
                            T_Jinpo newjinpo = new T_Jinpo();
                            newjinpo.ID = Convert.ToInt32(dr["ID"]);
                            newjinpo.JinpoManey = Convert.ToInt32(dr["JinpoManey"]);
                            newjinpo.JinpoAttendState = Convert.ToString(dr["JinpoAttendState"]);
                            newjinpo.JinpoID = Convert.ToString(dr["JinpoID"]);
                            newjinpo.JinpoIDCar = Convert.ToString(dr["JinpoIDCar"]);
                            newjinpo.JinpoName = Convert.ToString(dr["JinpoName"]);
                            newjinpo.JinpoPayState = Convert.ToString(dr["JinpoPayState"]);
                            newjinpo.JinpoPhone = Convert.ToString(dr["JinpoPhone"]);
                            tmodel = newjinpo;
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
            return tmodel;
        }

        /// <summary>
        /// 删除一个对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeletmodelData(int id)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {

                }
                string sqlstr = @"
                                    DELETE dbo.T_Jinpo 
                                    WHERE ID = @ID
                                ";
                using (SqlCommand com = new SqlCommand())
                {
                    com.Connection = conn;
                    com.CommandText = sqlstr;
                    com.Parameters.Add(new SqlParameter("@ID", id));
                    try
                    {
                        result = com.ExecuteNonQuery() > 0;
                    }
                    catch (Exception ex)
                    {

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

        #region --编辑页面
        /// <summary>
        /// 数据更新操作
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool EditedWin_Updata(T_Jinpo model)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {

                }
                string sqlstr_EditedWin_Updata = @"
                                                    UPDATE T_Jinpo	
                                                     SET
	                                                    JinpoName = @JinpoName,
                                                        JinpoID = @JinpoID,
	                                                    JinpoIDCar = @JinpoIDCar,
	                                                    JinpoManey =@JinpoManey,
	                                                    JinpoPhone =@JinpoPhone,
	                                                    JinpoPayState = @JinpoPayState,
	                                                    JinpoAttendState = @JinpoAttendState
                                                    WHERE ID=@ID
                                                 ";
                using (SqlCommand com = new SqlCommand())
                {
                    com.Connection = conn;
                    com.CommandText = sqlstr_EditedWin_Updata;
                    com.Parameters.Add(new SqlParameter("@ID", model.ID));
                    com.Parameters.Add(new SqlParameter("@JinpoName", model.JinpoName));
                    com.Parameters.Add(new SqlParameter("@JinpoID", model.JinpoID));
                    com.Parameters.Add(new SqlParameter("@JinpoIDCar", model.JinpoIDCar));
                    com.Parameters.Add(new SqlParameter("@JinpoManey", model.JinpoManey));
                    com.Parameters.Add(new SqlParameter("@JinpoPhone", model.JinpoPhone));
                    com.Parameters.Add(new SqlParameter("@JinpoPayState", model.JinpoPayState));
                    com.Parameters.Add(new SqlParameter("@JinpoAttendState", model.JinpoAttendState));
                    try
                    {
                        result = com.ExecuteNonQuery() > 0;
                        if (result)
                        {
                            result = true;
                        }
                        else
                        {
                            result = false;
                        }
                    }
                    catch (Exception ex)
                    {

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

        #region --添加页面
        /// <summary>
        /// 数据添加操作
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddedWin_Add(T_Jinpo model)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(constr))
            {
                try
                {
                    conn.Open();
                }
                catch (Exception ex)
                {

                }
                string sqlstr_addedWin_add = @"
                                                INSERT	dbo.T_Jinpo
                                                    ( 
		                                                JinpoName ,
                                                        JinpoID ,
                                                        JinpoIDCar ,
                                                        JinpoManey ,
                                                        JinpoPhone ,
                                                        JinpoPayState ,
                                                        JinpoAttendState
                                                    )
                                                VALUES  ( 
		                                                @JinpoName,
                                                        @JinpoID,
                                                        @JinpoIDCar,
                                                        @JinpoManey,
                                                        @JinpoPhone,
                                                        @JinpoPayState,
                                                        @JinpoAttendState
                                                    )
                                                 ";
                using (SqlCommand com = new SqlCommand())
                {
                    com.Connection = conn;
                    com.CommandText = sqlstr_addedWin_add;
                    com.Parameters.Add(new SqlParameter("@JinpoName", model.JinpoName));
                    com.Parameters.Add(new SqlParameter("@JinpoID", model.JinpoID));
                    com.Parameters.Add(new SqlParameter("@JinpoIDCar", model.JinpoIDCar));
                    com.Parameters.Add(new SqlParameter("@JinpoManey", model.JinpoManey));
                    com.Parameters.Add(new SqlParameter("@JinpoPhone", model.JinpoPhone));
                    com.Parameters.Add(new SqlParameter("@JinpoPayState", model.JinpoPayState));
                    com.Parameters.Add(new SqlParameter("@JinpoAttendState", model.JinpoAttendState));
                    try
                    {
                        result = com.ExecuteNonQuery() > 0;
                        if (result)
                        {
                            result = true;
                        }
                        else
                        {
                            result = false;
                        }
                    }
                    catch (Exception ex)
                    {

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
    #endregion
}
