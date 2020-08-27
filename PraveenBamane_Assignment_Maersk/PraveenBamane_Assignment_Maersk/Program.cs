using System;
using PraveenBamane_Assignment.Enums;
using PraveenBamane_Assignment.Modals;

namespace PraveenBamane_Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            RuleBase _rule = null;
            int PaymentType;

            int level;
            string video = "";
            PaymentOrderType selectedPaymentoption;

            Console.WriteLine("Provide the payment type from below options, enter the option number. \n 1. Product \n 2. Video \n 3. Books \n 4. Activate Membership \n 5. Update Membership");

            while (!int.TryParse(Console.ReadLine(), out PaymentType))
            {
                Console.WriteLine("Invalid option provide, please provide the payment type from below options, enter the option number. \n 1. Product \n 2. Video \n 3. Books \n 4. Activate Membership \n 5. Update Membership");
            }
            if (PaymentType == 1)
            {
                Product(out _rule, out selectedPaymentoption);
            }
            else if (PaymentType == 2)
            {
                Video(out _rule, out video, out selectedPaymentoption);
            }
            else if (PaymentType == 3)
            {
                Books(out _rule, out selectedPaymentoption);

            }
            else if (PaymentType == 4)
            {
                ActivateMembership(out _rule, out selectedPaymentoption);

            }
            else if (PaymentType == 5)
            {
                UpdateMembership(out _rule, out level, out selectedPaymentoption);
            }
            else
            {
                Console.WriteLine("invalid option provided. \n Exiting ...");
                return;
            }

        }

        public static void UpdateMembership(out RuleBase _rule, out int level, out PaymentOrderType selectedPaymentoption)
        {
            _rule = new RuleBase();
            selectedPaymentoption = PaymentOrderType.UpdateMembership;
            Console.WriteLine("Please provide the memberid for upgradation");
            level = 0;

            string Id = Console.ReadLine();

            //check if member exists
            if (Id == "" || Id == null)
            {
                Console.WriteLine("Provide the correct member id");
            }
            else
            {
                Membership member = new Membership();


                Console.WriteLine("Provide the membership upgrade level. Starting from 0 to 10 ");
                level = int.Parse(Console.ReadLine());

                member = _rule.GenerateMember(member, level);

                Console.WriteLine("Membership updated successfully. Current level set to {0}", level);

            }
        }

        public static void ActivateMembership(out RuleBase _rule, out PaymentOrderType selectedPaymentoption)
        {
            _rule = new RuleBase();
            selectedPaymentoption = PaymentOrderType.MemberShip;
            Console.WriteLine("Please provide the valid email id for membership");

            string email = Console.ReadLine();

            Membership member = _rule.GenerateMember(email);

            Console.WriteLine("Member with with email {0} activated with id: {1}", email, member.Membershipid);
        }

        private static void Books(out RuleBase _rule, out PaymentOrderType selectedPaymentoption)
        {
            _rule = new RuleBase();
            selectedPaymentoption = PaymentOrderType.Books;

            PackingSlip originalpackingslip = _rule.Generatepackingslip("Order:1020");
            PackingSlip royality_dep = _rule.Generatepackingslip("Order:1020", true);
            Console.WriteLine("Packing slips generated");

            double _agentcommision = _rule.GenerateAgentcommision(500.00);
            Console.WriteLine("agent commision generated for Rs {0}", _agentcommision);
        }

        private static void Video(out RuleBase _rule, out string video, out PaymentOrderType selectedPaymentoption)
        {
            selectedPaymentoption = PaymentOrderType.Video;
            _rule = new RuleBase();
            Console.WriteLine("Provide the name of the video");
            video = Console.ReadLine();

            PackingSlip _slip = _rule.getvideourl(video);

            foreach (var item in _slip.addedservice)
            {
                Console.WriteLine("Access to video provided follow the link:" + item.videourl);
            }
        }

        private static void Product(out RuleBase _rule, out PaymentOrderType selectedPaymentoption)
        {
            selectedPaymentoption = PaymentOrderType.Product;
            _rule = new RuleBase();
            PackingSlip _slip = _rule.Generatepackingslip("Order No:909");
            Console.WriteLine("Packing slip generated");

            double _agentcommision = _rule.GenerateAgentcommision(500.00);
            Console.WriteLine("agent commision generated for Rs {0}", _agentcommision);
        }
    }
}
