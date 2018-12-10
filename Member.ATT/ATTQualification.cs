using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Member.ATT
{
    public class ATTQualification
    {
        public int EmployeeId { get; set; }
        public int QualId { get; set; }
        public string Marks { get; set; }
        public string Action { get; set; }

        public string QualName { get; set; }
    }
}
