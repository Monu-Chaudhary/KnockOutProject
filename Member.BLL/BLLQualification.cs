using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;
using Member.ATT;
using Member.DLL;

namespace Member.BLL
{
    public class BLLQualification
    {
        public JsonResponse GetEmployeeDetails(string EmployeeId)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLQualification objDll = new DLLQualification();
                response.ResponseData = objDll.GetQualificationDetails(EmployeeId);
                response.IsSuccess = true;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;

            }
            return response;

        }

        //public JsonResponse UpdateQualification(ATTQualification objATT)
        //{
        //    JsonResponse response = new JsonResponse();
        //    try
        //    {
        //        DLLQualification objDLL = new DLLQualification();
        //        response.ResponseData = objDLL.UpdateQualification(objATT);
        //        response.IsSuccess = true;
        //    }

        //    catch (Exception ex)
        //    {
        //        response.ResponseData = ex.Message;
        //        response.IsSuccess = false;
        //    }

        //    return response;

        //}

    }
}
