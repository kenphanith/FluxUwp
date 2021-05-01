using FluxUwp.Interfaces;
using FluxUwp.Types;
using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Windows.UI.Core;

namespace FluxUwp
{
    public class FluxDispatcher<Action, Mutation, State> : IFluxDispatchable<Action, Mutation, State>
        where Action : Enum
        where Mutation : Enum
        where State : struct
    {
        /// <summary>
        /// action subject
        /// </summary>
        protected Subject<ActionType<Action>> _action { get; } = new Subject<ActionType<Action>>();

        /// <summary>
        /// action subject 
        /// </summary>
        public Subject<ActionType<Action>> action { get { return this._action; } }

        /// <summary>
        /// Flux State
        /// </summary>
        private IObservable<State> _state { get; set; }

        /// <summary>
        /// Flux State
        /// </summary>
        public IObservable<State> state { get { return this._state; } }

        protected State InitialState { get; set; }
        protected State CurrentState { get; set; }

        /// <summary>
        /// ActionType for Dispatcher
        /// </summary>
        protected ActionType<Action> ActionType { get; }

        /// <summary>
        /// MutationType for Dispatcher
        /// </summary>
        protected MutationType<Mutation> MutationType { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="initialState"></param>
        public FluxDispatcher(State initialState)
        {
            this.InitialState = initialState;
            this._state = this.CreateStateStream();
            this._state.Subscribe().Dispose(); // require subsciption once
        }

        /// <summary>
        /// Dispatcher for Action
        /// </summary>
        /// <param name="action"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public ActionType<Action> Dispatcher(Action action, dynamic param = null)
        {
            return new ActionType<Action>(action, param);
        }

        /// <summary>
        /// Flux: Core Concept
        /// </summary>
        /// <returns></returns>
        private IObservable<State> CreateStateStream()
        {
            var action = this._action.AsObservable();
            var mutation = action.SelectMany(__action =>
            {
                return Mutate(action: __action);
            });
            var state = mutation.Scan(this.InitialState, (__state, __mutation) =>
            {
                return Reduce(state: __state, mutation: __mutation);
            })
            .Catch(Observable.Empty<State>())
            .StartWith(this.InitialState)
            .ObserveOnDispatcher(CoreDispatcherPriority.High)
            .Do((__state) =>
            {
                this.CurrentState = __state;
            })
            .Replay(1);

            return state.AutoConnect();
        }

        /// <summary>
        /// overridable at sub classes
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        protected virtual IObservable<MutationType<Mutation>> Mutate(ActionType<Action> action)
        {
            return Observable.Empty<MutationType<Mutation>>();
        }


        /// <summary>
        /// overridable at sub classes
        /// </summary>
        /// <param name="state"></param>
        /// <param name="mutation"></param>
        /// <returns></returns>
        protected virtual State Reduce(State state, MutationType<Mutation> mutation)
        {
            return state;
        }
    }
}
