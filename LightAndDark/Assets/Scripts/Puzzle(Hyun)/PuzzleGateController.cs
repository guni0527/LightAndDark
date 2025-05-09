using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 퍼즐 게이트 제어 컴포넌트
/// PuzzleSystem에 의해 열리는 문 역할
/// 특정 스위치 타입들이 모두 활성화되면 열림
/// </summary>
public class PuzzleGateController : MonoBehaviour
{
    [Header("열릴 위치 오프셋")]
    [SerializeField] private Vector3 openOffset = new Vector3(0, 3, 0);

    [Header("열림 속도")]
    [SerializeField] private float openSpeed = 2f;

    [Header("필요한 스위치 타입들")]
    [SerializeField] private List<TriggerType> requiredTriggers;

    private bool isOpened = false;
    private Vector3 closedPosition;
    private Vector3 openedPosition;
    private Dictionary<TriggerType, bool> triggerStates = new();

    void Start()
    {
        closedPosition = transform.position;
        openedPosition = closedPosition + openOffset;

        foreach (var trigger in requiredTriggers)
        {
            triggerStates[trigger] = false;
        }
    }

    /// <summary>
    /// puzzleSystem에서 트리거 상태가 바뀔 때 호출됨
    /// </summary>
    /// <param name="triggerType">스위치 타입 (Light / Dark)</param>
    /// <param name="isActivated">해당 스위치가 활성화 되었는지 여부</param>
    public void UpdateGateState(TriggerType triggerType, bool isActivated)
    {
        Debug.Log($"[게이트] {gameObject.name} ← {triggerType}: {isActivated}");

        if (triggerStates.ContainsKey(triggerType))
        {
            triggerStates[triggerType] = isActivated;

            if (IsConditionMet())
            {
                Debug.Log($"[게이트 열림 조건 충족]: {gameObject.name}");
                OpenGate();
            }
        }
    }

    /// <summary>
    /// 현재 모든 스위치 조건이 충족되었는지 확인
    /// </summary>
    /// <returns>모든 조건이 만족되면 true</returns>
    private bool IsConditionMet()
    {
        foreach (var trigger in requiredTriggers)
        {
            if (!triggerStates[trigger])
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// 외부에서 호출되어 문을 여는 매서드
    /// 중복 호출을 방지하고 코루틴 실행
    /// </summary>
    public void OpenGate()
    {
        if (isOpened)
        {
            return;
        }

        isOpened = true;
        StartCoroutine(OpenGateRoutine());
    }

    /// <summary>
    /// 문이 부드럽게 열리는 코루틴
    /// 목표 위치까지 일정 속도로 이동
    /// </summary>
    /// <returns></returns>
    private IEnumerator OpenGateRoutine()
    {
        while ((transform.position - openedPosition).sqrMagnitude > 0.0001f)
        {
            transform.position = Vector3.MoveTowards(transform.position, openedPosition, openSpeed * Time.deltaTime);

            yield return null;
        }
        transform.position = openedPosition;
    }
}
