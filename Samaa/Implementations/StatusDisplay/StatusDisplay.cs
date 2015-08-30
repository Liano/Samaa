using Samaa.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Samaa.Implementations.StatusDisplay
{
  /// <summary>
  /// An IStatusDisplay implementation that shows displays status using a ProgressBar and a Label
  /// </summary>
  public class StatusDisplay : IStatusDisplay
  {
    #region Fields
    double _currentProgress;
    string _currentMessage;
    MessageLevel _currentMessageLevel; 
    #endregion
    #region Events
    public event StatusChangedEventHandler StatusChanged;
    #endregion
    #region IStatusDisplay implementation
    Task IStatusDisplay.SetStatusMessage(string message, MessageLevel level)
    {
      return Task.Factory.StartNew(() =>
      {
        this._currentMessage = message;
        this._currentMessageLevel = level;

        if (this.StatusChanged != null)
          this.FireStatusChangedEvent();
      });
    }
    Task IStatusDisplay.SetStatusProgress(double progress)
    {
      return Task.Factory.StartNew(() =>
      {
        this._currentProgress = progress;
        if (this.StatusChanged != null)
          this.FireStatusChangedEvent();
      });
    }
    #endregion
    #region Methods
    private void FireStatusChangedEvent()
    {
      this.StatusChanged(this._currentMessage, this._currentProgress, this._currentMessageLevel);
    } 
    #endregion
  }
}
