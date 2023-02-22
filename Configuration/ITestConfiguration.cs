namespace Configuration
{
    public interface ITestConfiguration
    {
        public Browser Browser { get; }
        public bool Headless { get; }
        public bool StartMaximised { get; }
        public string TestName { get; set; }
    }
}