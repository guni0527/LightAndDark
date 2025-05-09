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

    private void Start()
    {
        LoadStage(currentStageIndex); // 게임 시작 시 현재 스테이지 로드
    }

    public void LoadStage(int index) // 지정된 인덱스의 스테이지를 로드
    {
        if (index < 0 || index >= stageList.Count)
        {
            Debug.LogError("잘못된 스테이지 인덱스");
            return;
        }
        currentStageIndex = index;
        StageData data = stageList[index];
        Debug.Log($"스테이지 {index} 시작 : {data.sceneName}");

        SceneManager.LoadScene(data.sceneName); // 해당 스테이지 씬 로드
    }

    public void UnlockNextStage() // 다음 스테이지 해금 및 로드
    {
        if (currentStageIndex + 1 < stageList.Count)
        {
            currentStageIndex++;
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
