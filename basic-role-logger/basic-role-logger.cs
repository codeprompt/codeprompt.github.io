using System;
using System.Collections.Generic;
using System.Linq;

namespace codeprompt.github.io
{
    /// <summary>
    /// Represents a log message role or importance.
    /// </summary>
    public enum eLogType
    {
        Trace,
        Debug,
        Info,
        Warning,
        Error
    }

    /// <summary>
    /// Represents a single log message.
    /// </summary>
    public class LogEntry
    {
        eLogType _type;
        string _message;
        DateTime _timestamp;



        /// <summary>
        /// The importance/role of the log message
        /// </summary>
        public eLogType Type
        {
            get
            {
                return _type;
            }
        }

        /// <summary>
        /// The actual message
        /// </summary>
        public string Message
        {
            get
            {
                return _message;
            }
        }

        /// <summary>
        /// The creation time.
        /// </summary>
        public DateTime TimeStamp
        {
            get
            {
                return _timestamp;
            }
        }



        internal LogEntry(eLogType type, string message)
        {
            _type = type;
            _message = (message == null) ? "" : message;
            _timestamp = DateTime.Now;
        }
        internal LogEntry(DateTime timestamp, eLogType type, string message)
        {
            _timestamp = timestamp;
            _type = type;
            _message = (message == null) ? "" : message;
            _timestamp = DateTime.Now;
        }



        /// <summary>
        /// Get string representation of the log entry, in format TIME[TYPE] : MESSAGE.
        /// </summary>
        /// <param name="dateFormat">
        /// The desired date format string.
        /// For more information see "DateTime.ToString(string format)"
        /// </param>
        /// <returns>The formated message string</returns>
        public string ToFullString(string dateFormat = "HH:mm:ss")
        {
            return _timestamp.ToString(dateFormat) + "[" + _type.ToString() + "] : " + _message;
        }

        /// <summary>
        /// Get string representation of the log entry, in format TIME : MESSAGE.
        /// </summary>
        /// <param name="dateFormat">
        /// The desired date format string.
        /// For more information see "DateTime.ToString(string format)"
        /// </param>
        /// <returns>The formated message string</returns>
        public string ToShortString(string dateFormat = "HH:mm:ss")
        {
            return _timestamp.ToString(dateFormat) + " : " + _message;
        }

        /// <summary>
        /// Get string representation of the log entry, in format MESSAGE.
        /// </summary>
        /// <returns>The formated message string</returns>
        public override string ToString()
        {
            return _message;
        }
    }

    /// <summary>
    /// Simple logger.
    /// </summary>
    public class Logger
    {
        List<LogEntry> _entries;

        /// <summary>
        /// Get all log entries.
        /// </summary>
        public List<LogEntry> Entries
        {
            get
            {
                List<LogEntry> li = new List<LogEntry>();
                lock(_entries)
                {
                    for(int i = 0; i < _entries.Count; i++)
                    {
                        if (_entries[i].Type < OutputVerbosity) continue;
                        li.Add(new LogEntry(_entries[i].TimeStamp, _entries[i].Type, _entries[i].Message));
                    }
                }
                return li;
            }
        }

        /// <summary>
        /// Get all log entries, regardless of verbosity.
        /// </summary>
        public List<LogEntry> AllEntries
        {
            get
            {
                List<LogEntry> li = new List<LogEntry>();
                lock (_entries)
                {
                    for (int i = 0; i < _entries.Count; i++)
                    {
                        li.Add(new LogEntry(_entries[i].TimeStamp, _entries[i].Type, _entries[i].Message));
                    }
                }
                return li;
            }
        }

        /// <summary>
        /// The minimal Log verbosity.
        /// Entries with lower importance will not be logged.
        /// </summary>
        public eLogType LogVerbosity;

        /// <summary>
        /// The minimal Output verbosity.
        /// Entries with lower importance will be logged but will not be outputted.
        /// </summary>
        public eLogType OutputVerbosity;



