using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace FluxUwp.Extensions
{
    public static class SubjectExtension
    {
        // TODO: Probably integrate with ICommand
        public static IDisposable Bind<T>(this Subject<T> subject, IObservable<T> obj)
        {
            return obj.Subscribe(observer => subject.OnNext(observer));
        }
    }
}
