using FluxUwp.Types;
using System;
using System.Reactive.Subjects;
using Windows.UI.Xaml.Controls;

namespace FluxUwp.Interfaces
{
    public interface IFluxDispatchable<Action, Mutation, State>
        where Action : Enum
        where Mutation : Enum
        where State : StateType
    {
        ActionType<Action> Dispatcher(Action action, dynamic param = null);
        Subject<ActionType<Action>> action { get; }
        IObservable<State> state { get; }
        void Bind(Control control);
    }
}
