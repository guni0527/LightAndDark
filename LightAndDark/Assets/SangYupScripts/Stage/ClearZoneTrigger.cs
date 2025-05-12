using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearZoneTrigger : MonoBehaviour
{
    public enum PlayerType { Light, Dark }
    public PlayerType playerType;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((playerType == PlayerType.Light && other.CompareTag("LightPlayer")) ||
            (playerType == PlayerType.Dark && other.CompareTag("DarkPlayer")))
        {
            StageClearCondition.Instance?.UpdatePlayerState(playerType, true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if ((playerType == PlayerType.Light && other.CompareTag("LightPlayer")) ||
            (playerType == PlayerType.Dark && other.CompareTag("DarkPlayer")))
        {
            StageClearCondition.Instance?.UpdatePlayerState(playerType, false);
        }
    }
}
