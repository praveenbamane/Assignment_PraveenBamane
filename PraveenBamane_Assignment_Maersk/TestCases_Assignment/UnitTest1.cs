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

    }
}