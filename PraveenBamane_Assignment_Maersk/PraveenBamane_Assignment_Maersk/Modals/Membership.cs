using System;
using System.Collections.Generic;
using System.Text;

namespace PraveenBamane_Assignment.Modals
{
    public class Membership
    {

        //public Membership(int Id)
        //{
        //    this.Membershipid = Id;
        //    this.Membershiplevel = 0; //this can fetched, current level by default set to 0
        //    this.Membershipstartdate = System.DateTime.Now; //this can fetched,  by default set to current date

        //}
        public int Membershipid { get; set; }

        public string Memberemail { get; set; }

        public DateTime Membershipstartdate { get; set; }


        public DateTime Membershipenddate
        {
            get { return this.Membershipstartdate.AddDays(365); } // assuming membership is valid  only for 1 year only.
        }

        public int Membershiplevel { get; set; }

        public bool Memberisactive { get; set; }

    }
}
