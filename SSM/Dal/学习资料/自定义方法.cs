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
                            result = "exist ";
                        }
                        dr.Close();//关闭执行
                        con.Close();//关闭数据库 
                        return result;
                    }
                    catch (Exception ex)
                    {
                        result = "数据库操作失败！";
                        con.Close();
                        return result;
                    }
                }
            }
        }