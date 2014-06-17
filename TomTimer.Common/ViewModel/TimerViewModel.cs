using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Alteridem.TomTimer.Common.Annotations;

namespace Alteridem.TomTimer.Common.ViewModel
{
   public class TimerViewModel : BaseViewModel
   {
      private TimeSpan _duration;
      private DateTime _start;
      private Timer _timer;
      private string _mode;
      private string _time;

      public TimerViewModel()
      {
         _duration = new TimeSpan(0, 2, 0);
         Time = _duration.TotalMinutes.ToString();
         Mode = "Work";

         _start = DateTime.Now;
         _timer = new Timer( OnTimerCallback, null, 250, 250 );
      }

      private void OnTimerCallback( object state )
      {
         var elapsed = _duration.Subtract( DateTime.Now.Subtract( _start ) );
         if ( elapsed.TotalMilliseconds <= 0 )
         {
            _timer.Cancel();
         }
         else if ( elapsed.TotalMinutes < 1 )
         {
            Time = ((int)elapsed.TotalSeconds).ToString();
         }
         else
         {
            Time = ((int)elapsed.TotalMinutes).ToString();
         }
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
