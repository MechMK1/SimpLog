using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MechMK1.SimpLog.Tests
{
	[TestClass]
	public class UnitTestSilentLogger
	{
		[TestMethod]
		[ExpectedException(typeof(NotImplementedException))]
		public void TestMethodUncaughtException()
		{
			Logger l = new ExceptionLogger();
			l.Debug("This will throw an exception");
			Assert.Fail("This should not be reached");
		}

		[TestMethod]
		public void TestMethodSilentException()
		{
			Silent<Logger> s = new Silent<Logger>(new ExceptionLogger());
			s.Debug("This will fail silently");
		}
	}
}
