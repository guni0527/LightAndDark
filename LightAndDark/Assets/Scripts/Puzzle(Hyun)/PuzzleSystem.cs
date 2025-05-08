using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 퍼즐 시스템 중앙 제어 클래스
/// 스위치 입력을 감지하고 퍼즐 조건이 충족되면 게이트를 개방함
/// </summary>
public class PuzzleSystem : MonoBehaviour
{
    public static PuzzleSystem Instance { get; private set; }

    [Header("연동된 퍼즐 게이트들")]
    [SerializeField] private List<PuzzleGateController> gates;

    private HashSet<string> activatedSwitches = new HashSet<string>();

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
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// 스위치에서 퍼즐 입력을 수신하여 상태를 갱신하고 조건 확인
    /// 중복 입력은 무시
    /// </summary>
    /// <param name="type"></param>
    public void TriggerFromSwitch(string type)
    {
        if (activatedSwitches.Contains(type))
        {
            return;
        }

        activatedSwitches.Add(type);
        Debug.Log($"스위치 입력: {type}");

        CheckPuzzleClear();
    }

    /// <summary>
    /// 퍼즐 클리어 조건 검사
    /// 모든 조건이 충족되면 연결된 게이트들을 개방
    /// </summary>
    public void CheckPuzzleClear()
    {
        if (activatedSwitches.Contains("Light") && activatedSwitches.Contains("Dark"))
        {
            Debug.Log("모든 스위치가 작동됨! -> 게임트 오픈");

            foreach (var gate in gates)
            {
                gate.OpenGate();
            }
        }      
    }
}
