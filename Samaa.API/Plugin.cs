using System;
using System.Threading.Tasks;

namespace Samaa.API
{
  /// <summary>
  /// Different possible statuses of a plugin
  /// </summary>
  public enum PluginStatus
  {
    /// <summary>
    /// Plugin is running normally
    /// </summary>
    Running,
    /// <summary>
    /// Plugin is stopped.
    /// </summary>
    Stopped,
    /// <summary>
    /// Plugin is running but paused.
    /// </summary>
    Paused,
    /// <summary>
    /// Plugin run has error
    /// </summary>
    Error
  }
  /// <summary>
  /// Abstract class that defines behavior needed to be implemented by inheriting plugins.
  /// </summary>
  public abstract class Plugin : MarshalByRefObject
  {
    #region Properties
    /// <summary>
    /// Get API version, the implementation should return "1.0"
    /// </summary>
    public abstract string APIVersion
    {
      get;
    }
    /// <summary>
    /// Get version of the plugin
    /// </summary>
    public abstract string Version { get; }
    /// <summary>
    /// Get plugin status
    /// </summary>
    public abstract PluginStatus Status { get; }
    /// <summary>
    /// Get the name of the plugin
    /// </summary>
    public abstract string Name { get; }
    /// <summary>
    /// Get plugin GUID.
    /// </summary>
    public abstract string GUID { get; }
    #endregion
    #region Methods
    /// <summary>
    /// Show informations about the plugin.
    /// Can be run asyncly.
    /// </summary>
    /// <returns></returns>
    public abstract Task About();
    /// <summary>
    /// Initializes the plugin.
    /// Can be run asyncly.
    /// </summary>
    /// <param name="host">Host of the plugin</param>
    /// <returns></returns>
    public abstract Task Initialize(IHost host);
    /// <summary>
    /// Stop plugin if it's running, this can be done asyncly.
    /// </summary>
    /// <param name="reporter">Reporter used to report action status</param>
    /// <returns></returns>
    public abstract Task Stop(IStatusDisplay reporter);
    /// <summary>
    /// Start execution of the plugin
    /// Can be run asyncly
    /// </summary>
    /// <param name="reporter">Reporter used to report action status</param>
    /// <returns></returns>
    public abstract Task Start(IStatusDisplay reporter);
    /// <summary>
    /// Pause the execution of the plugin, this will not stop plugin from running
    /// this gives the ability to resume run of plugin afterwards.
    /// Can be called asyncly
    /// </summary>
    /// <param name="reporter">Reporter used to report action status</param>
    /// <returns></returns>
    public abstract Task Pause(IStatusDisplay reporter);
    /// <summary>
    /// Resume plugin execution, this should typically be called after plugin is paused.
    /// Can be called asyncly.
    /// </summary>
    /// <param name="reporter">Reporter used to report action status</param>
    /// <returns></returns>
    public abstract Task Resume(IStatusDisplay reporter);
    /// <summary>
    /// Reset plugin to its default state. Can also be called in case the plugin has execution problems.
    /// Can be run asyncly
    /// </summary>
    /// <param name="reporter">Reporter used to report action status</param>
    /// <returns></returns>
    public abstract Task Reset(IStatusDisplay reporter);
    /// <summary>
    /// Uninstall the plugin, typically the plugin has to remove anything related to it when this method is called.
    /// Can be run asyncly
    /// </summary>
    /// <param name="reporter">Reporter used to report action status</param>
    /// <returns></returns>
    public abstract Task Uninstall(IStatusDisplay reporter);
    /// <summary>
    /// Configure plugin options, this is called to show plugin configuration to the user.
    /// Can be run asyncly
    /// </summary>
    /// <returns></returns>
    public abstract Task Configure();
    #endregion
  }
}
