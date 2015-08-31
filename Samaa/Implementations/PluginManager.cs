using Samaa.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Samaa.API;
using System.Threading.Tasks;
using Intelife.Configuration;

namespace Samaa.Implementations
{
  public class PluginManager : IPluginManager
  {
    IConfiguration _configuration;
    List<Plugin> _plugins;
    IHost _host;

    public PluginManager(IConfiguration configuration, IHost host)
    {
      if (configuration == null)
        throw new ArgumentNullException("Configuration can not be null");

      if (host == null)
        throw new ArgumentNullException("host");

      this._configuration = configuration;
      this._host = host;

      this._plugins = new List<Plugin>();
    }
    public Task Finalize(IStatusDisplay reporter)
    {
      if (reporter == null)
        throw new ArgumentNullException("IStatusDisplay can not be null");

      return Task.Factory.StartNew(async () =>
      {
        if (this._plugins.Count == 0)
        {
          reporter.SetStatusMessage("Finalization done", MessageLevel.Info);
          reporter.SetStatusProgress(1000d);
        }else
        {
          for (int i = 0; i < this._plugins.Count; i++)
          {
            var plugin = this._plugins[i];
            await this.FinalizePlugin(plugin, reporter);
          }
        }
      });
    }

    /// <summary>
    /// finalize plugin
    /// save its status for later initialization
    /// shutdown the plugin
    /// </summary>
    /// <param name="plugin">the plugin to finalize</param>
    private Task FinalizePlugin(Plugin plugin, IStatusDisplay reporter)
    {
      //delegate method called when the task fails
      var OnPluginStopFail = new Action<Task>(t =>
      {
        var msg = string.Format("Error stopping plugin: {0}", t.Exception.Message);
        this._host.Log(MessageLevel.Warning
          , msg
          , plugin);
      });

      return Task.Factory.StartNew(() =>
      {
        //TODO finish this see above.
        //TODO save plugin status

        //stop plugin
        var stopTask = plugin.Stop(reporter);
        stopTask.ContinueWith(OnPluginStopFail, TaskContinuationOptions.OnlyOnFaulted);
      });

    }

    public Task Initialize(IStatusDisplay reporter)
    {
      throw new NotImplementedException();
    }

    public Task SaveCurrentStatus()
    {
      throw new NotImplementedException();
    }

    public Task ShowPluginManagement()
    {
      throw new NotImplementedException();
    }
  }
}
