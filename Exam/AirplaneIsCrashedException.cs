using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017._10._07_exam
{
    [System.Serializable]
    public class AirplaneIsCrashedException : Exception
    {
        public AirplaneIsCrashedException() { }
        public AirplaneIsCrashedException(string message) : base(message) { }
        public AirplaneIsCrashedException(string message, Exception inner) : base(message, inner) { }
        protected AirplaneIsCrashedException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }    
}
