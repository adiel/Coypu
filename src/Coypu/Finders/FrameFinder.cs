using System.Collections.Generic;
using System.ComponentModel;

namespace Coypu.Finders
{
    internal class FrameFinder : ElementFinder
    {
        internal FrameFinder(Driver driver, string locator, DriverScope scope) : base(driver, locator, scope) { }

        internal override IEnumerable<ElementFound> Find(Options options = null)
        {
            return new [] {Driver.FindFrame(Locator, Scope)};
        }

        internal override string QueryDescription
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}