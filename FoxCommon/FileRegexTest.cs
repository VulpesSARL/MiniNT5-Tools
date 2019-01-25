using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Fox.Common
{
    public class FileRegexTest
    {
        public static bool WildcardMatchesWindowsStyle(string fileName, string pattern)
        {
            var dotdot = pattern.IndexOf("..", StringComparison.Ordinal);
            if (dotdot >= 0)
            {
                for (var i = dotdot; i < pattern.Length; i++)
                    if (pattern[i] != '.')
                        return false;
            }

            var normalized = Regex.Replace(pattern, @"\.+$", "");
            var endsWithDot = normalized.Length != pattern.Length;

            var endWeight = 0;
            if (endsWithDot)
            {
                var lastNonWildcard = normalized.Length - 1;
                for (; lastNonWildcard >= 0; lastNonWildcard--)
                {
                    var c = normalized[lastNonWildcard];
                    if (c == '*')
                        endWeight += short.MaxValue;
                    else if (c == '?')
                        endWeight += 1;
                    else
                        break;
                }

                if (endWeight > 0)
                    normalized = normalized.Substring(0, lastNonWildcard + 1);
            }

            var endsWithWildcardDot = endWeight > 0;
            var endsWithDotWildcardDot = endsWithWildcardDot && normalized.EndsWith(".");
            if (endsWithDotWildcardDot)
                normalized = normalized.Substring(0, normalized.Length - 1);

            normalized = Regex.Replace(normalized, @"(?!^)(\.\*)+$", @".*");

            var escaped = Regex.Escape(normalized);
            string head, tail;

            if (endsWithDotWildcardDot)
            {
                head = "^" + escaped;
                tail = @"(\.[^.]{0," + endWeight + "})?$";
            }
            else if (endsWithWildcardDot)
            {
                head = "^" + escaped;
                tail = "[^.]{0," + endWeight + "}$";
            }
            else
            {
                head = "^" + escaped;
                tail = "$";
            }

            if (head.EndsWith(@"\.\*") && head.Length > 5)
            {
                head = head.Substring(0, head.Length - 4);
                tail = @"(\..*)?" + tail;
            }

            var regex = head.Replace(@"\*", ".*").Replace(@"\?", "[^.]?") + tail;
            return Regex.IsMatch(fileName, regex, RegexOptions.IgnoreCase);
        }
    }
}
