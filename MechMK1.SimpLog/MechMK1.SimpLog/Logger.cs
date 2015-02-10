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

		public void Debug(string message)
		{
			Write(message, LogLevel.Debug);
		}

		public void Info(string message)
		{
			Write(message, LogLevel.Info);
		}

		public void Warning(string message)
		{
			Write(message, LogLevel.Warning);
		}

		public void Error(string message)
		{
			Write(message, LogLevel.Error);
		}

		public void Fatal(string message)
		{
			Write(message, LogLevel.Fatal);
		}
    }
}
