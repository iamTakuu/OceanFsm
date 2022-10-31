using System;
using Ocean.StateMachine.Samples.States;
using UnityEngine;

namespace Ocean.StateMachine.Samples
{
    public class CubeMachine : OceanMachine<CubeMachine>
    {
        [SerializeField] private MeshRenderer meshRenderer;
        [SerializeField] private Color firstStateColor;
        [SerializeField] private Color resetColor;
        
        private void Start()
        {
            AddState(new FirstState(this, meshRenderer, firstStateColor));
            AddState(new SecondState(this));

            TransitionToState<FirstState>();
        }

        private void OnDestroy()
        {
            meshRenderer.material.color = resetColor;
        }
    }
}


