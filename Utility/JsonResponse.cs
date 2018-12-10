using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utility
{
    public class JsonResponse
    {

        private bool _IsSuccess = false;

        public bool IsSuccess
        {
            get { return _IsSuccess; }
            set { _IsSuccess = value; }
        }

        private string _Message = string.Empty;

        public string Message
        {
            get { return _Message; }
            set { _Message = value; }
        }

        private string _Token = string.Empty;

        public string Token
        {
            get { return _Token; }
            set { _Token = value; }
        }

        private object _ResponseData = null;

        public object ResponseData
        {
            get { return _ResponseData; }
            set { _ResponseData = value; }
        }

        private object _Records = null;
        public object Records
        {
            get { return _Records; }
            set { _Records = value; }
        }

        private object _TotalRecords = null;
        public object TotalRecords
        {
            get { return _TotalRecords; }
            set { _TotalRecords = value; }
        }

        private string _CallBack = string.Empty;
        public string CallBack
        {
            get { return _CallBack; }
            set { _CallBack = value; }
        }

        private bool _IsToken = true;
        public bool IsToken
        {
            get { return _IsToken; }
            set { _IsToken = value; }
        }
    }
}
