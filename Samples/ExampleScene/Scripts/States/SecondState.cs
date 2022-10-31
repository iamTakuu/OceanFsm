using Ocean.StateMachine.Handlers;
using UnityEngine;

namespace Ocean.StateMachine.Samples.States
{
    public class SecondState : OceanState<CubeMachine>, IUpdateHandler, IEnterHandler
    {
        private float timeElapsed;
        
        public SecondState(OceanMachine<CubeMachine> machine) : base(machine)
        {
        }
        
        public void OnEnter()
        {
            timeElapsed = 0f;
        }

        public void OnUpdate(float deltaTime)
        {
            timeElapsed += deltaTime;
            
            var transform = Machine.transform;
            
            transform.Rotate(Vector3.back, 30 * deltaTime);

            if (timeElapsed > 2f)
            {
                Machine.TransitionToState<FirstState>();
            }
        }


    }
}