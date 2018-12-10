using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Member.ATT;
using Utility;
using System.Data;
using System.Data.SqlClient;

namespace Member.DLL
{
    public class DLLEmployee
    {
        public List<ATTEmployee> GetEmployee()
        {
            List<ATTEmployee> lstEmp = new List<ATTEmployee>();

            DataSet ds = new DataSet();
            ds = DAO.gettable("Usp_GetEmployee", null);

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ATTEmployee objATT = new ATTEmployee();

                    objATT.EmployeeId = Convert.ToInt32(dr["EmployeeId"]);
                    objATT.Name = dr["Name"].ToString();
                    objATT.Gender = dr["Gender"].ToString();
                    objATT.DOB = dr["DOB"].ToString();
                    objATT.Salary = dr["Salary"].ToString();

                    lstEmp.Add(objATT);
                }
            }

            return lstEmp;
        }

        public string SaveEmployee(ATTEmployee objEmp)
        {
            string msg = "";

            SqlConnection conn = DAO.conn();

            using (conn)
            {
                SqlTransaction tran;
                tran = conn.BeginTransaction();
                try
                {
                    SqlCommand cmd;

                    if (objEmp.Action != null)
                    {
                        if (objEmp.Action == "E")
                            cmd = new SqlCommand("Usp_UpdateEmployee", conn, tran);
                        else
                            cmd = new SqlCommand("Usp_InsertEmployee", conn, tran);

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@EmployeeId", SqlDbType.Int).Value = objEmp.EmployeeId;
                        cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = objEmp.Name;
                        cmd.Parameters.Add("@DOB", SqlDbType.VarChar, 50).Value = objEmp.DOB;
                        cmd.Parameters.Add("@Gender", SqlDbType.VarChar, 50).Value = objEmp.Gender;
                        cmd.Parameters.Add("@Salary", SqlDbType.VarChar, 50).Value = objEmp.Salary;
                        cmd.ExecuteNonQuery();


                        //if (objEmp.Action == "A")
                        {
                            foreach (var item in objEmp.Qualification)
                            {
                                item.EmployeeId = objEmp.EmployeeId;
                            }
                            DLLQualification dllQualification = new DLLQualification();
                            dllQualification.SaveQualification(objEmp.Qualification, conn, tran);
                        }

                        tran.Commit();
                    }
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw new Exception("Error" + ex.Message);
                }
                return msg;
            }
        }

        public List<ATTEmployee> GetEmployeeDetails(string EmployeeId)
        {
            List<ATTEmployee> lst = new List<ATTEmployee>();

            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@EmployeeId", EmployeeId);
            ds = DAO.gettable("Usp_GetEmployeeDetails", param);

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ATTEmployee objATT = new ATTEmployee();
                    objATT.EmployeeId = Convert.ToInt32(dr["EmployeeId"]);
                    objATT.Name = dr["Name"].ToString();
                    objATT.Gender = dr["Gender"].ToString();
                    objATT.DOB = dr["DOB"].ToString();
                    objATT.Salary = dr["Salary"].ToString();
                    lst.Add(objATT);
                }
            }
            return lst;
        } 
    }
}
