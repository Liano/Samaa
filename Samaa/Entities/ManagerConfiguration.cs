using Samaa.API.Configuration;
using System;
using System.Linq;
using Intelife.Configuration;
using Samaa.API;
using System.Collections.Generic;

namespace Samaa.Entities
{
  public class ManagerConfiguration : API.Configuration.ConfigurationBase
  {
    public override string Name
    {
      get; set;
    }
    public Dictionary<string, PluginStatus> PluginStatuses { get; set; }
    public ManagerConfiguration()
    {
      this.PluginStatuses = new Dictionary<string, PluginStatus>();
    }
  }
}
