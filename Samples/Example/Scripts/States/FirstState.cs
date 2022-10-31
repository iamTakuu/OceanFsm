using Ocean.StateMachine.Handlers;
using UnityEngine;

namespace Ocean.StateMachine.Samples.States
{
    public class FirstState : OceanState<CubeMachine>, IEnterHandler, IUpdateHandler, IExitHandler
    {
        private readonly MeshRenderer _renderer;
        private readonly Color _color;
        
        private float _timeElapsed;
        private Color _initialColor;
        
        public FirstState(OceanMachine<CubeMachine> machine, MeshRenderer renderer, Color color) : base(machine)
        {
            _color = color;
            _renderer = renderer;
        }
        
        public void OnEnter()
        {
            var mat = _renderer.sharedMaterial;
            _initialColor = mat.color;
            mat.color = _color;
            
            _timeElapsed = 0f;
        }
        
        public void OnUpdate(float deltaTime)
        {
            _timeElapsed += deltaTime;

            if (_timeElapsed > 2f)
            {
                Machine.TransitionToState<SecondState>();
            }
        }

        public void OnExit()
        {
            _renderer.sharedMaterial.color = _initialColor;
        }
    }
}