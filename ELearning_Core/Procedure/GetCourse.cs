using DCA.Core.DataBase;
using ELearning_Core.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning_Core.Procedure
{
    public class GetCourse
    {
        DatabaseHelper databaseHelper = new DatabaseHelper();

        public DataTable getCoures()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] para = new SqlParameter[]
                {

                };
                dt = databaseHelper.ExecProcDataTable("getCourse", para);
                return dt;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}

