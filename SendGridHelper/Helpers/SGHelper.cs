using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SendGridHelper.Helpers {
    public static class SGHelper {
        public static bool IsValidEmail(this string email) {
            try {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            } catch {
                return false;
            }
        }

        public static IEnumerable<IEnumerable<T>> SplitList<T>(this IEnumerable<T> locations, int nSize = 30) {
            return locations
                        .Select((x, i) => new { Index = i, Value = x })
                        .GroupBy(x => x.Index / nSize)
                        .Select(x => x.Select(v => v.Value).ToList())
                        .ToList();
        }
    }
}
