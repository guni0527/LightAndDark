using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// LiftComtroller
/// 리프트 플랫폼을 위로 이동시키는 역할을 담당하는 컨트롤러
/// SwitchTriggerComponent에서 ActivatiteLift()를 호출하면 이동 시작
/// </summary>
public class LiftController : MonoBehaviour
{
    [SerializeField] private Transform liftPlatform;
    [SerializeField] private Transform topPoint;
    [SerializeField] private Transform bottomPoint;
    [SerializeField] private float moveSpeed = 2f;

    private bool isMoving = false;

    /// <summary>
    /// 외부에서 호출하여 리프트를 위로 이동시키기 시작
    /// </summary>
    public void ActivateLift()
    {
        isMoving = true;
    }

    /// <summary>
    /// 매 프레임마다 리프트가 이동 중인지 체크하고, 목적지까지 이동 처리
    /// </summary>
    void Update()
    {
        if (isMoving)
        {
            liftPlatform.position = Vector3.MoveTowards(liftPlatform.position, topPoint.position, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(liftPlatform.position, topPoint.position) < 0.01f)
            {
                isMoving = false;
            }
        }
    }
}
