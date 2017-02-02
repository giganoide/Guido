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
        static object[] _findDuplicateTestCaseSource =
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
        
        [Test, TestCaseSource(nameof(_findDuplicateTestCaseSource))]
        public void FindDuplicateTest(Dictionary<int, string> input, IEnumerable<IGrouping<int, KeyValuePair<int, string>>> expected)
        {
            Assert.AreEqual(expected, PowerEditExt.FindDuplicate(input));
        }

        static object[] _getFirstNotOrderedElementTestCaseSource =
        {
            new object[]
            {
                new Dictionary<int, int> {{1, 100}, {2, 200}, {3, 300}},
                default(KeyValuePair<int, int>)
            },
            new object[]
            {
                new Dictionary<int, int> {{1, 100}, {2, 300}, {3, 200}},
                new KeyValuePair<int, int>(3, 200) 
            },
            new object[]
            {
                new Dictionary<int, int> {{1, 200}, {50, 100}},
                new KeyValuePair<int, int>(50, 100)
            },
            new object[]
            {
                new Dictionary<int, int> {{1, 100}, {2, 200}, {4, 50 }, {5, 300 }},
                new KeyValuePair<int, int>(4, 50)
            },
            new object[]
            {
                new Dictionary<int, int> {{1, 100}},
                default(KeyValuePair<int, int>)
            }
        };

        [Test, TestCaseSource(nameof(_getFirstNotOrderedElementTestCaseSource))]
        public void GetFirstNotOrderedElementTest(Dictionary<int, int> input, KeyValuePair<int, int> expected)
        {
            Assert.AreEqual(expected, PowerEditExt.GetFirstNotOrderedElement(input));
        }
    }
}
