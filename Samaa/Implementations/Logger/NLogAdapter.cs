using Intelife.Diagnostic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Samaa.Implementations.Logger
{
  public class NLogAdapter : ILogger
  {
    #region Fields
    private NLog.Logger _logger;
    #endregion
    #region Constructors
    public NLogAdapter(NLog.Logger nlogger)
    {
      this._logger = nlogger;
    }
    #endregion
    #region Methods
    public void Log(LogLevel level, string message)
    {
      var le = new NLog.LogEventInfo(GetLevell(level), _logger.Name, message);

      _logger.Log(typeof(NLogAdapter), le);
    }
    public void Log(LogLevel level, string message, params object[] parameters)
    {
      var le = new NLog.LogEventInfo(GetLevell(level)
        , _logger.Name, string.Format(message, parameters));

      _logger.Log(typeof(NLogAdapter), le);
    }
    private static NLog.LogLevel GetLevell(LogLevel level)
    {
      NLog.LogLevel lvl;

      switch (level)
      {
        case LogLevel.Trace:
          lvl = NLog.LogLevel.Trace;
          break;
        case LogLevel.Debug:
          lvl = NLog.LogLevel.Debug;
          break;
        case LogLevel.Info:
          lvl = NLog.LogLevel.Info;
          break;
        case LogLevel.Warning:
          lvl = NLog.LogLevel.Warn;
          break;
        case LogLevel.Error:
          lvl = NLog.LogLevel.Error;
          break;
        case LogLevel.Fatal:
          lvl = NLog.LogLevel.Fatal;
          break;
        default:
          throw new ArgumentException("Invalid log level");
      }

      return lvl;
    }
    public void Log(LogLevel level, string message, Exception exception)
    {
      var le = new NLog.LogEventInfo(GetLevell(level), _logger.Name, message);
      le.Exception = exception;

      _logger.Log(typeof(NLogAdapter), le);
    }
    #endregion
  }
}
