using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Ocean.StateMachine
{
    /// <summary>
    ///  A MonoBehaviour that runs a finite state machine.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the state machine.
    /// </typeparam>
    public abstract class OceanMachine<T> : MonoBehaviour where T : OceanMachine<T>
    {
        [SerializeField] private UnityEvent<OceanState<T>> onStateChange;
        
        private OceanState<T> _currentState;
        private readonly Dictionary<Type, OceanState<T>> _stateDictionary = new();
        
        private void Update()
        {
            _currentState?.UpdateHandler?.OnUpdate(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            _currentState?.FixedUpdateHandler?.OnFixedUpdate(Time.fixedDeltaTime);
        }
        
        /// <summary>
        ///  Add a state to the state machine.
        /// </summary>
        /// <param name="state">
        /// The state to add where T is the type of the state machine.
        /// </param>
        /// <example><code>
        /// AddState(new ExampleState(this)));
        /// </code>
        /// </example>
        protected void AddState(OceanState<T> state)
        {
            var type = state.GetType();
            
            if (_stateDictionary.ContainsKey(type))
            {
                Debug.LogWarning($"State [{type.Name}] already exists in the machine.");
                return;
            }
            
            _stateDictionary.Add(type, state);
        }
        
        /// <summary>
        /// Will change the current state to the given state.
        /// </summary>
        /// <typeparam name="TState">
        /// Must be a subclass of <see cref="OceanState{T}"/>,
        /// where T is the type of the state machine.
        /// </typeparam>
        /// <returns>
        /// (more or less optional) The instance of the state that was transitioned to.
        /// Useful if you want to access the state's fields/methods.
        /// </returns>
        public TState TransitionToState<TState>() where TState : OceanState<T>
        {
            var state = typeof(TState);
            
            if (!_stateDictionary.ContainsKey(state))
            {
                Debug.LogError($"State [{state.Name}] was not added to this machine");
                return null;
            }
            
            _currentState?.ExitHandler?.OnExit();
            
            _currentState = _stateDictionary[state];

            _currentState.EnterHandler?.OnEnter();
            
            onStateChange?.Invoke(_currentState);

            return (TState) _currentState;
        }
    }
}