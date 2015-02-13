using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace MechMK1.SimpLog.Tests
{
	[TestClass]
	public class UnitTestConditionalLogger
	{
		[TestMethod]
		public void TestMethodLogNormally()
		{
			Logger l = new ConsoleLogger();
			l.Debug("This should be written");
			string content = File.ReadAllLines("test.log")[0];
			Assert.AreEqual<string>("This should be written", content);
		}

		[TestMethod]
		public void TestMethodConditionalLog()
		{
			Assert.IsFalse(File.Exists("test.log"));
			ConditionalLoggerWrapper c = new ConditionalLoggerWrapper(new ConsoleLogger(), false);
			c.Debug("This should not be displayed");
			Assert.IsFalse(File.Exists("test.log"));
		}

		[TestInitialize]
		[TestCleanup]
		public void Prepare()
		{
			if(File.Exists("test.log")) File.Delete("test.log");
		}

	}
}
