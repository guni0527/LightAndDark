using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance { get; private set; }

    [SerializeField] private int currentStageIndex; // 현재 스테이지 인덱스
    public int CurrentStageIndex => currentStageIndex; // 외부에서 읽기 전용으로 접근

    [SerializeField] private List<StageData> stageList; // 스테이지 데이터 목록

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void LoadStage(int index) // 지정된 인덱스의 스테이지를 로드
    {
        if (!StageUnlockSystem.Instance.IsStageUnlocked(index))
        {
            Debug.LogWarning($"스테이지 {index}는 해금되지 않았습니다.");
            return;
        }

        if (index < 0 || index >= stageList.Count)
        {
            Debug.LogError("잘못된 스테이지 인덱스");
            return;
        }

        string sceneToLoad = stageList[index].sceneName;

        if (SceneManager.GetActiveScene().name == sceneToLoad)
        {
            Debug.Log("현재 씬과 동일하여 로드 생략");
            return;
        }

        currentStageIndex = index;
        StageData data = stageList[index];
        Debug.Log($"스테이지 {index} 시작 : {data.sceneName}");

        SceneManager.LoadScene(data.sceneName); // 해당 스테이지 씬 로드
    }

    public void UnlockNextStage() // 다음 스테이지 언락 및 로드
    {
        if (currentStageIndex + 1 < stageList.Count)
        {
            currentStageIndex++;

            StageUnlockSystem.Instance.UnlockStage(currentStageIndex); // StageUnlockSystem에 저장 (PlayerPrefs에도 저장됨)

            LoadStage(currentStageIndex); // 다음 스테이지 로드
        }
        else
        {
            Debug.Log("모든 스테이지 클리어");
            GameManager.Instance.SetGameState(GameManager.GameState.StageClear); // 게임 클리어
        }
    }

    public string GetCurrentStageSceneName() // 현재 스테이지의 씬 이름 반환
    {
        if (currentStageIndex < 0 || currentStageIndex >= stageList.Count)
        {
            Debug.LogError("현재 스테이지 인덱스가 잘못되었습니다.");
            return "";
        }
        return stageList[currentStageIndex].sceneName;
    }
}
