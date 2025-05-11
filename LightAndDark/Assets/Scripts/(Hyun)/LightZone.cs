using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// LightZone
/// 특정 구역의 조명 상태를 제어하는 클래스
/// ON/OFF 상태에 따라 시각적 효과 및 퍼즐 판정에 영향을 줌
/// </summary>
public class LightZone : MonoBehaviour
{
    [SerializeField] private GameObject lightVisual;
    private bool isLightOn = true;

    /// <summary>
    /// 조명의 현재 상태를 반전시키고, 시각적 오브젝트를 ON/OFF 처리
    /// </summary>
    public void ToggleLight()
    {
        isLightOn = !isLightOn;
        lightVisual.SetActive(isLightOn);
        Debug.Log($"조명 상태: {(isLightOn ? "켜짐" : "꺼짐")}");
    }

    public bool IsLit => isLightOn;
}
