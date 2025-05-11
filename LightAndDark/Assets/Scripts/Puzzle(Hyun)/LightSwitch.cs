using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// LightSwitch
/// Light �Ǵ� Dark �÷��̾ ���� �� H Ű�� ���� ����(LightZone)�� ON/OFF�� ����
/// �����ڴ� ������ �����ϸ�, ������ �޴� ����� ��� ĳ������ �� ����
/// </summary>
public class LightSwitch : MonoBehaviour
{
    [SerializeField] private LightZone targetZone;

    private bool isInTrigger = false;

    /// <summary>
    /// �÷��̾ Ʈ���� �ȿ� �ְ� H Ű�� ������ ���� ���� ���
    /// </summary>
    private void Update()
    {
        if (isInTrigger && Input.GetKeyDown(KeyCode.H))
        {
            targetZone.ToggleLight();
        }
    }

    /// <summary>
    /// �÷��̾ Ʈ���ſ� �������� �� Light, Dark ���о��� ��� �ν�
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("LightPlayer") || other.CompareTag("DarkPlayer"))
        {
            isInTrigger = true;
        }
    }

    /// <summary>
    /// Ʈ���ſ��� ����� �Է� ��ȿȭ
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("LightPlayer") || other.CompareTag("DarkPlayer"))
        {
            isInTrigger = false;
        }
    }
}
