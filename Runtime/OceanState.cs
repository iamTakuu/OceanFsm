using Ocean.StateMachine.Handlers;

namespace Ocean.StateMachine
{
    /// <summary>
    /// A state behavior that is used to handle the state machine's callbacks.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the state.
    /// </typeparam>
    public abstract class OceanState<T> where T : OceanMachine<T>
    {
        /// <summary>
        /// The MonoBehaviour that that this state belongs to.
        /// </summary>
        protected T Runner { get; }
        
        /// <summary>
        /// The State Machine the <see cref="Runner"/> instance is using.
        /// </summary>
        /// <example>
        /// <code>
        /// Machine.TransitionToState&lt;ExampleState>();
        /// </code>
        /// </example>
        protected readonly OceanMachine<T> Machine;
        
        public IEnterHandler EnterHandler => this as IEnterHandler; 
        public IUpdateHandler UpdateHandler => this as IUpdateHandler;
        public IFixedUpdateHandler FixedUpdateHandler => this as IFixedUpdateHandler;
        public IExitHandler ExitHandler => this as IExitHandler;
        
        protected OceanState(OceanMachine<T> machine)
        {
            Machine = machine;
            Runner = Machine.GetComponent<T>();
        }
    }
}