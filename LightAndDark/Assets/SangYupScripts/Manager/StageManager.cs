using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 프리펩 기반 스테이지 관리 매니저 (씬 로드 제거)
/// </summary>
public class StageManager : MonoBehaviour
{
    public static StageManager Instance { get; private set; }

    [SerializeField] private int currentStageIndex; // 현재 스테이지 인덱스
    [SerializeField] private List<GameObject> stagePrefabs;
    [SerializeField] private Transform stageParemt;

    public int CurrentStageIndex => currentStageIndex;

    private GameObject currentStageInstance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// 스테이지 로드 (프리팹 Instantiate)
    /// </summary>
    /// <param name="index"></param>
    public void LoadStage(int index) // 지정된 인덱스의 스테이지를 로드
    {
        if (index < 0 || index >= stagePrefabs.Count)
        {
            Debug.LogError("잘못된 스테이지 인덱스");
            return;
        }

        if (currentStageInstance != null)
        {
            Destroy(currentStageInstance);
        }

        currentStageInstance = Instantiate(stagePrefabs[index], stageParemt);
        currentStageIndex = index;

        Debug.Log($"스테이지 {index + 1} 프리펩 로드 완료");
    }

    public void LoadNextStage()
    {
        int nextIndex = (currentStageIndex + 1) % stagePrefabs.Count;
        LoadStage(nextIndex);
    }
}
