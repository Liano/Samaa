using Samaa.API.Configuration;
using System.Threading.Tasks;

namespace Samaa.API
{
  /// <summary>
  /// Interface for interaction with plugins host
  /// </summary>
  public interface IHost
  {
    #region Properties
    /// <summary>
    /// Host version
    /// </summary>
    string Version { get; }
    #endregion
    #region Methods
    /// <summary>
    /// Log a message to host log records
    /// </summary>
    /// <param name="level">Log message level</param>
    /// <param name="message">The message to log</param>
    /// <param name="plugin">The plugin that is logging the message</param>
    /// <returns>Task object so this method can be run asyncly</returns>
    Task Log(MessageLevel level, string message, Plugin plugin);

    /// <summary>
    /// Save configuration data
    /// </summary>
    /// <param name="config">configuration data to save</param>
    /// <returns>Task object so this method can be run asyncly</returns>
    Task SaveConfiguration(ConfigurationBase config);

    /// <summary>
    /// Get a configuration object
    /// </summary>
    /// <typeparam name="T">configuration type</typeparam>
    /// <returns>Task object with configuration object so this method can be run asyncly</returns>
    Task<T> GetConfiguration<T>() where T : ConfigurationBase;

    /// <summary>
    /// Show a message.
    /// </summary>
    /// <param name="level">Message level</param>
    /// <param name="message">Message to show</param>
    /// <returns>Task object so this method can be run asyncly</returns>
    Task ShowMessage(MessageLevel level, string message, string title); 
    #endregion
  }
}