namespace RepositoryPattern.Entities
{
    public enum SegmentSubmittedReason
    {
        NotSet,
        CompletedSuccessfully,
        UserQuit,
        Timeout,
        AuthenticationError,
        Return,
        UnscheduledBreak,
        OffTheClockBreak
    }
}