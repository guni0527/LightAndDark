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
}
