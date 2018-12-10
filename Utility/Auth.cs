using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.SessionState;
using System.Web;

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
   File                 :Auth.cs 
   Description          :This Page contain the Authentication class
   *********************************************************************************
   <Name>                                          <Date>         <Version>
   Raju Shahi <stylishraju@gmail.com>              18/07/2014      1.0.0                                                                    
   *********************************************************************************
    */
    # endregion

    public class Auth : IRequiresSessionState
    {
        public static string Token()
        {
            Guid token = Guid.NewGuid();

            HttpContext.Current.Session["Token"] = token;
            return token.ToString();
        }
    }
}
