using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageClearCondition : MonoBehaviour
{
    public static StageClearCondition Instance { get; private set; }

    private bool isLightPlayerReady = false; // Light 플레이어 도달 여부
    private bool isDarkPlayerReady = false;  // Dark 플레이어 도달 여부
    private bool isCleared = false;          // 중복 처리 방지용

    private float timer = 0f;                // 제한시간 측정용 타이머
    private float timeLimit = 60f;           // 스테이지 제한 시간 (StageData에서 받아옴)

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start() // 현재 스테이지 정보에서 제한 시간 가져오기
    {
        int index = StageManager.Instance.CurrentStageIndex;
        timeLimit = StageManager.Instance.StageList[StageManager.Instance.CurrentStageIndex].timeLimit;
    }

    private void Update()
    {
        if (isCleared || GameManager.Instance.CurrentState != GameManager.GameState.Playing)
            return;

        timer += Time.deltaTime;

        if (timer > timeLimit)
        {
            Debug.Log("제한 시간 초과로 스테이지 실패");
            GameManager.Instance.SetGameState(GameManager.GameState.StageFail);
        }
    }

    public void UpdatePlayerState(ClearZoneTrigger.PlayerType playerType, bool isInside)
    {
        if (playerType == ClearZoneTrigger.PlayerType.Light)
            isLightPlayerReady = isInside;
        else if (playerType == ClearZoneTrigger.PlayerType.Dark)
            isDarkPlayerReady = isInside;

        CheckClearCondition();
    }

    private void CheckClearCondition()
    {
        if (!isCleared && isLightPlayerReady && isDarkPlayerReady && timer <= timeLimit)
        {
            isCleared = true;
            Debug.Log("스테이지 클리어");
            GameManager.Instance.SetGameState(GameManager.GameState.StageClear);
        }
    }
}
