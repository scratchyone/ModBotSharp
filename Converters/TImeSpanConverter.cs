using System.Threading.Tasks;
using DSharpPlus.Entities;
using DSharpPlus.CommandsNext.Converters;
using DSharpPlus.CommandsNext;
using System;
using System.Text.RegularExpressions;

namespace ModBot.Converters
{
    public class TimeSpanConverter : IArgumentConverter<TimeSpan>
    {
        public Task<Optional<TimeSpan>> ConvertAsync(string value, CommandContext ctx)
        {
            var text = value;
            uint cumTimeMs = 0;
            cumTimeMs += toMs(new Regex(@"(\d+) ?mo(nth(s)?)?", RegexOptions.IgnoreCase), ref text, 2592000000);
            cumTimeMs += toMs(new Regex(@"(\d+) ?d(ays(s)?)?", RegexOptions.IgnoreCase), ref text, 86400000);
            cumTimeMs += toMs(new Regex(@"(\d+) ?h(our(s)?)?", RegexOptions.IgnoreCase), ref text, 3600000);
            cumTimeMs += toMs(new Regex(@"(\d+) ?ms", RegexOptions.IgnoreCase), ref text, 1);
            cumTimeMs += toMs(new Regex(@"(\d+) ?m(inute(s)?|min(s)?)?", RegexOptions.IgnoreCase), ref text, 60000);
            cumTimeMs += toMs(new Regex(@"(\d+) ?s(econd(s)?|sec(s)?)?", RegexOptions.IgnoreCase), ref text, 1000);
            return Task.FromResult(Optional.FromValue(TimeSpan.FromMilliseconds(cumTimeMs)));
        }
        uint toMs(Regex regex, ref string text, uint ms)
        {
            var minMatches = regex.Matches(text);
            if (minMatches.Count > 0)
            {
                var t = UInt32.Parse(minMatches[0].Groups[1].Value);
                text = regex.Replace(text, "");
                return t * ms;
            }
            else
            {
                return 0;
            }
        }
    }
}