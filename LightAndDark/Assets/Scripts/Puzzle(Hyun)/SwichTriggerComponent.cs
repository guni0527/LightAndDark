using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 스위치 트리거 컴포넌트
/// 플레이어가 특정 스위치에 접근하면 PuzzleSystem에 트리거 신호를 보냄
/// </summary>
public class SwichTriggerComponent : MonoBehaviour
{
    [SerializeField] private TriggerType triggerType;

    private enum TriggerType
    {
        Light,
        Dark
    }

    /// <summary>
    /// 플레이어가 트리거 존에 진입했을 때 실행됨
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((triggerType == TriggerType.Light && other.CompareTag("LightPlayer")) || (triggerType == TriggerType.Dark && other.CompareTag("DarkPlayer")))
        {
            Debug.Log($"{triggerType} 스위치 작동!");
            PuzzleSystem.Instance.TriggerFromSwitch(triggerType.ToString());
        }
    }
}
