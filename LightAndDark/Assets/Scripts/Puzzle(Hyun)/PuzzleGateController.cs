using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���� ����Ʈ ���� ������Ʈ
/// PuzzleSystem�� ���� ������ �� ����
/// Ư�� ����ġ Ÿ�Ե��� ��� Ȱ��ȭ�Ǹ� ����
/// </summary>
public class PuzzleGateController : MonoBehaviour
{
    [Header("���� ��ġ ������")]
    [SerializeField] private Vector3 openOffset = new Vector3(0, 3, 0);

    [Header("���� �ӵ�")]
    [SerializeField] private float openSpeed = 2f;

    [Header("�ʿ��� ����ġ Ÿ�Ե�")]
    [SerializeField] private List<TriggerType> requiredTriggers;

    private bool isOpened = false;
    private Vector3 closedPosition;
    private Vector3 openedPosition;
    private Dictionary<TriggerType, bool> triggerStates = new();

    void Start()
    {
        closedPosition = transform.position;
        openedPosition = closedPosition + openOffset;

        foreach (var trigger in requiredTriggers)
        {
            triggerStates[trigger] = false;
        }
    }

    /// <summary>
    /// puzzleSystem���� Ʈ���� ���°� �ٲ� �� ȣ���
    /// </summary>
    /// <param name="triggerType">����ġ Ÿ�� (Light / Dark)</param>
    /// <param name="isActivated">�ش� ����ġ�� Ȱ��ȭ �Ǿ����� ����</param>
    public void UpdateGateState(TriggerType triggerType, bool isActivated)
    {       
        if (triggerStates.ContainsKey(triggerType))
        {
            Debug.Log($"[����Ʈ] {gameObject.name} �� {triggerType}: {isActivated}");

            triggerStates[triggerType] = isActivated;

            foreach (var kv in triggerStates)
            {
                Debug.Log($" - ���� {kv.Key}: {kv.Value}");
            }

            if (IsConditionMet())
            {
                Debug.Log($"[����Ʈ ���� ���� ����]: {gameObject.name}");
                OpenGate();
            }
            else
            {
                Debug.Log($"[����Ʈ ���� ���� ������] -> ���� ������ ����: {gameObject.name}");
            }
        }
    }

    /// <summary>
    /// ���� ��� ����ġ ������ �����Ǿ����� Ȯ��
    /// </summary>
    /// <returns>��� ������ �����Ǹ� true</returns>
    private bool IsConditionMet()
    {
        foreach (var trigger in requiredTriggers)
        {
            if (!triggerStates[trigger])
            {
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// �ܺο��� ȣ��Ǿ� ���� ���� �ż���
    /// �ߺ� ȣ���� �����ϰ� �ڷ�ƾ ����
    /// </summary>
    public void OpenGate()
    {
        if (isOpened)
        {
            return;
        }

        isOpened = true;
        StartCoroutine(OpenGateRoutine());
    }

    /// <summary>
    /// ���� �ε巴�� ������ �ڷ�ƾ
    /// ��ǥ ��ġ���� ���� �ӵ��� �̵�
    /// </summary>
    /// <returns></returns>
    private IEnumerator OpenGateRoutine()
    {
        while ((transform.position - openedPosition).sqrMagnitude > 0.0001f)
        {
            transform.position = Vector3.MoveTowards(transform.position, openedPosition, openSpeed * Time.deltaTime);

            yield return null;
        }
        transform.position = openedPosition;
    }
}
