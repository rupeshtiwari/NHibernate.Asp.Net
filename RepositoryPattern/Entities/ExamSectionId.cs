namespace RepositoryPattern.Entities
{
    public class ExamSectionId 
    {
        public virtual string ExamGuid { get; private set; }
        public static readonly int MaximumLength = 4000;
        internal ExamSectionId() { }

        public ExamSectionId(string examGuid)
        {
            ExamGuid = examGuid;
        }
    }
}