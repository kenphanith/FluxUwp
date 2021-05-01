using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace FluxUwp.Extensions
{
    public static class TextBlockExtension
    {
        public static Subject<string> rx_Text(this TextBlock tb)
        {
            var subject = new Subject<string>();

            // TODO: use UWP viewmodel
            subject.Subscribe(observer => { tb.Text = observer; });
            return subject;
        }
    }
}
