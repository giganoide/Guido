using System.Collections.Generic;
using System.Linq;

namespace Guido
{
    public class PowerEditExt
    {
        public static IEnumerable<IGrouping<int, KeyValuePair<int, string>>> FindDuplicate(Dictionary<int, string> rows)
        {
            var rowsDuplicated = rows.GroupBy(x => x.Value).Where(group => group.Count() > 1).Select(x => x.Key);
            var result = new Dictionary<int, string>();
            foreach (var row in rowsDuplicated)
                foreach (var item in rows.ToList().FindAll(x => x.Value == row))
                    result.Add(item.Key, item.Value);
            return result.GroupBy(x => x.Key);
        }

        public static KeyValuePair<int, int> GetFirstNotOrderedElement(Dictionary<int, int> rows)
        {
            var ordered = rows.OrderBy(d => d.Value).ToList();
            var list = rows.ToList();

            for (var j = 0; j < rows.Count; j++)
                if (list[j].Value != ordered[j].Value)
                    return ordered[j];
            
            return default(KeyValuePair<int, int>);
        }
    }
}
