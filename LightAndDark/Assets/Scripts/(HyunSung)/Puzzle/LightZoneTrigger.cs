using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// LightZoneTrigger
/// 빛 영역과의 충돌을 처리하는 트리거 컴포넌트
/// - LightPlayer: 영역 내/외 진입 시 isInLightZone 플래그 관리 및 사망 판정
/// - DarkPlayer: 영역 진입 시 즉시 사망 처리
/// </summary>
public class LightZoneTrigger : MonoBehaviour
{
    /// <summary>
    /// 플레이어가 LightZone에 진입 시 호출
    /// - LightPlayer: 영역 내부 플래그 true 설정
    /// - DarkPlayer: 즉시 사망 처리 (DarkDie)
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("LightPlayer"))
        {
           PlayerState state = other.GetComponent<PlayerState>();
            if (state != null)
            {
                state.IsInLightZone = true;
            }
        }

        if (other.CompareTag("DarkPlayer"))
        {
            Debug.Log("어둠이 빛에 닿아 사망");
            PlayerState state = other.GetComponent<PlayerState>();
            if (state != null)
            {
                state.Die();
            }
            else
            {
                Debug.LogWarning("PlayerState 컴포넌트를 찾을수없음.");
            }
        }
    }

    /// <summary>
    /// LightPlayer가 LightZone에서 이탈 시 호출
    /// - isInLightZone false 설정
    /// - 다른 LightZone과 겹치지 않으면 사망 처리 (LightDie)
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("LightPlayer"))
        {
            PlayerState state = other.GetComponent<PlayerState>();
            if(state != null)
            {
                state.IsInLightZone = false;

                if (!IsInAnyLightZone(state))
                {
                    Debug.Log("빛 캐릭터가 완전한 어둠으로 나가 사망");
                    state.Die();
                }
            }
        }
    }

    /// <summary>
    /// 특정 위치가 어떤 LightZone에도 포함되어 있는지 확인
    /// </summary>
    /// <param name="white">체크할 WhiteController 인스턴스</param>
    /// <returns>하나 이상의 LightZone과 겹치면 true, 없으면 false</returns>
    private bool IsInAnyLightZone(PlayerState player)
    {
        Collider2D[] colliders = Physics2D.OverlapPointAll(player.transform.position);
        foreach (var col in colliders)
        {
            if (col.CompareTag("LightZone"))
            {
                return true;
            }
        }
        return false;
    }
}
