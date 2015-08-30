using Samaa.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samaa.Contacts
{
  /// <summary>
  /// Interface for interraction with plugin provider
  /// </summary>
  public interface IPluginsProvider
  {
    /// <summary>
    /// Get list of available plugins
    /// </summary>
    /// <returns>Task of list of Plugin</returns>
    Task<List<Plugin>> GetPlugins();
  }
}
