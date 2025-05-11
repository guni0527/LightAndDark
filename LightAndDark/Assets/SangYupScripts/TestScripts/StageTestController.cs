using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageTestController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) // �������� Ŭ���� �׽�Ʈ
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.SetGameState(GameManager.GameState.StageClear);
            }
            else
            {
                Debug.LogWarning("GameManager �ν��Ͻ��� �����ϴ�.");
            }
        }

        if (Input.GetKeyDown(KeyCode.R)) // �������� ���� �� ����� �׽�Ʈ
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.SetGameState(GameManager.GameState.StageFail);
                GameManager.Instance.RetryStage();
            }
            else
            {
                Debug.LogWarning("GameManager �ν��Ͻ��� �����ϴ�.");
            }
        }
    }
}
