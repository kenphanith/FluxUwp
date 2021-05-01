using Sample.FluxDispatcher;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using FluxUwp.Interfaces;
using Action = Sample.FluxDispatcher.Action;
using Mutation = Sample.FluxDispatcher.Mutation;
using State = Sample.FluxDispatcher.State;
using FluxUwp.Disposable;
using FluxUwp.Extensions;
using System.Reactive.Linq;
using FluxUwp.Types;
using System.Diagnostics;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Sample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private IFluxDispatchable<Action, Mutation, State> fluxDispatcher = new MainFluxDispatcher();
        private DisposeBag DisposeBag = new DisposeBag();
        private State state { get; set; }

        public MainPage()
        {
            this.InitializeComponent();

            /// Binding state with Control
            this.fluxDispatcher.Bind(this);

            this.Increment.rx_Tap()
                .Select(x => this.fluxDispatcher.Dispatcher(Action.Increment))
                .Bind(this.fluxDispatcher.action)
                .DisposeBag(bag: this.DisposeBag);

            this.Decrement.rx_Tap()
                .Select(x => this.fluxDispatcher.Dispatcher(Action.Decrement))
                .Bind(this.fluxDispatcher.action)
                .DisposeBag(bag: this.DisposeBag);
        }
    }
}
