using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    public float MoveInput { get; set; }
    public bool JumpRequested { get; set; }

    [SerializeField] private KeyCode leftKey = KeyCode.LeftArrow;
    [SerializeField] private KeyCode rigjtKey = KeyCode.RightArrow;
    [SerializeField] private KeyCode jumpKey = KeyCode.UpArrow;

    private void Update()
    {
        MoveInput = 0f;
        if (Input.GetKey(leftKey))
        {
            MoveInput = -1f;
        }
        if (Input.GetKey(rigjtKey))
        {
            MoveInput = 1f;
        }

        if (Input.GetKeyDown(jumpKey))
        {
            JumpRequested = true;
        }
    }

    public void ConsumeJumpRequest()
    {
        JumpRequested = false;
    }
}
