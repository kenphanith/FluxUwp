using FluxUwp;
using FluxUwp.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.FluxDispatcher
{
    public enum Action
    {
        Increment,
        Decrement,
    }

    public enum Mutation
    {
        INCREMENT,
        DECREMENT,
    }

    public struct State
    {
        public int Counter { get; set; }
    }

    public class MainFluxDispatcher: FluxDispatcher<Action, Mutation, State>
    {
        private static State initialState = new State
        {
            Counter = 1
        };

        public MainFluxDispatcher() : base(initialState: initialState) { }

        protected override IObservable<MutationType<Mutation>> Mutate(ActionType<Action> action)
        {
            switch (action._action)
            {
                case Action.Increment:
                    return Observable.Return(new MutationType<Mutation>(Mutation.INCREMENT));

                case Action.Decrement:
                    return Observable.Return(new MutationType<Mutation>(Mutation.DECREMENT));

                default: return Observable.Empty<MutationType<Mutation>>();
            }
        }

        protected override State Reduce(State state, MutationType<Mutation> mutation)
        {
            var newState = state;
            switch (mutation._mutation)
            {
                case Mutation.INCREMENT:
                    newState.Counter++;
                    break;

                case Mutation.DECREMENT:
                    newState.Counter--;
                    break;
            }

            return newState;
        }
    }
}
