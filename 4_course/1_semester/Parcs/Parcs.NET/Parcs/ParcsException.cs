using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parcs
{
    public class ParcsException : Exception
    {
        public ParcsException() { }
        public ParcsException(string message)
        {
            _message = message;
        }

        public override string Message
        {
            get
            {
                return string.IsNullOrEmpty(_message) ? Message : _message;
            }
        }

        string _message = "Parcs-.NET is not the most robust and fault-tolerant system in the world. Keep calm and try once again.";
    }
}
