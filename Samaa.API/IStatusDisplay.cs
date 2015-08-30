using System.Threading.Tasks;

namespace Samaa.API
{
  /// <summary>
  /// Status change event handler delegate
  /// </summary>
  /// <param name="message">New message</param>
  /// <param name="progress">New progress value (0.0d~1000.0d)</param>
  /// <param name="level">Message level</param>
  public delegate void StatusChangedEventHandler(string message, double progress, MessageLevel level);

  /// <summary>
  /// An interface for reporting execution status
  /// </summary>
  public interface IStatusDisplay
  {
    /// <summary>
    /// Set status message
    /// </summary>
    /// <param name="message">Status message</param>
    /// <returns></returns>
    Task SetStatusMessage(string message, MessageLevel level);
    /// <summary>
    /// Set progress status
    /// </summary>
    /// <param name="progress">progress value. Should be between 0~1000</param>
    /// <returns></returns>
    Task SetStatusProgress(double progress);
    /// <summary>
    /// Event fired when status has changed.
    /// </summary>
    event StatusChangedEventHandler StatusChanged;
  }
}
