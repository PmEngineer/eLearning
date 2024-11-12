using DCA.Core.DataBase;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning_Core.Procedure
{
    public class GetLessonsBySubject
    {
        DatabaseHelper databaseHelper = new DatabaseHelper();
        public DataTable getLessonsBySubject(int SubId)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] para = new SqlParameter[]
                {
                    new SqlParameter("@SubId",SubId),
                };
                dt = databaseHelper.ExecProcDataTable("GetLessonsBySubject", para);
                return dt;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
