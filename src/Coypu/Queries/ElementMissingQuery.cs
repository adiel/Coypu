namespace Coypu.Queries
{
    internal class ElementMissingQuery : DriverScopeQuery<bool>
    {
        public override bool ExpectedResult
        {
            get { return true; }
        }

        protected internal ElementMissingQuery(DriverScope driverScope, Options options)
            : base(driverScope, options)
        {
        }

        public override bool Run()
        {
            try
            {
                DriverScope.FindNow();
                return false;
            }
            catch (MissingHtmlException)
            {
                return true;
            }
            catch (MissingWindowException)
            {
                return true;
            }
        }
    }
}