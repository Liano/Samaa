
using DryIoc;
using Samaa.Contacts;
using Intelife.Configuration;
using Samaa.Implementations;
using Samaa.API;
using Samaa.Implementations.StatusDisplay;

namespace Samaa
{
  public static class IoCC
  {
    static Container _container;
    /// <summary>
    /// IoC container singlton instance
    /// </summary>
    public static Container O
    {
      get
      {
        if (_container == null)
        {
          _container = new Container();

          //register types
          RegisterTypes();

          //register instances
          RegisterInstances();

        }

        return _container;
      }
    }
    private static void RegisterTypes()
    {
      if (_container != null)
      {
        _container.Register<FrmMain>(reuse: Reuse.Singleton);
        _container.Register<IObjectSerializer, JsonSerializer>(reuse: Reuse.Singleton);
        _container.Register<IConfiguration, Configuration>(reuse: Reuse.Singleton);
        _container.Register<IHost, Host>(reuse: Reuse.Singleton);
        _container.Register<IStatusDisplay, StatusDisplay>();
      }
    }
    private static void RegisterInstances()
    {
      if (_container != null)
      {
        //register main GUI
        _container.RegisterInstance<IView>(_container.Resolve<FrmMain>(), Reuse.Singleton);
      }
    }
    /// <summary>
    /// Register the object to default IoC container
    /// </summary>
    /// <typeparam name="T">Type as which register the object</typeparam>
    /// <param name="o">Object to register to container</param>
    /// <param name="key">Object identification key used for resolving the instance</param>
    public static void RegisterInstance<T>(this object o, object key = null)
    {
      O.RegisterInstance<T>((T)o, Reuse.Singleton, serviceKey: key);
    }
  }

  /// <summary>
  /// Static class that contains Keys used for object resolution for the IOC container.
  /// </summary>
  public static class IoCCKeys
  {
    /// <summary>
    /// Plugins view status message label key
    /// </summary>
    public static string PluginsViewStatusMessageLabel { get { return "PluginsViewStatusMessageLabel"; } }
  }
}
