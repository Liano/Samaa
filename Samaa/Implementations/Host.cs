using Samaa.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Samaa.API.Configuration;
using System.Threading.Tasks;
using Intelife.Diagnostic;
using Samaa.Helpers;
using Intelife.Configuration;
using Samaa.Contacts;

namespace Samaa.Implementations
{
  public class Host : IHost
  {
    #region Constants
    const string HOST_VERSION = "1.0.0.0"; 
    #endregion
    #region Fields
    static ILogger _logger = GetLogger();
    IConfiguration _configuration;
    IView _view;
    #endregion
    #region Ctors
    public Host(IConfiguration configuration)
    {
      if (configuration == null)
        throw new ArgumentNullException("Configuration is null");

      this._configuration = configuration;
    }
    #endregion
    #region IHost implementation
    string IHost.Version
    {
      get
      {
        return HOST_VERSION;
      }
    }

    Task<T> IHost.GetConfiguration<T>()
    {
      _logger.Log(LogLevel.Debug, "Retrieving configuration: {0}", typeof(T).FullName);

      return Task.Factory.StartNew<T>(() =>
      {
        return this._configuration.GetConfiguration<T>();
      });
    }

    Task IHost.Log(MessageLevel level, string message, Plugin plugin)
    {
      return Task.Factory.StartNew(() =>
      {
        var msg = string.Format("{0}::{1}", plugin.GetType().FullName, message);
        _logger.Log(GetLogLevel(level), msg);
      });
    }

    Task IHost.SaveConfiguration(API.Configuration.ConfigurationBase config)
    {
      if (config == null)
        throw new ArgumentNullException("Configuration to save is null");

      return Task.Factory.StartNew(() =>
      {
        this._configuration.SaveConfig(config);
        _logger.Log(LogLevel.Debug, "Configuration {0} saved", config.Name);
      });
    }

    Task IHost.ShowMessage(MessageLevel level, string message, string title)
    {
      if (this._view == null)
        throw new InvalidOperationException("The view is not yet initialized");

      return Task.Factory.StartNew(() => this._view.ShowMessage(message, title, level));
    }

    /// <summary>
    /// Initializes the host 
    /// </summary>
    /// <param name="view">the view needed for initialization</param>
    public void Initialize(IView view)
    {
      if (view == null)
        throw new ArgumentNullException("view is null");

      this._view = view;
    }
    #endregion
    #region Methods
    private static ILogger GetLogger()
    {
      return new LogManager().CreateLogger(typeof(Host));
    } 
    private static LogLevel GetLogLevel(MessageLevel level)
    {
      switch (level)
      {
        case MessageLevel.Debug:
          return LogLevel.Debug;
        case MessageLevel.Error:
          return LogLevel.Error;
        case MessageLevel.Fatal:
          return LogLevel.Fatal;
        case MessageLevel.Info:
          return LogLevel.Info;
        case MessageLevel.Trace:
          return LogLevel.Trace;
        case MessageLevel.Warning:
          return LogLevel.Warning;
        default:
          throw new ArgumentException("No equivalent log level for the message level");
      }
    }
    #endregion
  }
}
