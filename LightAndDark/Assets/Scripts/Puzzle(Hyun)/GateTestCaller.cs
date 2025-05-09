using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateTestCaller : MonoBehaviour
{
    [SerializeField] private PuzzleGateController gate;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gate.OpenGate();
        }
    }
}
