using Samaa.API;
using System.Threading.Tasks;

namespace Samaa.Contacts
{
  /// <summary>
  /// Interface for interracting with the view
  /// </summary>
  public interface IView
  {
    /// <summary>
    /// Show a message.
    /// </summary>
    /// <param name="message">message to show</param>
    /// <param name="title">message title</param>
    /// <param name="level">message level</param>
    /// <returns></returns>
    Task ShowMessage(string message, string title, MessageLevel level);
  }
}
