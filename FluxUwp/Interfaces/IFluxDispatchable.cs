using FluxUwp.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace FluxUwp.Interfaces
{
    public interface IFluxDispatchable<Action, Mutation, State>
        where Action : Enum
        where Mutation : Enum
        where State : struct
    {
        ActionType<Action> Dispatcher(Action action, dynamic param = null);
        Subject<ActionType<Action>> action { get; }
        IObservable<State> state { get; }
    }
}
