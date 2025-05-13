using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightZoneTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("LightPlayer"))
        {
            WhiteController white = other.GetComponent<WhiteController>();
            if (white != null)
            {
                white.isInLightZone = true;
            }
        }

        if (other.CompareTag("DarkPlayer"))
        {
            Debug.Log("어둠이 빛에 닿아 사망");
            DarkController dark = other.GetComponent<DarkController>();
            if (dark != null)
            {
                dark.DarkDie();
            }
            else
            {
                Debug.LogWarning("DarkController 컴포넌트를 찾을수없음.");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("LightPlayer"))
        {
            Debug.Log("빛 캐릭터가 전등 범위를 벗어나 사망");
            WhiteController white = other.GetComponent<WhiteController>();
            if(white != null)
            {
                white.isInLightZone = false;

                if (!IsInAnyLightZone(white))
                {
                    Debug.Log("빛 캐릭터가 완전한 어둠으로 나가 사망");
                    white.LightDie();
                }
            }
        }
    }

    private bool IsInAnyLightZone(WhiteController white)
    {
        Collider2D[] colliders = Physics2D.OverlapPointAll(white.transform.position);
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
