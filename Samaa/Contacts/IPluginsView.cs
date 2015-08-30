using Samaa.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samaa.Contacts
{
  /// <summary>
  /// Plugins view interaction interface
  /// </summary>
  public interface IPluginsView
  {
    /// <summary>
    /// Show plugins view
    /// </summary>
    /// <param name="pcs">List of plugins to display</param>
    /// <returns>Task so this method can be run asyncly</returns>
    Task Show(List<PluginControl> pcs);
  }
}
