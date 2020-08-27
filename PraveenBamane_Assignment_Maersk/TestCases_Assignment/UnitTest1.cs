using NUnit.Framework;
using PraveenBamane_Assignment.Modals;

namespace TestCases_Assignment
{

    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void packingsliptest()
        {
            PraveenBamane_Assignment.RuleBase _obj = new PraveenBamane_Assignment.RuleBase();

            var returntype = _obj.Generatepackingslip("OrderNo");

            Assert.IsNotNull(returntype.PackingSlipid);
            Assert.Pass();
        }

        [Test]
        public void packingslipduplicate()
        {
            PraveenBamane_Assignment.RuleBase _obj = new PraveenBamane_Assignment.RuleBase();

            var returntype = _obj.Generatepackingslip("OrderNo", true);

            PraveenBamane_Assignment.Enums.PackingSlipType _objSliptype = new PraveenBamane_Assignment.Enums.PackingSlipType();


            Assert.AreEqual(_objSliptype, returntype.type);  // this will fail as expected is orginial and returned is duplicate.
            Assert.Pass();
        }


        [Test]
        public void Membershiptest()
        {
            PraveenBamane_Assignment.RuleBase _obj = new PraveenBamane_Assignment.RuleBase();

            var returntype = _obj.GenerateMember("bamane1090@gmail.com");

            Assert.IsNotNull(returntype.Membershipid);
            Assert.Pass();
        }

        [Test]
        public void UpdateMembershiptest()
        {
            PraveenBamane_Assignment.RuleBase _obj = new PraveenBamane_Assignment.RuleBase();

            Membership _member = new Membership();

            var returntype = _obj.GenerateMember(_member, 3);

            Assert.AreEqual(3, returntype.Membershiplevel);  // match the passed upgraded level with returned level
            Assert.Pass();
        }


    }
}