using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 퍼즐 게이트 제어 컴포넌트
/// PuzzleSystem에 의해 열리는 문 역할
/// </summary>
public class PuzzleGateController : MonoBehaviour
{
    [Header("열릴 위치 오프셋")]
    [SerializeField] private Vector3 openOffset = new Vector3(0, 3, 0);

    [Header("열림 속도")]
    [SerializeField] private float openSpeed = 2f;

    private bool isOpened = false;
    private Vector3 closedPosition;
    private Vector3 openedPosition;

    void Start()
    {
        closedPosition = transform.position;
        openedPosition = closedPosition + openOffset;
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
