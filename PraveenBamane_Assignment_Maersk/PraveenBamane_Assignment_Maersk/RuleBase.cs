using PraveenBamane_Assignment.Modals;
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
            _objpackingslip.PackingSlipid = generateID(10001);  // function to generate random ids
            _objpackingslip.type = Enums.PackingSlipType.Original;
            _objpackingslip.addedservice = null;
            return _objpackingslip;
        }



        private int generateID(int startindex)
        {
            // returns max or unique Memeber id. This can be fetched from database or generated randomly.

            Random id = new Random(startindex);
            id.Next();

            return id.Next();
        }

    }
}
