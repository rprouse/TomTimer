using System.ComponentModel;
using System.Runtime.CompilerServices;
using Alteridem.TomTimer.Common.Annotations;

namespace Alteridem.TomTimer.Common.ViewModel
{
   public class TimerViewModel : BaseViewModel
   {
      private string _mode;
      private string _time;

      public TimerViewModel()
      {
         Time = "25";
         Mode = "Work";
      }

      public string Time
      {
         get { return _time; }
         set
         {
            if ( value == _time ) return;
            _time = value;
            OnPropertyChanged( );
         }
      }

      public string Mode
      {
         get { return _mode; }
         set
         {
            if ( value == _mode ) return;
            _mode = value;
            OnPropertyChanged( );
         }
      }
   }
}
