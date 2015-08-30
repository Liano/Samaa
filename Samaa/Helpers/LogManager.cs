using Intelife.Diagnostic;
using Samaa.Implementations.Logger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Samaa.Helpers
{
  /// <summary>
  /// Preconfigured log instance factory
  /// </summary>
  public class LogManager
  {
    #region Constents
    private const string LOG_CONFIG = "LOG.CFG";
    #endregion
    #region Fields
    static bool _logManagerConfigured = false; 
    #endregion
    #region Methods
    /// <summary>
    /// Create logger
    /// </summary>
    /// <param name="t">type for which logger will be created</param>
    /// <returns>Concret ILogger implementation</returns>
    public ILogger CreateLogger(Type t)
    {
      if (!_logManagerConfigured)
      {
        this.Configure();
        _logManagerConfigured = true;
      }

      var log = NLog.LogManager.GetLogger(t.FullName);
      var logger = new NLogAdapter(log);

      //Log
      logger.Log(LogLevel.Debug, "New logger instance initialized");
      return logger;
    }
    private void Configure()
    {
      var logConfig = Path.Combine(this.GetCurrentFolder(), LOG_CONFIG);
      NLog.LogManager.Configuration =
        new NLog.Config.XmlLoggingConfiguration(logConfig, false);

    }
    private void BackupConfiguration()
    {
      NLog.Config.SimpleConfigurator.ConfigureForConsoleLogging();
    }
    
    public void RemoveRichTextBoxTarget()
    {
      NLog.LogManager.Configuration.RemoveTarget("rtbTarget");
    }
    private string GetCurrentFolder()
    {
      return System.AppDomain.CurrentDomain.BaseDirectory;
    }
    #endregion
  }
}
