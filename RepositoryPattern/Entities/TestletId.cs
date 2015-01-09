namespace RepositoryPattern.Entities
{
    public class TestletId 
    {
        public string TestletGuid { get; private set; }

        internal TestletId() { }

        public TestletId(string testletGuid)
        {
            TestletGuid = testletGuid;

        }
        
    }
}