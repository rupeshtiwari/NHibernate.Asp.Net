using RepositoryPattern.Entities;
using RepositoryPattern.SqlNhibernate;

namespace RepositoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            SaveTestlet();
            FetchTestlet();
        }

        private static void FetchTestlet()
        {

            var segmentRepo = SegmentSqlRepository();

            var segment = segmentRepo.Get(new SegmentId("2"));

        }

        private static void SaveTestlet()
        {
            var segment = new TestletSegment(new SegmentId("2"), new ExamSectionId("43")) {SegmentName = "Testlet"};

            var segmentRepo = SegmentSqlRepository();

            segmentRepo.Save(segment);
        }

        private static SegmentSqlRepository SegmentSqlRepository()
        {
            var helper = new NHibernateHelper();

            var sessionFactory = helper.SessionFactory;

            var segmentRepo = new SegmentSqlRepository(sessionFactory.OpenSession());
            return segmentRepo;
        }
    }
}
