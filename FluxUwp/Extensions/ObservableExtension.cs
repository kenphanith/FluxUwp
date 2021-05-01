using FluxUwp.Disposable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace FluxUwp.Extensions
{
    public static class ObservableExtension
    {
        public static IObservable<T> Bind<T>(this IObservable<T> source, Subject<T> to)
        {
            return source.Do(value => to.OnNext(value));
        }

        public static void DisposeBag<T>(this IObservable<T> source, DisposeBag bag)
        {
            var token = source.Subscribe(); // usually take this at the end of stream composition
            bag.Collect(token);
        }
    }
}
