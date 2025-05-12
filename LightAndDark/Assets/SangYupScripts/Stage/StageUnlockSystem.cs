using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageUnlockSystem : MonoBehaviour
{
    public static StageUnlockSystem Instance {  get; private set; }
    private HashSet<int> unlockedStages = new HashSet<int>(); // �رݵ� �������� �ε������� �����ϴ� HashSet

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        LoadUnlockedStages();
    }

    private void LoadUnlockedStages()
    {
        unlockedStages.Clear();
        int count = PlayerPrefs.GetInt("UnlockedStageCount", 1); // �⺻�� 1�� �ر�
        for (int i = 0; i < count; i++) // �⺻������ �������� 0�� �׻� �رݵ� ���·� ����
        {
            unlockedStages.Add(i);
        }
    }

    public bool IsStageUnlocked(int stageIndex) // Ư�� ���������� �رݵǾ����� ���θ� ��ȯ
    {
        return unlockedStages.Contains(stageIndex);
    }

    public void UnlockStage(int stageIndex) // ���ο� ���������� �ر��ϰ�, ����
    {
        if (!unlockedStages.Contains(stageIndex))
        {
            unlockedStages.Add(stageIndex);
            PlayerPrefs.SetInt("UnlockedStageCount", unlockedStages.Count); // �ر� �������� �� ����
            PlayerPrefs.Save();
        }
    }

    public List<int> GetUnlockedStages() // ���� �رݵ� ��� �������� �ε����� ����Ʈ�� ��ȯ
    {
        return new List<int>(unlockedStages);
    }

    public void ResetStage() // ��� ���������� ��� ���·� �ʱ�ȭ
    {
        unlockedStages.Clear();
        PlayerPrefs.DeleteKey("UnlockedStageCount");
    }
}
