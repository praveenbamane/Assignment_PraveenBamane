using System;
using System.Collections.Generic;
using System.Text;

namespace PraveenBamane_Assignment
{
   public class RuleBase
    {

        public PackingSlip Generatepackingslip(string orderdetails)
        {
            PackingSlip _objpackingslip = new PackingSlip();
            _objpackingslip.PackingSlipid = generateMemberID(10001);
            _objpackingslip.type = Enums.PackingType.Original;
            _objpackingslip.addedservice = null;
            return _objpackingslip;
        }



    }
}
