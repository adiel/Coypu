using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Coypu.Finders
{
    internal class CssFinder : ElementFinder
    {
        private readonly Regex textPattern;
        private readonly string text;

        internal CssFinder(Driver driver, string locator, DriverScope scope)
            : base(driver, locator, scope)
        {
        }

        internal CssFinder(Driver driver, string locator, DriverScope scope, Regex textPattern)
            : this(driver, locator, scope)
        {
            this.textPattern = textPattern;
        }

        internal CssFinder(Driver driver, string locator, DriverScope scope, bool exact, string text)
            : this(driver, locator, scope)
        {
            this.text = text;
        }

        internal override IEnumerable<ElementFound> Find(Options options)
        {
            return Driver.FindAllCss(Locator, Scope, TextPattern(options.Exact));
        }

        private Regex TextPattern(bool exact)
        {
            return textPattern ?? TextAsRegex(text, exact);
        }

        internal override string QueryDescription
        {
            get
            {
                var queryDesciption = "css: " + Locator;
                if (textPattern != null)
                    queryDesciption += " with text matching /" + text ?? textPattern + "/";

                return queryDesciption;
            }
        }

        public static Regex TextAsRegex(string textEquals, bool exact)
        {
            Regex textMatches = null;
            if (textEquals != null)
            {
                var escapedText = Regex.Escape(textEquals);
                if (exact)
                    escapedText = string.Format("^{0}$", escapedText);

                textMatches = new Regex(escapedText, RegexOptions.Multiline);
            }

            return textMatches;
        }
    }
}