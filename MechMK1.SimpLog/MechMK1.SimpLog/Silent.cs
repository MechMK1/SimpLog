using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechMK1.SimpLog
{
	public class Silent<T> where T : Logger
	{
		private T logger;
		public Silent(T logger)
		{
			this.logger = logger;
		}

		private void Write(string message, LogLevel level)
		{
			try
			{
				this.logger.Write(message, level);
			}
			catch (Exception)
			{
				// Nobody can hear your exceptions
			}
		}

		/// <summary>
		/// Log Debug-information which is diagnostically helpful to people closely involved to development of an application
		/// An example would be any information regarding the current state of the program, a class or a method.
		/// </summary>
		/// <param name="message">Debug message to write to log</param>
		public virtual void Debug(string message)
		{
			Write(message, LogLevel.Debug);
		}

		/// <summary>
		/// Log generally useful information.
		/// This should be information which the user or developer always want at hand, but usually don't care about during normal workflow.
		/// An example would be starting or stopping a service, configuration assumptions, etc.
		/// </summary>
		/// <param name="message">Info message to write to log</param>
		public virtual void Info(string message)
		{
			Write(message, LogLevel.Info);
		}

		/// <summary>
		/// Log anything that can potentially cause odd behaviour, but which can be automatically recovered from.
		/// An example would be switching to backup servers, retrying operations, missing secondary data, etc.
		/// </summary>
		/// <param name="message">Warning message to write to log</param>
		public virtual void Warning(string message)
		{
			Write(message, LogLevel.Warning);
		}

		/// <summary>
		/// Log anything which is fatal to an operation, but not to the service or application.
		/// These errors usually force user intervention.
		/// An example would be insufficient permissions, no network connectivity, etc.
		/// </summary>
		/// <param name="message">Error message to write to log</param>
		public virtual void Error(string message)
		{
			Write(message, LogLevel.Error);
		}

		/// <summary>
		/// Log anything that forces a shutdown of the service or application to prevent (further) data loss.
		/// Reserved for only the most viscious errors and situation where data loss/corruption is almost guranteed.
		/// I wish you luck. You'll need it
		/// </summary>
		/// <param name="message">Your applications last words before it will lay down for eternal sleep</param>
		public virtual void Fatal(string message)
		{
			Write(message, LogLevel.Fatal);
		}
	}
}
