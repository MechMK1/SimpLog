using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechMK1.SimpLog
{
	public class FileLogger : Logger
	{
		public string Path { get; set; }
		public Encoding Encoding { get; set; }

		public FileLogger(string path) : this(path, defaultEncoding)
		{
		}

		public FileLogger(string path, Encoding encoding)
		{
			this.Path = path;
			this.Encoding = encoding;
		}

		protected internal override void Write(string message, LogLevel level)
		{
			File.AppendAllText(
				this.Path,
				GetFormattedMessage(message, level),
				this.Encoding
			);
		}

		#region Helpers
		private static string GetFormattedMessage(string message, LogLevel level)
		{
			return string.Format(
				CultureInfo.InvariantCulture,
				"[{0}] [{1}]: {2}{3}",
				GetFormattedLogLevel(level),
				DateTime.Now.ToString(
					"yyyy-MM-dd HH:mm:ss.ffff",
					CultureInfo.InvariantCulture
				),
				message,
				Environment.NewLine
			);
		}

		private static string GetFormattedLogLevel(LogLevel level)
		{
			switch (level)
			{
				case LogLevel.Debug:
				case LogLevel.Info:
				case LogLevel.Warning:
				case LogLevel.Error:
					return level.ToString().ToUpperInvariant();
				case LogLevel.Fatal:
					return "--- F A T A L ---";
				default:
					throw new ArgumentOutOfRangeException("level");
			}
		}
		#endregion Helpers

		private static Encoding defaultEncoding = Encoding.UTF8;
	}
}
