namespace RepositoryPattern.Entities.Interfaces
{
    public interface ISegmentRepository : IRepository<Segment>
    {
        Segment Get(SegmentId segmentId);
        SegmentId GetNextIdentity();
        void Save(Segment segment);
    }
}