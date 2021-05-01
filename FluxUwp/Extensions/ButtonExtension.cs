using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace FluxUwp.Extensions
{
    public static class ButtonExtension
    {
        public static Subject<TappedRoutedEventArgs> rx_Tap(this Button btn)
        {
            var subject = new Subject<TappedRoutedEventArgs>();
            btn.Tapped += (sender, e) => {
                subject.OnNext(e);
            };

            return subject;
        }
    }
}
