using TechTalk.SpecFlow;

namespace Core.SpecFlow
{
    public class AbstractSteps<T>
    {
        public T Context
        {
            get { return ScenarioContext.Current.Get<T>(); }
            set { ScenarioContext.Current.Set(value); }
        }
    }
}