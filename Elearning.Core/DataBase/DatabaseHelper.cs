using System;  
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.Core.DataBase
{
    public class DatabaseHelper
    {
        public string connstr;
       public SqlConnection con;
        public DatabaseHelper() {
            connstr = "Server=DESKTOP-GVDCLHL;Database=ELearning;Trusted_Connection=True;MultipleActiveResultSets=true";
           con = new SqlConnection(connstr);
        }
     
        public int ExecuteNonQueryProc(string cmdText, SqlParameter[] prms)
        {
            int r = 0;
            try
            {
              
                using (SqlConnection conn = new SqlConnection(connstr))
                {
                    using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        if (prms != null)
                        {
                            foreach (SqlParameter p in prms)
                            {
                                cmd.Parameters.Add(p);
                            }
                        }
                        conn.Open();
                        try
                        {
                            r = cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                            r = 0;
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return r;

        }
        public DataTable ExecProcDataTable(string ProName, SqlParameter[] Param)
        {
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(ProName, con);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter prm in Param)
                {
                    cmd.Parameters.Add(prm);
                }
                cmd.CommandTimeout = 0;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                adp.Fill(dt);

            }

            catch (Exception ex)
            {
                Console.Write(ex.Message);

            }
            finally
            {
                con.Close();
            }
            return dt;
        }
        public DataSet ExecProcDataSet(string ProName, SqlParameter[] Param)
        {
            DataSet dt = new DataSet();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(ProName, con);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter prm in Param)
                {
                    cmd.Parameters.Add(prm);
                }
                cmd.CommandTimeout = 0;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return dt;
        }
        public DataTable ExecAdaptorDataTable(string Query)
        {
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return dt;
        }
        public DataTable ExecAdaptorDataTableProc(string Query)
        {
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return dt;
        }
        public DataTable IExecAdaptorDataTableProc(string Query)
        {
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Query, con);

                cmd.CommandTimeout = 0;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return dt;
        }
    }
}