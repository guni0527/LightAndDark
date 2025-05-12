using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// LightZone
/// Ư�� ������ ���� ���¸� �����ϴ� Ŭ����
/// ON/OFF ���¿� ���� �ð��� ȿ�� �� ���� ������ ������ ��
/// </summary>
public class LightZone : MonoBehaviour
{
    [SerializeField] private GameObject lightVisual;
    private bool isLightOn = true;

    /// <summary>
    /// ������ ���� ���¸� ������Ű��, �ð��� ������Ʈ�� ON/OFF ó��
    /// </summary>
    public void ToggleLight()
    {
        isLightOn = !isLightOn;
        lightVisual.SetActive(isLightOn);
        Debug.Log($"���� ����: {(isLightOn ? "����" : "����")}");
    }

    public bool IsLit => isLightOn;
}
