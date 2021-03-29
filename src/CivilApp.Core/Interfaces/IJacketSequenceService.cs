namespace CivilApp.Core.Interfaces
{
    public interface IJacketSequenceService
    {
        bool NeedsSequenceReset();
        void ResetSequence();
    }
}