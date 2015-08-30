namespace Samaa.API
{
  /// <summary>
  /// Proxy interface for providing <see cref="Plugin"/> implementation
  /// </summary>
  public interface IPluginProxy
  {
    /// <summary>
    /// Get instance of <see cref="Plugin"/> that is intended to be hosted
    /// </summary>
    /// <returns><see cref="Plugin"/> instance</returns>
    Plugin GetPlugin();
  }
}
