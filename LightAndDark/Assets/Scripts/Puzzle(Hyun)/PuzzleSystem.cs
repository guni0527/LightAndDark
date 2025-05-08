using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���� �ý��� �߾� ���� Ŭ����
/// ����ġ �Է��� �����ϰ� ���� ������ �����Ǹ� ����Ʈ�� ������
/// </summary>
public class PuzzleSystem : MonoBehaviour
{
    public static PuzzleSystem Instance { get; private set; }

    [Header("������ ���� ����Ʈ��")]
    [SerializeField] private List<PuzzleGateController> gates;

    private HashSet<string> activatedSwitches = new HashSet<string>();

    /// <summary>
    /// �̱��� �ν��Ͻ� �ʱ�ȭ
    /// ���� �� �ϳ��� PuzzleSystem�� �����ϵ��� ����
    /// </summary>
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// ����ġ���� ���� �Է��� �����Ͽ� ���¸� �����ϰ� ���� Ȯ��
    /// �ߺ� �Է��� ����
    /// </summary>
    /// <param name="type"></param>
    public void TriggerFromSwitch(string type)
    {
        if (activatedSwitches.Contains(type))
        {
            return;
        }

        activatedSwitches.Add(type);
        Debug.Log($"����ġ �Է�: {type}");

        CheckPuzzleClear();
    }

    /// <summary>
    /// ���� Ŭ���� ���� �˻�
    /// ��� ������ �����Ǹ� ����� ����Ʈ���� ����
    /// </summary>
    public void CheckPuzzleClear()
    {
        if (activatedSwitches.Contains("Light") && activatedSwitches.Contains("Dark"))
        {
            Debug.Log("��� ����ġ�� �۵���! -> ����Ʈ ����");

            foreach (var gate in gates)
            {
                gate.OpenGate();
            }
        }      
    }
}
