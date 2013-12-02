using System.Collections.Generic;

namespace Coypu.Finders
{
    internal class DocumentElementFinder : ElementFinder
    {
        public DocumentElementFinder(Driver driver) : base(driver, "Window",null)
        {
        }

        internal override IEnumerable<ElementFound> Find(Options options = null)
        {
            return new [] {Driver.Window};
        }

        internal override string QueryDescription
        {
            get { return "Document Element"; }
        }
    }
}