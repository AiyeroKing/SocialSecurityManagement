string result = "";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = cons;
            // string constr = @"server=DESKTOP-BRAUOEP\ACKING;database=SSData;uid=sa;pwd=123";
            con.Open();
           string cmdstr = @" SELECT *
                              FROM  T_LoginSet

                              WHERE DataBaseIP=@DataBaseIP  AND DataBaseName =@DataBaseName

                                      ";
           
            
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            // com.CommandType = CommandType.Text;
            // com.CommandText = cmdstr;
            com.Parameters.Add(new SqlParameter("@DataBaseIP", DBIP));
            com.Parameters.Add(new SqlParameter("@DataBaseName", DBName));
            SqlDataReader dr = com.ExecuteReader();//执行SQL语句
            List<T_LoginSet> Dmode = new List<T_LoginSet>();

            //for (int i=0;dr.Read();i++) { }

            while( dr.Read()){
                T_LoginSet modell = new T_LoginSet();
                modell.DataBaseIP = dr["DataBaseIP"].ToString();
                Dmode.Add(modell);
            }
            if(Dmode.Count<1)
            {

            }
            else
            {

            }

            dr.Close();//关闭执行
            con.Close();//关闭数据库 