using Samaa.API;
using Samaa.Contacts;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Samaa
{
  enum MessageTarget
  {
    MessageBox,
    ToolTip,
    None
  }
  public partial class FrmMain : Form, IView
  {
    MessageTarget _messageTarget = MessageTarget.MessageBox;

    public FrmMain()
    {
      InitializeComponent();
    }

    public Task ShowMessage(string message, string title, MessageLevel level)
    {
      //TODO:Need to implement tooltip and message logging in case for none
      return Task.Factory.StartNew(() =>
      {
        switch (this._messageTarget)
        {
          case MessageTarget.MessageBox:
            if (this.InvokeRequired)
            {
              this.Invoke(new Action(() =>
              {
                MessageBox.Show(message, title, MessageBoxButtons.OK, FrmMain.GetIcon(level));
              }));
            }
            else
              MessageBox.Show(message, title, MessageBoxButtons.OK, FrmMain.GetIcon(level));
            break;
          case MessageTarget.ToolTip:
            break;
          case MessageTarget.None:
            break;
          default:
            break;
        }

      });
    }
    #region Methods
    private static MessageBoxIcon GetIcon(MessageLevel mlevel)
    {
      MessageBoxIcon mbi = MessageBoxIcon.None;
      switch (mlevel)
      {
        case MessageLevel.Debug:
        case MessageLevel.Info:
        case MessageLevel.Trace:
          mbi = MessageBoxIcon.Information;
          break;
        case MessageLevel.Error:
        case MessageLevel.Fatal:
          mbi = MessageBoxIcon.Error;
          break;
        case MessageLevel.Warning:
          mbi = MessageBoxIcon.Warning;
          break;
        default:
          mbi = MessageBoxIcon.None;
          break;
      }

      return mbi;
    }
    #endregion
  }
}
