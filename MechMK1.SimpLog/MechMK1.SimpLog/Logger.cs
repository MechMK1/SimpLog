using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechMK1.SimpLog
{
    public abstract class Logger
    {
		abstract protected void Write(string message, LogLevel level);
    }
}
