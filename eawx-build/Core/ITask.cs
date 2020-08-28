namespace EawXBuild.Core
{
    public interface ITask
    {
        string Description { get; }
        void Run();
    }
}