using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// LightSwitch
/// Light 또는 Dark 플레이어가 접근 후 H 키를 눌러 조명(LightZone)의 ON/OFF를 조작
/// 조작자는 누구든 가능하며, 영향을 받는 대상은 상대 캐릭터일 수 있음
/// </summary>
public class LightSwitch : MonoBehaviour
{
    [SerializeField] private LightZone targetZone;

    private bool isInTrigger = false;

    /// <summary>
    /// 플레이어가 트리거 안에 있고 H 키를 누르면 조명 상태 토글
    /// </summary>
    private void Update()
    {
        if (isInTrigger && Input.GetKeyDown(KeyCode.H))
        {
            targetZone.ToggleLight();
        }
    }

    /// <summary>
    /// 플레이어가 트리거에 진입했을 때 Light, Dark 구분없이 모두 인식
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("LightPlayer") || other.CompareTag("DarkPlayer"))
        {
            isInTrigger = true;
        }
    }

    /// <summary>
    /// 트리거에서 벗어나면 입력 무효화
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("LightPlayer") || other.CompareTag("DarkPlayer"))
        {
            isInTrigger = false;
        }
    }
}
