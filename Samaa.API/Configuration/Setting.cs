using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Samaa.API.Configuration
{
  public class Setting<T>
  {
    /// <summary>
    /// Setting description
    /// </summary>
    public string Description { get; set; }
    /// <summary>
    /// Setting value
    /// </summary>
    public T Value { get; set; }
  }
}
