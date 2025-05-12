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
            Destroy(other.gameObject);
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("LightPlayer"))
        {
            Debug.Log("빛 캐릭터가 전등 범위를 벗어나 사망");           
            Destroy(other.gameObject);           
        }
    }
}
