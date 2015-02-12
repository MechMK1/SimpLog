using System;

namespace MechMK1.SimpLog.Tests
{
	class ExceptionLogger : Logger
	{
		protected override void Write(string message, LogLevel level)
		{
			throw new NotImplementedException();
		}
	}
}
