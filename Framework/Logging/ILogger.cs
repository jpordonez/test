﻿using System;

namespace Framework.Logging
{
    /// <summary>
    /// Supporting Logger levels.
    /// </summary>
    public enum LoggerLevel
    {
        /// <summary>
        /// Logging will be off
        /// </summary>
        Off = 0,
        /// <summary>
        /// Fatal logging level
        /// </summary>
        Fatal = 1,
        /// <summary>
        /// Error logging level
        /// </summary>
        Error = 2,
        /// <summary>
        /// Warn logging level
        /// </summary>
        Warn = 3,
        /// <summary>
        /// Info logging level
        /// </summary>
        Info = 4,
        /// <summary>
        /// Debug logging level
        /// </summary>
        Debug = 5,
    }

    /// <summary>
    /// Manages logging.
    /// </summary>
    /// <remarks>
    /// This is a facade for the different logging subsystems.
    /// It offers a simplified interface that follows IOC patterns
    /// and a simplified priority/level/severity abstraction. 
    /// </remarks>
    public interface ILogger
    {
        #region Debug

        /// <summary>
        /// Logs a debug message.
        /// </summary>
        /// <param name="message">The message to log</param>
        void Debug(String message);

        /// <summary>
        /// Logs a debug message. 
        /// </summary>
        /// <param name="exception">The exception to log</param>
        /// <param name="message">The message to log</param>
        void Debug(String message, System.Exception exception);

        /// <summary>
        /// Logs a debug message.
        /// </summary>
        /// <param name="format">Format string for the message to log</param>
        /// <param name="args">Format arguments for the message to log</param>
        void DebugFormat(String format, params Object[] args);

        /// <summary>
        /// Logs a debug message.
        /// </summary>
        /// <param name="exception">The exception to log</param>
        /// <param name="format">Format string for the message to log</param>
        /// <param name="args">Format arguments for the message to log</param>
        void DebugFormat(System.Exception exception, String format, params Object[] args);

        /// <summary>
        /// Logs a debug message.
        /// </summary>
        /// <param name="formatProvider">The format provider to use</param>
        /// <param name="format">Format string for the message to log</param>
        /// <param name="args">Format arguments for the message to log</param>
        void DebugFormat(IFormatProvider formatProvider, String format, params Object[] args);

        /// <summary>
        /// Logs a debug message.
        /// </summary>
        /// <param name="exception">The exception to log</param>
        /// <param name="formatProvider">The format provider to use</param>
        /// <param name="format">Format string for the message to log</param>
        /// <param name="args">Format arguments for the message to log</param>
        void DebugFormat(System.Exception exception, IFormatProvider formatProvider, String format, params Object[] args);


        /// <summary>
        /// Determines if messages of priority "debug" will be logged.
        /// </summary>
        /// <value>True if "debug" messages will be logged.</value> 
        bool IsDebugEnabled { get; }

        #endregion

        #region Info

        /// <summary>
        /// Logs an info message.
        /// </summary>
        /// <param name="message">The message to log</param>
        void Info(String message);

        /// <summary>
        /// Logs an info message. 
        /// </summary>
        /// <param name="exception">The exception to log</param>
        /// <param name="message">The message to log</param>
        void Info(String message, System.Exception exception);

        /// <summary>
        /// Logs an info message.
        /// </summary>
        /// <param name="format">Format string for the message to log</param>
        /// <param name="args">Format arguments for the message to log</param>
        void InfoFormat(String format, params Object[] args);

        /// <summary>
        /// Logs an info message.
        /// </summary>
        /// <param name="exception">The exception to log</param>
        /// <param name="format">Format string for the message to log</param>
        /// <param name="args">Format arguments for the message to log</param>
        void InfoFormat(System.Exception exception, String format, params Object[] args);

        /// <summary>
        /// Logs an info message.
        /// </summary>
        /// <param name="formatProvider">The format provider to use</param>
        /// <param name="format">Format string for the message to log</param>
        /// <param name="args">Format arguments for the message to log</param>
        void InfoFormat(IFormatProvider formatProvider, String format, params Object[] args);

        /// <summary>
        /// Logs an info message.
        /// </summary>
        /// <param name="exception">The exception to log</param>
        /// <param name="formatProvider">The format provider to use</param>
        /// <param name="format">Format string for the message to log</param>
        /// <param name="args">Format arguments for the message to log</param>
        void InfoFormat(System.Exception exception, IFormatProvider formatProvider, String format, params Object[] args);


        /// <summary>
        /// Determines if messages of priority "info" will be logged.
        /// </summary>
        /// <value>True if "info" messages will be logged.</value> 
        bool IsInfoEnabled { get; }

        #endregion

        #region Warn

        /// <summary>
        /// Logs a warn message.
        /// </summary>
        /// <param name="message">The message to log</param>
        void Warn(String message);

        /// <summary>
        /// Logs a warn message. 
        /// </summary>
        /// <param name="exception">The exception to log</param>
        /// <param name="message">The message to log</param>
        void Warn(String message, System.Exception exception);

        /// <summary>
        /// Logs a warn message.
        /// </summary>
        /// <param name="format">Format string for the message to log</param>
        /// <param name="args">Format arguments for the message to log</param>
        void WarnFormat(String format, params Object[] args);

