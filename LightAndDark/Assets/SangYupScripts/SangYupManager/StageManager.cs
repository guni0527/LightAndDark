using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance { get; private set; }

    [SerializeField] private int currentStageIndex;
    [SerializeField] private List<StageData> stageList;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        LoadStage(currentStageIndex);
    }

    public void LoadStage(int index)
    {
        if (index < 0 || index >= stageList.Count)
        {
            Debug.LogError("잘못된 스테이지 인덱스");
            return;
        }
        currentStageIndex = index;
        StageData data = stageList[index];
        Debug.Log($"스테이지 {index} 시작 : {data.sceneName}");

        SceneManager.LoadScene(data.sceneName);
    }

    public void UnlockNextStage()
    {
        if (currentStageIndex + 1 < stageList.Count)
        {
            currentStageIndex++;
            LoadStage(currentStageIndex);
        }
        else
        {
            Debug.Log("모든 스테이지 클리어");
            GameManager.Instance.SetGameState(GameManager.GameState.StageClear);
        }
    }
}
