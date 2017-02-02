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
    }
}
