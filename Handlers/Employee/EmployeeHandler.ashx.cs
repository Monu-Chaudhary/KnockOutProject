using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Member.ATT;
using Member.BLL;
using Utility;
using RS.Utility;

namespace KnockOut.Handlers.Employee
{
    /// <summary>
    /// Summary description for EmployeeHandler
    /// </summary>
    public class EmployeeHandler : BaseHandler  //, IHttpHandler
    {

        public object SaveEmployee(string args)
        {
            JsonResponse response = new JsonResponse();
            ATTEmployee objATT = JsonUtility.DeSerialize(args, typeof(ATTEmployee)) as ATTEmployee;
            BLLEmployee bllObj = new BLLEmployee();
            response = bllObj.SaveEmployee(objATT);
            return JsonUtility.Serialize(response);
        }


        public object GetEmployee()
        {
            JsonResponse response = new JsonResponse();
            BLLEmployee bllEmployee = new BLLEmployee();
            response = bllEmployee.GetEmployee();
            return JsonUtility.Serialize(response);
        }

        public object GetQualificationList()
        {
            JsonResponse response = new JsonResponse();
            BLLQualificationList bllQualificationList = new BLLQualificationList();
            response = bllQualificationList.GetQualificationList();
            return JsonUtility.Serialize(response);
        }

        public object GetEmployeeDetails(string EmployeeId)
        {
            JsonResponse response = new JsonResponse();
            BLLEmployee bllEmployee = new BLLEmployee();
            response = bllEmployee.GetEmployeeDetails(EmployeeId);
            return JsonUtility.Serialize(response);
        }

        public object GetQualificationDetails(string EmployeeId)
        {
            JsonResponse response = new JsonResponse();
            BLLQualification bllQualification = new BLLQualification();
            response = bllQualification.GetEmployeeDetails(EmployeeId);
            return JsonUtility.Serialize(response);
        }

        //public object UpdateQualification(string args)
        //{
        //    JsonResponse response = new JsonResponse();
        //    ATTQualification objATT = JsonUtility.DeSerialize(args, typeof(ATTQualification)) as ATTQualification;
        //    BLLQualification bllObj = new BLLQualification();
        //    response = bllObj.UpdateQualification(objATT);
        //    return JsonUtility.Serialize(response);
        //}

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}