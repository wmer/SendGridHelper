using System;
using System.Collections.Generic;
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

        public static List<List<T>> SplitList<T>(this List<T> locations, int nSize = 30) {
            var list = new List<List<T>>();
            for (int i = 0; i < locations.Count; i += nSize) {
                list.Add(locations.GetRange(i, Math.Min(nSize, locations.Count - i)));
            }

            return list;
        }
    }
}
