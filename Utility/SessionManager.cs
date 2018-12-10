using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;
using Utility;

namespace RS.Utility
{
    # region Copyright
    /*
   *********************************************************************************
   Copyright © SOSYS , 2014
   info@ssf.gov.np

   This program is the intellectual property of Ministry of Labour and Employment.
   The program may be used, modified and/or copied only with the written permission 
   in accordance with the terms and conditions stipulated in the agreement/contract 
   under which the program has been supplied.

   *********************************************************************************
   Project              :Social Security Information Management System (SOSYS)  
   File                 :SessionManager.cs 
   Description          :This Page contain the SessionManager class
   *********************************************************************************
   <Name>                                          <Date>         <Version>
   Raju Shahi <stylishraju@gmail.com>              18/07/2014      1.0.0                                                                    
   *********************************************************************************
    */
    # endregion

    public class SessionManager : IRequiresSessionState
    {
        //public static HttpContext context = HttpContext.Current;
        private const string SESSION_StageFlag = "StageFlag";
        private const string SESSION_CurrentDate = "CurrentDate";

        //public static string StageFlag
        //{
        //    get
        //    {
        //        if (context.Session[SESSION_StageFlag] != null)
        //            return context.Session[SESSION_StageFlag] as string;
        //        else
        //            return null;
        //    }
        //    set
        //    {
        //        context.Session[SESSION_StageFlag] = value;
        //    }
        //}

        public static JsonResponse CurrentDate
        {


            get
            {
                if (HttpContext.Current.Session != null)
                {
                    if (HttpContext.Current.Session[SESSION_CurrentDate] != null)
                    {
                        return (JsonResponse)HttpContext.Current.Session[SESSION_CurrentDate];
                    }
                }
                return null;
            }
            set { HttpContext.Current.Session[SESSION_CurrentDate] = value; }
        }

    }
}
