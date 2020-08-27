using PraveenBamane_Assignment.Modals;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

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

        public PackingSlip Generatepackingslip(string orderdetails, bool isduplicate)
        {
            PackingSlip _objpackingslip = new PackingSlip();
            _objpackingslip.PackingSlipid = generateID(10001);
            _objpackingslip.type = Enums.PackingSlipType.Duplicate;
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

        public Membership GenerateMember(string email)
        {
            Membership _member = new Membership()
            {
                Membershipid = generateID(0),  //used same function to generate ID but it can be fetched.
                Membershipstartdate = System.DateTime.Now, // using current date as start date. logically ! End Date is always +1 year (assumed)
                Membershiplevel = 0,
                Memberisactive = true,
                Memberemail = email
            };


            /*
             
             code to save membership in database/server if necessory 
             
             */

            Task task = Task.Run(() => sendmail(email, "Memebership Activated", "Dear User, Your membership has been activated starting today. please do not reply to this system generated email address. Regards W Enterprise."));

            return _member;
        }


        public Membership GenerateMember(Membership _member, int level)
        {

            _member.Memberisactive = true;
            _member.Membershiplevel = level;
            _member.Membershipstartdate = System.DateTime.Now;

            /*
             
             code to Update membership details in database/server if necessory 
             
             */
            Task task = Task.Run(() => sendmail(_member.Memberemail, "Memebership Updated", "Dear User, Your membership has been updated starting today. please do not reply to this system generated email address. Regards W Enterprise."));
            return _member;
        }

        private async Task sendmail(string emailid, string subject, string body)
        {
            string ToList = emailid;


            //string ToList = "";

            MailMessage message = new MailMessage();



            message.From = new MailAddress("noreply@wayaneenterprise.com");  // random mail address
            message.To.Add(new MailAddress(ToList)); // Users email address for email notification.
            message.Subject = subject;
            message.IsBodyHtml = true; //to make message body as html else false   
            message.Body = body;


            using (var smtpClient = new SmtpClient())

            {
                smtpClient.Port = 25;
                smtpClient.Host = "smtpdce.wayneenterprise.net"; //some random Hosting smtp server..  
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential("test@wayneenterprise.com", "randompassword");
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                await smtpClient.SendMailAsync(message);
            }


        }

        public PackingSlip getvideourl(string videoName)
        {
            List<AdditionalItems> listofitems = new List<AdditionalItems>();

            listofitems.Add(new AdditionalItems
            {
                videourl = "url to video selected by user"
            });

            if (videoName == "Learning to Ski")
            {
                listofitems.Add(new AdditionalItems
                {
                    videourl = "url to video First Aid"
                });
            }

            PackingSlip _objpackingslip = new PackingSlip();

            _objpackingslip.PackingSlipid = generateID(10002);
            _objpackingslip.type = Enums.PackingSlipType.Duplicate;
            _objpackingslip.addedservice = listofitems;
            return _objpackingslip;
        }

        public double GenerateAgentcommision(double payment)
        {
            double agentcommision = 0.00;



            if (1 == 1) // check if agent is still active or died, we can also check if he was double agent :D
            {
                agentcommision = payment / 2;  // agent commision is very high in wayneenterprise :) 
            }
            else if (2 == 2) // He/She is indeed a double agent
            {
                agentcommision = payment / 4;  // reduce the agent commision :) 
            }


            return agentcommision;
        }

    }
}
