using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ����ġ Ʈ���� ������Ʈ
/// �÷��̾ Ư�� ����ġ�� �����ϸ� PuzzleSystem�� Ʈ���� ��ȣ�� ����
/// </summary>
public class SwitchTriggerComponent : MonoBehaviour
{     
    [SerializeField] private TriggerType triggerType;       // �۵� ������ �Ǵ� �÷��̾� Ÿ�� (Light �Ǵ� Dark)
    [SerializeField] private PuzzleSystem puzzleSystem;     // ���� ���¸� ������ PuzzleSystem ����

    private bool isTrigger = false;      // �÷��̾ ���� Ʈ���� ���� �ȿ� �ִ��� ����
    private bool isActivated = false;    // ���� ����ġ�� Ȱ��ȭ �������� ����

    /// <summary>
    /// �� �����Ӹ��� �Է��� üũ�Ͽ� Ʈ���� �ȿ� ���� �� HŰ�� ����ġ�� �۵���Ŵ
    /// </summary>
    private void Update()
    {
        if (isTrigger && Input.GetKeyDown(KeyCode.Space))
        {
            ToggleSwitch();
        }
    }

    /// <summary>
    /// ����ġ ���¸� �������� PuzzleSystem�� ������, ���� �ð���/ û���� �ǵ�� ó������
    /// </summary>
    private void ToggleSwitch()
    {
        isActivated = !isActivated;
        puzzleSystem.UpdatePuzzleState(triggerType, isActivated);

        // TODO: ����Ʈ or ���� ����
        // AudioSource.Play(), Animator.SetTrigger("Activate") ��
    }

    /// <summary>
    /// �÷��̾ Ʈ���� ���� �������� �� �����
    /// ��ȿ�� �÷��̾�(TriggerType�� ��ġ)�� ��� Ʈ���� Ȱ��ȭ
    /// </summary>
    /// <param name="other">Ʈ���ſ� ���� �ݶ��̴�</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (IsValidPlayer(other))
        {
            isTrigger = true;
        }
    }

    /// <summary>
    /// �÷��̾ Ʈ���� ������ ����� �� ȣ���
    /// ��ȿ�� �÷��̾��� ��� Ʈ���� ��Ȱ��ȭ
    /// </summary>
    /// <param name="other">Ʈ���ſ��� ���� �ݶ��̴�</param>
    private void OnTriggerExit2D(Collider2D other)
    {
        if (IsValidPlayer(other))
        {
            isTrigger = false;
        }
    }

    /// <summary>
    /// �浹�� ��ü�� ���� ����ġ�� Ÿ�԰� ��ġ�ϴ� �÷��̾����� �Ǻ�
    /// </summary>
    /// <param name="other">�浹�� �ݶ��̴�</param>
    /// <returns>�ش� �÷��̾ ��ȿ�� Ÿ���� ��� true</returns>
    private bool IsValidPlayer(Collider2D other)
    {
        return (triggerType == TriggerType.Light && other.CompareTag("LightPlayer")) || (triggerType == TriggerType.Dark && other.CompareTag("DarkPlayer"));
    }
}
