using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightZoneTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DarkPlayer"))
        {
            Debug.Log("¾îµÒÀÌ ºû¿¡ ´ê¾Æ »ç¸Á");

            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("LightPlayer"))
        {
            Debug.Log("ºû Ä³¸¯ÅÍ°¡ Àüµî ¹üÀ§¸¦ ¹þ¾î³ª »ç¸Á");
            Destroy(other.gameObject);
        }
    }
}
