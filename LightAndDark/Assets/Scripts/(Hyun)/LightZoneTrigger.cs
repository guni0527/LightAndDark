using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightZoneTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
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
                white.LightDie();
            }
            else
            {
                Debug.LogWarning("LightController 컴포넌트를 찾을수없음.");
            }
        }
    }
}
