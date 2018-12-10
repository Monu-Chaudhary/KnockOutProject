using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Member.ATT
{
    public class ATTEmployee
    {

        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string DOB { get; set; }
        public string Gender { get; set; }
        public string Salary { get; set; }
        public string Action { get; set; }

        private List<ATTQualification> _Qual = new List<ATTQualification>();

        public List<ATTQualification> Qualification
        {
            get { return _Qual; }
            set { _Qual = value; }
        }

    }
}
