using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Member.ATT;
using Member.DLL;
using Utility;

namespace Member.BLL
{
    public class BLLEmployee
    {
        public JsonResponse GetEmployee()
        {
            JsonResponse response = new JsonResponse();
            try
            {
                DLLEmployee objDLL = new DLLEmployee();
                response.ResponseData = objDLL.GetEmployee();
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;
            }
            return response;
        }

        public JsonResponse SaveEmployee(ATTEmployee objATT)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLEmployee objDLL = new DLLEmployee();
                response.ResponseData = objDLL.SaveEmployee(objATT);
                response.IsSuccess = true;

            }

            catch (Exception ex)
            {
                response.ResponseData = ex.Message;
                response.IsSuccess = false;

            }


            return response;

        }

        public JsonResponse GetEmployeeDetails(string EmployeeId)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DLLEmployee objDll = new DLLEmployee();
                response.ResponseData = objDll.GetEmployeeDetails(EmployeeId);
                response.IsSuccess = true;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;

            }
            return response;
        }
    }
}
