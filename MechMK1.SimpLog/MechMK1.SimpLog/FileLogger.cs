using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechMK1.SimpLog
{
	/// <summary>
	/// Logger to write to files
	/// </summary>
	public class FileLogger : Logger
	{
		/// <summary>
		/// Path to log file
		/// </summary>
		public string Path { get; set; }

		/// <summary>
		/// Encoding to use. Default is UTF-8
		/// </summary>
		public Encoding Encoding { get; set; }

		/// <summary>
		/// Initializes a new instance of the FileLogger class for the specified file path, with Info LogLevel and UTF-8 encoding.
		/// </summary>
		/// <param name="path">A relative or absolute path for the logfile</param>
		public FileLogger(string path) : this(path, defaultEncoding)
		{
		}



		/// <summary>
		/// Initializes a new instance of the FileLogger class for the specified file path, with specified LogLevel and UTF-8 encoding.
		/// </summary>
		/// <param name="path">A relative or absolute path for the logfile</param>
		/// <param name="logLevel">The minimum LogLevel to write</param>
		public FileLogger(string path, LogLevel logLevel) : this(path, logLevel, defaultEncoding)
		{
		}

		/// <summary>
		/// Initializes a new instance of the FileLogger class for the specified file path, with Info LogLevel and specified encoding.
		/// </summary>
		/// <param name="path">A relative or absolute path for the logfile</param>
		/// <param name="encoding">The encoding to use when writing the logfile</param>
		public FileLogger(string path, Encoding encoding) : this(path, LogLevel.Info, encoding)
		{
		}

		/// <summary>
		/// Initializes a new instance of the FileLogger class for the specified file path, LogLevel and encoding.
		/// </summary>
		/// <param name="path">A relative or absolute path for the logfile</param>
		/// <param name="logLevel">The minimum LogLevel to write</param>
		/// <param name="encoding">The encoding to use when writing the logfile</param>
		public FileLogger(string path, LogLevel logLevel, Encoding encoding)
		{
			this.Path = path;
			this.Encoding = encoding;
			this.MinimumLogLevel = logLevel;
		}

		/// <summary>
		/// Actually writes to the logfile. Logfile will be created if it does not exist.
		/// </summary>
		/// <exception cref="System.IO.IOException">Thrown when shit goes down</exception>
		/// <param name="message">Log message to write to the logfile</param>
		/// <param name="level">Attached parameter to write to the logfile</param>
		protected internal override void Write(string message, LogLevel level)
		{
			if (ShouldLog(level))
			{
				File.AppendAllText(
					this.Path,
					GetFormattedMessage(message, level),
					this.Encoding
				);
			}
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
