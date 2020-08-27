using PraveenBamane_Assignment.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PraveenBamane_Assignment.Modals
{
    public class PackingSlip
    {
        public int PackingSlipid { get; set; }

        public PackingSlipType type { get; set; }


        public List<AdditionalItems> addedservice { get; set; }
    }
}
