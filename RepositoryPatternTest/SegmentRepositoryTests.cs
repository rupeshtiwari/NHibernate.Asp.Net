using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using RepositoryPattern.Entities;
using RepositoryPattern.SqlNhibernate;

namespace RepositoryPatternTest
{
    [TestClass]
    public class SegmentRepositoryTests
    {
        public string Connection { get; set; }

        public SegmentRepositoryTests()
        {
            Connection = @"Server = .\SQLEXPRESS; Integrated Security = SSPI; User ID=admin;Database= NDEMOTEST";
        }

        [TestMethod]
        public void Can_Insert_New_Testlet_Segment()
        {
            ISession session = null;
            var helper = new NHibernateHelper(Connection);

            SegmentId segmentId;
            var examSectionId = new ExamSectionId(Guid.NewGuid().ToString());
            var testletId = new TestletId(Guid.NewGuid().ToString());

            try
            {
                session = helper.SessionFactory.OpenSession();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            using (session)//insert
            {
                var segmentRepo = new SegmentSqlRepository(session);
                segmentId = segmentRepo.GetNextIdentity();
                var segment = new TestletSegment(segmentId, examSectionId) {SegmentName = "Testlet"};

                segment.AssignTestletContent(testletId);

                segmentRepo.Save(segment);
            }

            session = helper.SessionFactory.OpenSession();
            using (session)//assert
            {
                var segmentRepo = new SegmentSqlRepository(session);
                var testlet = segmentRepo.Get(segmentId);
                Assert.IsNotNull(testlet);
                Assert.IsNotNull(testlet.DeliveryStatus);
            }
        }

        [TestMethod]
        public void Can_Update_Testlet_Segment_DeliveryStatus()
        {

            var helper = new NHibernateHelper(Connection);
            var session = helper.SessionFactory.OpenSession();

            SegmentId segmentId;
            var examSectionId = new ExamSectionId(Guid.NewGuid().ToString());
            var testletId = new TestletId(Guid.NewGuid().ToString());

            using (session)//insert
            {
                var segmentRepo = new SegmentSqlRepository(session);
                segmentId = segmentRepo.GetNextIdentity();
                var segment = new TestletSegment(segmentId, examSectionId) {SegmentName = "Testlet"};

                segment.AssignTestletContent(testletId);
                segmentRepo.Save(segment);
            }

            session = helper.SessionFactory.OpenSession();

            using (session)//fetch & update
            {
                var segmentRepo = new SegmentSqlRepository(session);

                var testlet = segmentRepo.Get(segmentId);
                testlet.Submit(SegmentSubmittedReason.UserQuit);
                segmentRepo.Save(testlet);
            }

            session = helper.SessionFactory.OpenSession();

            using (session)//assert
            {
                var segmentRepo = new SegmentSqlRepository(session);
                var testlet = segmentRepo.Get(segmentId);
                Assert.IsNotNull(testlet);
                Assert.IsNotNull(testlet.DeliveryStatus);
                Assert.AreEqual(SegmentSubmittedReason.UserQuit, testlet.DeliveryStatus.SubmittedReason);
            }
        }


        [TestMethod]
        public void Can_Insert_New_Introduction_Segment()
        {
            ISession session = null;
            var helper = new NHibernateHelper(Connection);

            SegmentId segmentId;
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
                var segmentRepo = new SegmentSqlRepository(session);
                segmentId = segmentRepo.GetNextIdentity();
                var segment = new IntroductionSegment(segmentId, examSectionId)
                {
                    SegmentName = "Introduction Segment",
                };
                segmentRepo.Save(segment);
            }

            session = helper.SessionFactory.OpenSession();
            using (session)//assert
            {
                var segmentRepo = new SegmentSqlRepository(session);
                var introductionSegment = segmentRepo.Get(segmentId);
                Assert.IsNotNull(introductionSegment);
                Assert.IsNotNull(introductionSegment.DeliveryStatus);
            }
        }
    }
}
