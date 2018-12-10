using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Member.DLL;
using Utility;
using System.Threading.Tasks;

namespace Member.BLL
{
    public class BLLQualificationList
    {
        public JsonResponse GetQualificationList()
        {
            JsonResponse response = new JsonResponse();
            try
            {
                DLLQualificationList objDLL = new DLLQualificationList();
                response.ResponseData = objDLL.GetQualificationList();
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
