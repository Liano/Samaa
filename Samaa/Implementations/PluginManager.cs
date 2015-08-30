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

    public PluginManager(IConfiguration configuration)
    {
      if (configuration == null)
        throw new ArgumentNullException("Configuration can not be null");
    }
    public new Task Finalize(IStatusDisplay reporter)
    {
      
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
