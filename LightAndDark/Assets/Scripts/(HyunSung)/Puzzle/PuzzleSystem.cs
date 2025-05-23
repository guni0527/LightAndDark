using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 퍼즐 시스템 중앙 제어 클래스
/// 스위치 입력을 감지하고 퍼즐 조건이 충족되면 게이트를 개방함
/// </summary>
public class PuzzleSystem : MonoBehaviour
{
    public static PuzzleSystem Instance { get; private set; } // 싱글턴 인스턴스

    [Header("연동된 퍼즐 게이트들")]
    [SerializeField] private List<PuzzleGateController> targetGates; // 퍼즐 클리어 시  열릴 게이트 목록

    [Header("이 퍼즐 시스템이 게이트에 영향을 주는가?")]
    public bool shouldAffectGates = true;
    public bool ShouldAffectGates => shouldAffectGates;

    private HashSet<TriggerType> activatedSwitches = new HashSet<TriggerType>(); // 현재 작동죽인 스위치 타입들을 저장하는 집합 (중복방지)

    /// <summary>
    /// 싱글턴 인스턴스 초기화
    /// 씬에 단 하나의 PuzzleSystem만 존재하도록 설정
    /// </summary>
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // 중복 방지
        }
    }

    /// <summary>
    /// 외부에서 스위치 상태가 변경될 때 호출됨
    /// 스위치의 활성/비활성 상태에 따라 내부 상태를 업데이트하고 퍼즐 조건 검사 수행
    /// </summary>
    /// <param name="type"></param>
    /// <param name="isActivated"></param>
    public void UpdatePuzzleState(TriggerType triggerType, bool isActivated)
    {
        foreach (var gate in targetGates)
        {
            gate.UpdateGateState(triggerType, isActivated);
        }
    }
}
