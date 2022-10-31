using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ocean.StateMachine.Samples
{
    public class LogChange : MonoBehaviour
    {
        public void OnCubeStateChanged(OceanState<CubeMachine> state)
        {
            Debug.Log($"Cube state changed to {state.GetType().Name}");
        }
    }
}

