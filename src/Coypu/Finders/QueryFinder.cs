namespace Coypu.Finders
{
    internal abstract class QueryFinder : ElementFinder
    {
        protected QueryFinder(Driver driver, string locator, DriverScope scope) : base(driver, locator, scope)
        {
        }
    }
}