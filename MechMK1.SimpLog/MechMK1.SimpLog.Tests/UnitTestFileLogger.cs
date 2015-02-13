using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text.RegularExpressions;

namespace MechMK1.SimpLog.Tests
{
	[TestClass]
	public class UnitTestFileLogger
	{
		static string path = "file.log";
		static string message = "FooBar";
		[TestMethod]
		public void TestMethodReadWrite()
		{
			Assert.IsFalse(File.Exists(path));
			FileLogger l = new FileLogger(path);
			l.Info(message);
			string content = File.ReadAllLines(path, l.Encoding)[0];
			Assert.IsTrue(Regex.IsMatch(content, @"\[.+?\]\ \[\d{4}-\d{2}-\d{2}\ \d{2}:\d{2}:\d{2}\.\d{4}\]:\ (.+)"));
		}

		[TestMethod]
		public void TestMethodAppend()
		{
			Assert.IsFalse(File.Exists(path));
			File.WriteAllText(path, "Filler" + Environment.NewLine);
			Assert.IsTrue(File.Exists(path));
			FileLogger l = new FileLogger(path);
			l.Info(message);
			string content = File.ReadAllLines(path, l.Encoding)[1];
			Assert.IsTrue(Regex.IsMatch(content, @"\[.+?\]\ \[\d{4}-\d{2}-\d{2}\ \d{2}:\d{2}:\d{2}\.\d{4}\]:\ (.+)"));
		}

		[TestInitialize]
		[TestCleanup]
		public void Prepare()
		{
			if (File.Exists(path)) File.Delete(path);
		}
	}
}
