using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechMK1.SimpLog.Tests
{
	class ConsoleLogger : Logger
	{
		protected override void Write(string message, LogLevel level)
		{
			File.WriteAllText("test.log", message);
		}
	}
}
