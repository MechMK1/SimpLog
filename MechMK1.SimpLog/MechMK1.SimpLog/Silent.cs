using System;

namespace MechMK1.SimpLog
{
	/// <summary>
	/// Wrapper for Loggers. Fails silently and catches ALL(!) Exceptions thrown in wrapped logger
	/// </summary>
	/// <typeparam name="T">The logger to wrap</typeparam>
	public class Silent<T> where T : Logger
	{
		private T logger;
		public Silent(T logger)
		{
			this.logger = logger;
		}

		/// <summary>
		/// Log Debug-information which is diagnostically helpful to people closely involved to development of an application
		/// An example would be any information regarding the current state of the program, a class or a method.
		/// </summary>
		/// <param name="message">Debug message to write to log</param>
		public void Debug(string message)
		{
			try
			{
				this.logger.Debug(message);
			}
			catch (Exception)
			{
				// Nobody can hear your exceptions
			}
		}

		/// <summary>
		/// Log generally useful information.
		/// This should be information which the user or developer always want at hand, but usually don't care about during normal workflow.
		/// An example would be starting or stopping a service, configuration assumptions, etc.
		/// </summary>
		/// <param name="message">Info message to write to log</param>
		public void Info(string message)
		{
			try
			{
				this.logger.Info(message);
			}
			catch (Exception)
			{
				// Nobody can hear your exceptions
			}
		}

		/// <summary>
		/// Log anything that can potentially cause odd behaviour, but which can be automatically recovered from.
		/// An example would be switching to backup servers, retrying operations, missing secondary data, etc.
		/// </summary>
		/// <param name="message">Warning message to write to log</param>
		public void Warning(string message)
		{
			try
			{
				this.logger.Warning(message);
			}
			catch (Exception)
			{
				// Nobody can hear your exceptions
			}
		}

		/// <summary>
		/// Log anything which is fatal to an operation, but not to the service or application.
		/// These errors usually force user intervention.
		/// An example would be insufficient permissions, no network connectivity, etc.
		/// </summary>
		/// <param name="message">Error message to write to log</param>
		public void Error(string message)
		{
			try
			{
				this.logger.Error(message);
			}
			catch (Exception)
			{
				// Nobody can hear your exceptions
			}
		}

		/// <summary>
		/// Log anything that forces a shutdown of the service or application to prevent (further) data loss.
		/// Reserved for only the most viscious errors and situation where data loss/corruption is almost guranteed.
		/// I wish you luck. You'll need it
		/// </summary>
		/// <param name="message">Your applications last words before it will lay down for eternal sleep</param>
		public void Fatal(string message)
		{
			try
			{
				this.logger.Fatal(message);
			}
			catch (Exception)
			{
				// Nobody can hear your exceptions
			}
		}
	}
}
