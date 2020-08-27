using NUnit.Framework;

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

    }
}