namespace Samaa.API
{
  /// <summary>
  /// Message types or level
  /// </summary>
  public enum MessageLevel
  {
    /// <summary>
    /// Indicate that message is a debug message
    /// </summary>
    Debug,
    /// <summary>
    /// Indicate that message is an error message
    /// </summary>
    Error,
    /// <summary>
    /// Indicate that message is a fatal error message
    /// </summary>
    Fatal,
    /// <summary>
    /// Indicate that message is an information message
    /// </summary>
    Info,
    /// <summary>
    /// Indicate that message is a trace message
    /// </summary>
    Trace,
    /// <summary>
    /// Indicate that message is a warning message
    /// </summary>
    Warning
  }
}