        /// <summary>
        /// Logs a warn message.
        /// </summary>
        /// <param name="exception">The exception to log</param>
        /// <param name="format">Format string for the message to log</param>
        /// <param name="args">Format arguments for the message to log</param>
        void WarnFormat(System.Exception exception, String format, params Object[] args);

        /// <summary>
        /// Logs a warn message.
        /// </summary>
        /// <param name="formatProvider">The format provider to use</param>
        /// <param name="format">Format string for the message to log</param>
        /// <param name="args">Format arguments for the message to log</param>
        void WarnFormat(IFormatProvider formatProvider, String format, params Object[] args);

        /// <summary>
        /// Logs a warn message.
        /// </summary>
        /// <param name="exception">The exception to log</param>
        /// <param name="formatProvider">The format provider to use</param>
        /// <param name="format">Format string for the message to log</param>
        /// <param name="args">Format arguments for the message to log</param>
        void WarnFormat(System.Exception exception, IFormatProvider formatProvider, String format, params Object[] args);


        /// <summary>
        /// Determines if messages of priority "warn" will be logged.
        /// </summary>
        /// <value>True if "warn" messages will be logged.</value> 
        bool IsWarnEnabled { get; }

        #endregion

        #region Error

        /// <summary>
        /// Logs an error message.
        /// </summary>
        /// <param name="message">The message to log</param>
        void Error(String message);

        /// <summary>
        /// Logs an error message. 
        /// </summary>
        /// <param name="exception">The exception to log</param>
        /// <param name="message">The message to log</param>
        void Error(String message, System.Exception exception);

        /// <summary>
        /// Logs an error message.
        /// </summary>
        /// <param name="format">Format string for the message to log</param>
        /// <param name="args">Format arguments for the message to log</param>
        void ErrorFormat(String format, params Object[] args);

        /// <summary>
        /// Logs an error message.
        /// </summary>
        /// <param name="exception">The exception to log</param>
        /// <param name="format">Format string for the message to log</param>
        /// <param name="args">Format arguments for the message to log</param>
        void ErrorFormat(System.Exception exception, String format, params Object[] args);

        /// <summary>
        /// Logs an error message.
        /// </summary>
        /// <param name="formatProvider">The format provider to use</param>
        /// <param name="format">Format string for the message to log</param>
        /// <param name="args">Format arguments for the message to log</param>
        void ErrorFormat(IFormatProvider formatProvider, String format, params Object[] args);

        /// <summary>
        /// Logs an error message.
        /// </summary>
        /// <param name="exception">The exception to log</param>
        /// <param name="formatProvider">The format provider to use</param>
        /// <param name="format">Format string for the message to log</param>
        /// <param name="args">Format arguments for the message to log</param>
        void ErrorFormat(System.Exception exception, IFormatProvider formatProvider, String format, params Object[] args);


        /// <summary>
        /// Determines if messages of priority "error" will be logged.
        /// </summary>
        /// <value>True if "error" messages will be logged.</value> 
        bool IsErrorEnabled { get; }

        #endregion

        #region Fatal

        /// <summary>
        /// Logs a fatal message.
        /// </summary>
        /// <param name="message">The message to log</param>
        void Fatal(String message);

        /// <summary>
        /// Logs a fatal message. 
        /// </summary>
        /// <param name="exception">The exception to log</param>
        /// <param name="message">The message to log</param>
        void Fatal(String message, System.Exception exception);

        /// <summary>
        /// Logs a fatal message.
        /// </summary>
        /// <param name="format">Format string for the message to log</param>
        /// <param name="args">Format arguments for the message to log</param>
        void FatalFormat(String format, params Object[] args);

        /// <summary>
        /// Logs a fatal message.
        /// </summary>
        /// <param name="exception">The exception to log</param>
        /// <param name="format">Format string for the message to log</param>
        /// <param name="args">Format arguments for the message to log</param>
        void FatalFormat(System.Exception exception, String format, params Object[] args);

        /// <summary>
        /// Logs a fatal message.
        /// </summary>
        /// <param name="formatProvider">The format provider to use</param>
        /// <param name="format">Format string for the message to log</param>
        /// <param name="args">Format arguments for the message to log</param>
        void FatalFormat(IFormatProvider formatProvider, String format, params Object[] args);

        /// <summary>
        /// Logs a fatal message.
        /// </summary>
        /// <param name="exception">The exception to log</param>
        /// <param name="formatProvider">The format provider to use</param>
        /// <param name="format">Format string for the message to log</param>
        /// <param name="args">Format arguments for the message to log</param>
        void FatalFormat(System.Exception exception, IFormatProvider formatProvider, String format, params Object[] args);


        /// <summary>
        /// Determines if messages of priority "fatal" will be logged.
        /// </summary>
        /// <value>True if "fatal" messages will be logged.</value> 
        bool IsFatalEnabled { get; }

        #endregion

        /// <summary>
        /// Create a new child logger.
        /// The name of the child logger is [current-loggers-name].[passed-in-name]
        /// </summary>
        /// <param name="loggerName">The Subname of this logger.</param>
        /// <returns>The New ILogger instance.</returns> 
        /// <exception cref="System.ArgumentException">If the name has an empty element name.</exception>
        ILogger CreateChildLogger(String loggerName);
    }
}
