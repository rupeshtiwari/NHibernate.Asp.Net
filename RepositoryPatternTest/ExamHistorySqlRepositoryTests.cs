using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using RepositoryPattern.Entities;
using RepositoryPattern.SqlNhibernate;

namespace RepositoryPatternTest
{
    [TestClass]
    public class ExamHistorySqlRepositoryTests
    {
        public string Connection { get; set; }

        public ExamHistorySqlRepositoryTests()
        {
            Connection = @"Server = .\SQLEXPRESS; Integrated Security = SSPI; User ID=admin;Database= NDEMOTEST";
        }

        [TestMethod]
        public void Can_Insert_New_ExamHistory()
        {
            ISession session = null;
            var helper = new NHibernateHelper(Connection);

            var examSectionId = new ExamSectionId(Guid.NewGuid().ToString());
            try
            {
                session = helper.SessionFactory.OpenSession();
            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException.Message);
            }

            using (session) //insert
            {
                var examHistorySqlRepository = new ExamHistorySqlRepository(session);
                var examHistoryId = examHistorySqlRepository.GetNextIdentity();
                var examHistory = new ExamHistory(examHistoryId, examSectionId);

                examHistorySqlRepository.Save(examHistory);
            }

            session = helper.SessionFactory.OpenSession();
            using (session)//assert
            {
                var examHistorySqlRepository = new ExamHistorySqlRepository(session);
                var examHistory = examHistorySqlRepository.Get(examSectionId);
                Assert.IsNotNull(examHistory);
            }
        }

        [TestMethod]
        public void Can_Insert_New_ExamHistory_With_Entries()
        {
            ISession session = null;
            var helper = new NHibernateHelper(Connection);

            var examSectionId = new ExamSectionId(Guid.NewGuid().ToString());
            try
            {
                session = helper.SessionFactory.OpenSession();
            }
            catch (Exception ex)
            {
                Console.Write(ex.InnerException.Message);
            }

            using (session) //insert
            {
                var examHistorySqlRepository = new ExamHistorySqlRepository(session);
                var examHistoryId = examHistorySqlRepository.GetNextIdentity();
                var examHistory = new ExamHistory(examHistoryId, examSectionId);

                examHistory.Entries.Add(new SegmentSubmitted(new TestletSegment(new SegmentId("afd"), examSectionId)));

                examHistorySqlRepository.Save(examHistory);
            }

            session = helper.SessionFactory.OpenSession();
            using (session)//assert
            {
                var examHistorySqlRepository = new ExamHistorySqlRepository(session);
                var examHistory = examHistorySqlRepository.Get(examSectionId);
                Assert.IsNotNull(examHistory);
            }
        }

    }
}
