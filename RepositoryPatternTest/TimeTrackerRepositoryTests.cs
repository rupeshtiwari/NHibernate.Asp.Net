using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using RepositoryPattern.Entities;
using RepositoryPattern.SqlNhibernate;

namespace RepositoryPatternTest
{

    [TestClass]
    public class TimeTrackerRepositoryTests
    {
        public string Connection { get; set; }

        public TimeTrackerRepositoryTests()
        {
            Connection = @"Server = .\SQLEXPRESS; Integrated Security = SSPI; User ID=admin;Database= NDEMOTEST";
        }

        [TestMethod]
        public void Can_Insert_New_TimeTracker()
        {
            ISession session = null;
            var helper = new NHibernateHelper(Connection);

            TimeTrackerId timeTrackerId;
            var examSectionId = new ExamSectionId(Guid.NewGuid().ToString());
            try
            {
                session = helper.SessionFactory.OpenSession();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            using (session) //insert
            {
                var timeTrackerSqlRepository = new TimeTrackerSqlRepository(session);
                timeTrackerId = timeTrackerSqlRepository.GetNextIdentity();
                var segment = new TimeTracker(timeTrackerId, examSectionId);
     
                timeTrackerSqlRepository.Save(segment);
            }

            session = helper.SessionFactory.OpenSession();
            using (session)//assert
            {
                var timeTrackerSqlRepository = new TimeTrackerSqlRepository(session);
                var timeTracker = timeTrackerSqlRepository.Get(timeTrackerId);
                Assert.IsNotNull(timeTracker);
            }
        }
    }
}
