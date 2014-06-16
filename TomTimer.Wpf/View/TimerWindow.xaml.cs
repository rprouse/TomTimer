using System.Windows;
using System.Windows.Input;

namespace Alteridem.TomTimer.Wpf.View
{
   /// <summary>
   /// Interaction logic for TimerWindow.xaml
   /// </summary>
   public partial class TimerWindow : Window
   {
      public TimerWindow()
      {
         InitializeComponent();
      }

      private void OnMouseDown( object sender, MouseButtonEventArgs e )
      {
         if ( e.ChangedButton == MouseButton.Left )
            DragMove();
      }
   }
}
