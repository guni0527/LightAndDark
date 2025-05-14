using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 플레이어 입력 처리 클래스
/// - 이동 및 점프 입력을 상태로 관리
/// </summary>
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

    /// <summary>
    /// 점프 요청 소모 (1회성 처리)
    /// </summary>
    public void ConsumeJumpRequest()
    {
        JumpRequested = false;
    }
}
