using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Member.ATT;
using System.Data;
using Utility;

namespace Member.DLL
{
    public class DLLQualificationList
    {
        public List<ATTQualificationList> GetQualificationList()
        {
            List<ATTQualificationList> lstQualList = new List<ATTQualificationList>();

            DataSet ds = new DataSet();
            ds = DAO.gettable("Usp_GetQualificationList", null);

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ATTQualificationList objATT = new ATTQualificationList();
                    objATT.QualId = Convert.ToInt32(dr["QualId"]);
                    objATT.QualName = dr["QualName"].ToString();

                    lstQualList.Add(objATT);
                }
            }
            return lstQualList;
        }
    }
}
