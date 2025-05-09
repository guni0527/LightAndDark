using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 스위치 트리거 컴포넌트
/// 플레이어가 특정 스위치에 접근하면 PuzzleSystem에 트리거 신호를 보냄
/// </summary>
public class SwitchTriggerComponent : MonoBehaviour
{     
    [SerializeField] private TriggerType triggerType;       // 작동 조건이 되는 플레이어 타입 (Light 또는 Dark)
    [SerializeField] private PuzzleSystem puzzleSystem;     // 퍼즐 상태를 제어할 PuzzleSystem 참조

    private bool isTrigger = false;      // 플레이어가 현재 트리거 범위 안에 있는지 여부
    private bool isActivated = false;    // 현재 스위치가 활성화 상태인지 여부

    /// <summary>
    /// 매 프레임마다 입력을 체크하여 트리거 안에 있을 때 H키로 스위치를 작동시킴
    /// </summary>
    private void Update()
    {
        if (isTrigger && Input.GetKeyDown(KeyCode.H))
        {
            ToggleSwitch();
        }
    }

    /// <summary>
    /// 스위치 상태를 반전시켜 PuzzleSystem에 전달함, 추후 시각적/ 청각적 피드백 처리가능
    /// </summary>
    private void ToggleSwitch()
    {
        isActivated = !isActivated;
        puzzleSystem.UpdatePuzzleState(triggerType, isActivated);

        // TODO: 이펙트 or 사운드 실행
        // AudioSource.Play(), Animator.SetTrigger("Activate") 등
    }

    /// <summary>
    /// 플레이어가 트리거 존에 진입했을 때 실행됨
    /// 유효한 플레이어(TriggerType과 일치)일 경우 트리거 활성화
    /// </summary>
    /// <param name="other">트리거에 들어온 콜라이더</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (IsValidPlayer(other))
        {
            isTrigger = true;
        }
    }

    /// <summary>
    /// 플레이어가 트리거 존에서 벗어났을 때 호출됨
    /// 유효한 플레이어일 경우 트리거 비활성화
    /// </summary>
    /// <param name="other">트리거에서 나간 콜라이더</param>
    private void OnTriggerExit2D(Collider2D other)
    {
        if (IsValidPlayer(other))
        {
            isTrigger = false;
        }
    }

    /// <summary>
    /// 충돌한 객체가 현재 스위치의 타입과 일치하는 플레이어인지 판별
    /// </summary>
    /// <param name="other">충돌한 콜라이더</param>
    /// <returns>해당 플레이어가 유효한 타입일 경우 true</returns>
    private bool IsValidPlayer(Collider2D other)
    {
        return (triggerType == TriggerType.Light && other.CompareTag("LightPlayer")) || (triggerType == TriggerType.Dark && other.CompareTag("DarkPlayer"));
    }
}
