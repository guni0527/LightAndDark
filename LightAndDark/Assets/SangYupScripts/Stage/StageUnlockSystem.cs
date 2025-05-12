using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageUnlockSystem : MonoBehaviour
{
    public static StageUnlockSystem Instance {  get; private set; }
    private HashSet<int> unlockedStages = new HashSet<int>(); // 해금된 스테이지 인덱스들을 저장하는 HashSet

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        LoadUnlockedStages();
    }

    private void LoadUnlockedStages()
    {
        unlockedStages.Clear();
        int count = PlayerPrefs.GetInt("UnlockedStageCount", 1); // 기본값 1개 해금
        for (int i = 0; i < count; i++) // 기본적으로 스테이지 0은 항상 해금된 상태로 시작
        {
            unlockedStages.Add(i);
        }
    }

    public bool IsStageUnlocked(int stageIndex) // 특정 스테이지가 해금되었는지 여부를 반환
    {
        return unlockedStages.Contains(stageIndex);
    }

    public void UnlockStage(int stageIndex) // 새로운 스테이지를 해금하고, 저장
    {
        if (!unlockedStages.Contains(stageIndex))
        {
            unlockedStages.Add(stageIndex);
            PlayerPrefs.SetInt("UnlockedStageCount", unlockedStages.Count); // 해금 스테이지 수 저장
            PlayerPrefs.Save();
        }
    }

    public List<int> GetUnlockedStages() // 현재 해금된 모든 스테이지 인덱스를 리스트로 반환
    {
        return new List<int>(unlockedStages);
    }

    public void ResetStage() // 모든 스테이지를 잠금 상태로 초기화
    {
        unlockedStages.Clear();
        PlayerPrefs.DeleteKey("UnlockedStageCount");
    }
}
