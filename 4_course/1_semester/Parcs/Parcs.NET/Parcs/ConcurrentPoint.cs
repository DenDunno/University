namespace Parcs
{
    internal class ConcurrentPoint : Point
    {
        internal ConcurrentPoint(IJob job, int parentNumber) : base(job, parentNumber) { }

        protected override void Initialize()
        {
            _taskQueue.StartNewTask(LockInitialize);
        }

        private void LockInitialize()
        {
            lock (TaskQueue.syncRoot)
            {
                base.Initialize();
            }
        }

        protected override IChannel CreateNewChannel()
        {
            return new ConcurrentChannel(this, _taskQueue) { From = Number };
        }

        protected override void WriteNumberToChannel()
        {
            _taskQueue.StartNewTask(base.WriteNumberToChannel);
        }

        private readonly TaskQueue _taskQueue = new TaskQueue();        
    }
}
