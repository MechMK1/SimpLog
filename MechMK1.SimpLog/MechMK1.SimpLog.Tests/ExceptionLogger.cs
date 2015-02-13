using System;

namespace MechMK1.SimpLog.Tests
{
	class ExceptionLogger : Logger
	{
		protected override void Write(string message, LogLevel level)
		{
			System.Diagnostics.Debug.WriteLine(message);
			throw new NotImplementedException();
		}
	}
}
