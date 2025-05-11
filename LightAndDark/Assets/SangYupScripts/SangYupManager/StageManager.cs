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

    private void Start()
    {
        LoadStage(currentStageIndex); // ���� ���� �� ���� �������� �ε�
    }

    public void LoadStage(int index) // ������ �ε����� ���������� �ε�
    {
        if (index < 0 || index >= stageList.Count)
        {
            Debug.LogError("�߸��� �������� �ε���");
            return;
        }
        currentStageIndex = index;
        StageData data = stageList[index];
        Debug.Log($"�������� {index} ���� : {data.sceneName}");

        SceneManager.LoadScene(data.sceneName); // �ش� �������� �� �ε�
    }

    public void UnlockNextStage() // ���� �������� �ر� �� �ε�
    {
        if (currentStageIndex + 1 < stageList.Count)
        {
            currentStageIndex++;
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
