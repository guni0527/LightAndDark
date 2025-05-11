using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageTestController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) // 스테이지 클리어 테스트
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.SetGameState(GameManager.GameState.StageClear);
            }
            else
            {
                Debug.LogWarning("GameManager 인스턴스가 없습니다.");
            }
        }

        if (Input.GetKeyDown(KeyCode.R)) // 스테이지 실패 후 재시작 테스트
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.SetGameState(GameManager.GameState.StageFail);
                GameManager.Instance.RetryStage();
            }
            else
            {
                Debug.LogWarning("GameManager 인스턴스가 없습니다.");
            }
        }
    }
}
