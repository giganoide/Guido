using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guido;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace GuidoTest
{
    [TestFixture]
    public class PowerEditExtTest
    {
        static object[] _inputList =
        {
            new object[] 
            {
                new Dictionary<int, string> {{1, "N100"}, {2, "N200"}, {3, "N300"}},
                new Dictionary<int, string> ().GroupBy(x => x.Key)
            },
            new object[] 
            {
                new Dictionary<int, string> {{1, "N100"}, {2, "N100"}, {3, "N300"}},
                new Dictionary<int, string> {{1, "N100"}, {2, "N100"}}.GroupBy(x => x.Key)
            },
            new object[]
            {
                new Dictionary<int, string> {{1, "N100"}, {2, "N100"}, {3, "N200"}, {4, "N200"}},
                new Dictionary<int, string> {{1, "N100"}, {2, "N100"}, {3, "N200"}, {4, "N200"}}.GroupBy(x => x.Key)
            },
            new object[]
            {
                new Dictionary<int, string> {{1, "N100"}, {2, "N200"}, {3, ""}, {4, "N100" }},
                new Dictionary<int, string> {{1, "N100"}, {4, "N100"}}.GroupBy(x => x.Key)
            }
        };
        
        [Test, TestCaseSource(nameof(_inputList))]
        public void FindDuplicateTest(Dictionary<int, string> input, IEnumerable<IGrouping<int, KeyValuePair<int, string>>> expected)
        {
            Assert.AreEqual(expected, PowerEditExt.FindDuplicate(input));
        }
    }
}
