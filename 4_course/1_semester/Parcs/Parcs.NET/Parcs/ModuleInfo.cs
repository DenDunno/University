namespace Parcs
{
    public class ModuleInfo
    {
        public IJob CurrentJob { get; private set; }
        public IChannel Parent { get; private set; }

        public ModuleInfo(IJob job, IChannel parent)
        {
            CurrentJob = job;
            Parent = parent;
        }

        public IPoint CreatePoint()
        {
            if (Parent == null)
                return CurrentJob.CreatePoint(0);
            return CurrentJob.CreatePoint(Parent.From);
        }

    }
}
