using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utility
{
    public class JsonUtility
    {
        public static object Serialize(JsonResponse response)
        {
            try
            {
                System.Web.Script.Serialization.JavaScriptSerializer jSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                jSerializer.MaxJsonLength = 500000000;

                return jSerializer.Serialize(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static object DeSerialize(string json, Type ObjectType)
        {
            try
            {
                object objDeserialized = Newtonsoft.Json.JsonConvert.DeserializeObject(json, ObjectType);

                return objDeserialized;
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
