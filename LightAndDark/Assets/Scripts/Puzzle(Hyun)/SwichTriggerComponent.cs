using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����ġ Ʈ���� ������Ʈ
/// �÷��̾ Ư�� ����ġ�� �����ϸ� PuzzleSystem�� Ʈ���� ��ȣ�� ����
/// </summary>
public class SwichTriggerComponent : MonoBehaviour
{
    [SerializeField] private TriggerType triggerType;

    private enum TriggerType
    {
        Light,
        Dark
    }

    /// <summary>
    /// �÷��̾ Ʈ���� ���� �������� �� �����
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((triggerType == TriggerType.Light && other.CompareTag("LightPlayer")) || (triggerType == TriggerType.Dark && other.CompareTag("DarkPlayer")))
        {
            Debug.Log($"{triggerType} ����ġ �۵�!");
            PuzzleSystem.Instance.TriggerFromSwitch(triggerType.ToString());
        }
    }
}
