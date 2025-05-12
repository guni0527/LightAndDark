using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance { get; private set; }

    [SerializeField] private int currentStageIndex; // ���� �������� �ε���
    public int CurrentStageIndex => currentStageIndex; // �ܺο��� �б� �������� ����

    [SerializeField] private List<StageData> stageList; // �������� ������ ���

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void LoadStage(int index) // ������ �ε����� ���������� �ε�
    {
        if (!StageUnlockSystem.Instance.IsStageUnlocked(index))
        {
            Debug.LogWarning($"�������� {index}�� �رݵ��� �ʾҽ��ϴ�.");
            return;
        }

        if (index < 0 || index >= stageList.Count)
        {
            Debug.LogError("�߸��� �������� �ε���");
            return;
        }

        string sceneToLoad = stageList[index].sceneName;

        if (SceneManager.GetActiveScene().name == sceneToLoad)
        {
            Debug.Log("���� ���� �����Ͽ� �ε� ����");
            return;
        }

        currentStageIndex = index;
        StageData data = stageList[index];
        Debug.Log($"�������� {index} ���� : {data.sceneName}");

        SceneManager.LoadScene(data.sceneName); // �ش� �������� �� �ε�
    }

    public void UnlockNextStage() // ���� �������� ��� �� �ε�
    {
        if (currentStageIndex + 1 < stageList.Count)
        {
            currentStageIndex++;

            StageUnlockSystem.Instance.UnlockStage(currentStageIndex); // StageUnlockSystem�� ���� (PlayerPrefs���� �����)

            LoadStage(currentStageIndex); // ���� �������� �ε�
        }
        else
        {
            Debug.Log("��� �������� Ŭ����");
            GameManager.Instance.SetGameState(GameManager.GameState.StageClear); // ���� Ŭ����
        }
    }

    public string GetCurrentStageSceneName() // ���� ���������� �� �̸� ��ȯ
    {
        if (currentStageIndex < 0 || currentStageIndex >= stageList.Count)
        {
            Debug.LogError("���� �������� �ε����� �߸��Ǿ����ϴ�.");
            return "";
        }
        return stageList[currentStageIndex].sceneName;
    }
}
