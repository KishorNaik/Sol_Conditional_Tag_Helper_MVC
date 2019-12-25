using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol_Condition_Tag_Helper.TagHelpers
{
    public class ConditionTagHelpersModel
    {
        public bool MarkCondition { get; set; }

        public Object If { get; set; }

        public Object Else { get; set; }
    }
}
