using System;
using System.Collections.Generic;
using Coypu.Drivers;

namespace Coypu.Finders
{
    internal class FieldsetFinder : XPathQueryFinder
    {
        internal FieldsetFinder(Driver driver, string locator, DriverScope scope) : base(driver, locator, scope) { }

        internal override string QueryDescription
        {
            get { return "fieldset: " + Locator; }
        }

        protected override Func<string, Options, string> GetQuery(XPath xpath)
        {
            return xpath.Fieldset;
        }
    }
}