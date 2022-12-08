using System;
using System.Collections.Generic;

namespace HostServer
{
    public class JobInfo 
    {
        public int Number { get; private set; }
        private int _lastPointNumber;
        private bool _isFinished;
        private bool _isCancelled;
        public IDictionary<int, IPointInfo> PointDictionary { get; }
        public bool NeedsPoint { get; set; }
        public int Priority { get; set; }
        public DateTime StartTimeUtc { get; }
        public DateTime? FinishTimeUtc { get; private set; }

        public bool IsFinished
        {
            get { return _isFinished; }
            set
            {
                _isFinished = value;
                if (value && !FinishTimeUtc.HasValue)
                {
                    FinishTimeUtc = DateTime.UtcNow;
                }
            }
        }

        public bool IsCancelled
        {
            get { return _isCancelled; }
            set
            {
                _isCancelled = value;
                if (value && !FinishTimeUtc.HasValue)
                {
                    FinishTimeUtc = DateTime.UtcNow;
                }
            }
        }

        public string Username { get; set; }

        public JobInfo(int number)
        {
            PointDictionary = new Dictionary<int, IPointInfo>();
            Number = number;
            StartTimeUtc = DateTime.UtcNow;
        }

        public int AddPoint(IPointInfo pointInfo)
        {
            pointInfo.Number = ++_lastPointNumber;
            PointDictionary.Add(pointInfo.Number, pointInfo);
            ++pointInfo.Host.PointCount;
            NeedsPoint = false;
            return _lastPointNumber;
        }

        public void RemovePoint(int pointNum, bool isCancelling = false)
        {
            IPointInfo pi;
            if (PointDictionary.TryGetValue(pointNum, out pi) && !pi.IsFinished)
            {
                pi.Host.PointCount--;
                if (!isCancelling)
                {
                    pi.IsFinished = true;
                }
            }
        }        
    }
}