        /// <summary>
        /// Ctor.
        /// </summary>
        public Logger()
        {
            _entries = new List<LogEntry>();
            LogVerbosity = eLogType.Trace;
            OutputVerbosity = eLogType.Trace;
        }

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="verbosity">
        /// The desired minimum verbocity.
        /// </param>
        public Logger(eLogType verbosity)
        {
            _entries = new List<LogEntry>();
            LogVerbosity = verbosity;
            OutputVerbosity = verbosity;
        }

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="verbosityLog">The desired minimum logging verbocity.</param>
        /// <param name="verbosityOutput">The desired minimum output verbocity.</param>
        public Logger(eLogType verbosityLog, eLogType verbosityOutput)
        {
            _entries = new List<LogEntry>();
            LogVerbosity = verbosityLog;
            OutputVerbosity = verbosityOutput;
        }

        /// <summary>
        /// Clear all logs.
        /// </summary>
        public void Clear()
        {
            lock (_entries)
            {
                _entries = new List<LogEntry>();
            }
        }

        /// <summary>
        /// Log a trace entry. 
        /// Use to log the most trivial stuff.
        /// Usefull while debugging.
        /// </summary>
        /// <param name="message">The log message</param>
        public void LogTrace(string message)
        {
            Log(eLogType.Trace, message);
        }

        /// <summary>
        /// Log a debug entry. 
        /// Use to log debug information.
        /// </summary>
        /// <param name="message">The log message</param>
        public void LogDebug(string message)
        {
            Log(eLogType.Debug, message);
        }

        /// <summary>
        /// Log an info entry. 
        /// Use to log a regular execution information.
        /// </summary>
        /// <param name="message">The log message</param>
        public void LogInfo(string message)
        {
            Log(eLogType.Info, message);
        }

        /// <summary>
        /// Log a warning entry. 
        /// Use to log errors and important information.
        /// </summary>
        /// <param name="message">The log message</param>
        public void LogWarning(string message)
        {
            Log(eLogType.Warning, message);
        }

        /// <summary>
        /// Log an error entry. 
        /// Use to log critical or fatal errors.
        /// </summary>
        /// <param name="message">The log message</param>
        public void LogError(string message)
        {
            Log(eLogType.Error, message);
        }

        /// <summary>
        /// Log an entry. 
        /// </summary>
        /// <param name="type">The type of the log entry</param>
        /// <param name="message">The log message</param>
        public void Log(eLogType type, string message)
        {
            if (LogVerbosity > type) return;
            lock (_entries)
            {
                _entries.Add(new LogEntry(type, message));
            }
        }



        /// <summary>
        /// Get string representation of the log so far, in format TIME[TYPE] : MESSAGE.
        /// </summary>
        /// <param name="dateFormat">
        /// The desired date format string.
        /// For more information see "DateTime.ToString(string format)"
        /// </param>
        /// <returns>The formated log string</returns>
        public string ToFullString(string dateFormat = "HH:mm:ss")
        {
            List<LogEntry> li = Entries;
            if (li.Count == 0) return "";
            else if (li.Count == 1) return li[0].ToFullString(dateFormat);

            string output = li[0].ToFullString(dateFormat);
            for (int i = 1; i < li.Count; i++)
            {
                output += Environment.NewLine + li[i].ToFullString(dateFormat);
            }

            return output;
        }

        /// <summary>
        /// Get string representation of the log so far, in format TIME : MESSAGE.
        /// </summary>
        /// <param name="dateFormat">
        /// The desired date format string.
        /// For more information see "DateTime.ToString(string format)"
        /// </param>
        /// <returns>The formated log string</returns>
        public string ToShortString(string dateFormat = "HH:mm:ss")
        {
            List<LogEntry> li = Entries;
            if (li.Count == 0) return "";
            else if (li.Count == 1) return li[0].ToShortString(dateFormat);

            string output = li[0].ToShortString(dateFormat);
            for (int i = 1; i < li.Count; i++)
            {
                output += Environment.NewLine + li[i].ToShortString(dateFormat);
            }

            return output;
        }

        /// <summary>
        /// Get string representation of the log so far, in format MESSAGE.
        /// </summary>
        /// <returns>The formated log string</returns>
        public override string ToString()
        {
            List<LogEntry> li = Entries;
            if (li.Count == 0) return "";
            else if(li.Count == 1) return li[0].ToString();

            string output = li[0].ToString();
            for(int i = 1; i < li.Count; i++)
            {
                output += Environment.NewLine + li[i].ToString();
            }

            return output;
        }
    }
}
