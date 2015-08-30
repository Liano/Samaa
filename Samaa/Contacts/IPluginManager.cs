using Samaa.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samaa.Contacts
{
  /// <summary>
  /// Interface for interraction with Plugin Managers
  /// </summary>
  public interface IPluginManager
  {
    /// <summary>
    /// Initialize the plugin manager
    /// </summary>
    /// <param name="reporter">Reporter that report the status of initialization</param>
    /// <returns>Future so this Method can be run asyncly</returns>
    Task Initialize(IStatusDisplay reporter);
    /// <summary>
    /// Show plugins manamgement view
    /// </summary>
    /// <returns>Future so this Method can be run asyncly</returns>
    Task ShowPluginManagement();
    /// <summary>
    /// Save current status of loaded plugin
    /// </summary>
    /// <returns>Future so this Method can be run asyncly</returns>
    Task SaveCurrentStatus();
    /// <summary>
    /// Finalize the plugin manager, this method is called before the end of manager's lifetime
    /// </summary>
    /// <param name="reporter">Reporter that report the status of finalization</param>
    /// <returns>Future so this Method can be run asyncly</returns>
    Task Finalize(IStatusDisplay reporter);
  }
}
