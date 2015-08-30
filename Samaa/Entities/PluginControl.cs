using Samaa.API;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Samaa.Entities
{
  /// <summary>
  /// Display and control plugin
  /// </summary>
  public class PluginControl
  {
    /// <summary>
    /// Name of the plugin
    /// </summary>
    public string Name { get; private set; }
    /// <summary>
    /// Version of the plugin
    /// </summary>
    public string Version { get; private set; }
    /// <summary>
    /// Image of plugin status
    /// </summary>
    public Image Status
    {
      get
      {
        Image statusImg = null;

        switch (this.PlugIn.Status)
        {
          case PluginStatus.Running:
            statusImg = Properties.Resources.Play;
            break;
          case PluginStatus.Stopped:
            statusImg = Properties.Resources.Stop;
            break;
          case PluginStatus.Paused:
            statusImg = Properties.Resources.Pause;
            break;
          case PluginStatus.Error:
            statusImg = Properties.Resources.Error;
            break;
        }

        return statusImg;
      }
    }
    /// <summary>
    /// The plugin instance to which this instance is bound
    /// </summary>
    internal Plugin PlugIn { get; private set; }
    public PluginControl(Plugin plugin)
    {
      this.PlugIn = plugin;
      this.Name = plugin.Name;
      this.Version = plugin.Version;
    }
  }
}
