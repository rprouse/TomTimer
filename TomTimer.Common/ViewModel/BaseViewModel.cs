using System.ComponentModel;
using System.Runtime.CompilerServices;
using Alteridem.TomTimer.Common.Annotations;

namespace Alteridem.TomTimer.Common.ViewModel
{
   public class BaseViewModel : INotifyPropertyChanged
   {
      public event PropertyChangedEventHandler PropertyChanged;

      [NotifyPropertyChangedInvocator]
      protected void OnPropertyChanged( [CallerMemberName] string propertyName = null )
      {
         var handler = PropertyChanged;
         if ( handler != null ) handler( this, new PropertyChangedEventArgs( propertyName ) );
      }
   }
}
