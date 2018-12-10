using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Member.ATT;
using Utility;
using System.Data.SqlClient;
using System.Data;

namespace Member.DLL
{
    public class DLLQualification
    {
        public void SaveQualification(List<ATTQualification> lstQual, SqlConnection con, SqlTransaction tran)
        {
            try
            {
                var flag = "";
                List<ATTQualification> lst = GetQualificationDetails(lstQual[0].EmployeeId.ToString());
                foreach (var item in lst)
                {
                    foreach (var emp in lstQual)
                    {
                        if (item.QualId == emp.QualId) {
                            flag = "Exist";
                            break;
                        }
                        else if (item.QualId != emp.QualId) {
                            flag = "DoesNotExixt";
                        }
                    }
                    if (flag == "DoesNotExixt")
                    {
                        SqlCommand cd = new SqlCommand("Usp_DeleteQualification", con, tran);
                        cd.CommandType = CommandType.StoredProcedure;
                        cd.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = item.EmployeeId;
                        cd.Parameters.Add("@QualId", SqlDbType.Int).Value = item.QualId;
                        cd.ExecuteNonQuery();
                    }
                }

                foreach (var emp in lstQual)
                {
                    SqlCommand cmd = new SqlCommand("Usp_InsertQualification", con, tran);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = emp.EmployeeId;
                    cmd.Parameters.Add("@QualId", SqlDbType.Int).Value = emp.QualId;
                    cmd.Parameters.Add("@Marks", SqlDbType.VarChar, 50).Value = emp.Marks;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ATTQualification> GetQualificationDetails(string EmployeeId)
        {
            List<ATTQualification> lstQualification = new List<ATTQualification>();

            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@EmployeeId", EmployeeId);
            ds = DAO.gettable("Usp_GetQualificationDetails", param);

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ATTQualification objATT = new ATTQualification();
                    objATT.EmployeeId = Convert.ToInt32(dr["EmployeeId"]);
                    objATT.QualId = Convert.ToInt32(dr["QualId"]);
                    objATT.Marks = dr["Marks"].ToString();
                    objATT.QualName = dr["QualName"].ToString();
                    lstQualification.Add(objATT);
                }

            }
            return lstQualification;
        }

        //public string UpdateQualification(ATTQualification obj)
        //{
        //    string msg = "";
        //    SqlConnection con = DAO.conn();
        //    using (con)
        //    {
        //        try
        //        {
        //            SqlCommand cmd;
        //            if (obj.Action != null)
        //            {
        //                if (obj.Action == "I")
        //                    cmd = new SqlCommand("Usp_InsertQualification", con);
        //                else if (obj.Action == "U")
        //                    cmd = new SqlCommand("Usp_UpdateQualification", con);

        //                else
        //                    cmd = new SqlCommand("Usp_DeleteQualification", con);

        //                cmd.CommandType = CommandType.StoredProcedure;
        //                cmd.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = obj.EmployeeId;
        //                cmd.Parameters.Add("@QualId", SqlDbType.Int, 10).Value = obj.QualId;
        //                cmd.Parameters.Add("@Marks", SqlDbType.VarChar, 50).Value = obj.Marks;            
        //                cmd.ExecuteNonQuery();
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception("Error" + ex.Message);
        //        }
        //    }
        //    return msg;
        //}
 
    }
}
