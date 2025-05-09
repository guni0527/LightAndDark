using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���� �ý��� �߾� ���� Ŭ����
/// ����ġ �Է��� �����ϰ� ���� ������ �����Ǹ� ����Ʈ�� ������
/// </summary>
public class PuzzleSystem : MonoBehaviour
{
    public static PuzzleSystem Instance { get; private set; } // �̱��� �ν��Ͻ�

    [Header("������ ���� ����Ʈ��")]
    [SerializeField] private List<PuzzleGateController> gates; // ���� Ŭ���� ��  ���� ����Ʈ ���

    private HashSet<string> activatedSwitches = new HashSet<string>(); // ���� �۵����� ����ġ Ÿ�Ե��� �����ϴ� ���� (�ߺ�����)

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
            Destroy(gameObject); // �ߺ� ����
        }
    }

    /// <summary>
    /// �ܺο��� ����ġ ���°� ����� �� ȣ���
    /// ����ġ�� Ȱ��/��Ȱ�� ���¿� ���� ���� ���¸� ������Ʈ�ϰ� ���� ���� �˻� ����
    /// </summary>
    /// <param name="type"></param>
    /// <param name="isActivated"></param>
    public void UpdatePuzzleState(TriggerType type, bool isActivated)
    {
        string key = type.ToString(); // enum -> ���ڿ��� ��ȯ�Ͽ� ��

        if (isActivated)
        {
            activatedSwitches.Add(key); // ����ġ ON -> ���տ� �߰�
        }
        else
        {
            activatedSwitches.Remove(key); // ����ġ OFF -> ���տ��� ����
        }

        Debug.Log($"����ġ {key} ����: {(isActivated ? "ON" : "OFF")}");

        CheckPuzzleClear(); // ���� �˻�
    }

    /// <summary>
    /// ���� Ŭ���� ���� �˻�
    /// ��� TriggerType�� Ȱ��ȭ�Ǿ��� ��� ����Ʈ ����
    /// </summary>
    public void CheckPuzzleClear()
    {
        // ��� enum Ÿ���� ���տ� �����ϴ��� Ȯ��
        foreach (TriggerType type in System.Enum.GetValues(typeof(TriggerType)))
        {
            if (!activatedSwitches.Contains(type.ToString()))
            {
                Debug.Log($"{type} ����ġ�� ���� �������� -> ���� �̿Ϸ�");
                return;
            }
        }

        Debug.Log("��� ����ġ�� �۵���! -> ����Ʈ ����!");

        foreach (var gate in gates)
        {
            gate.OpenGate();
        }
    }
}
