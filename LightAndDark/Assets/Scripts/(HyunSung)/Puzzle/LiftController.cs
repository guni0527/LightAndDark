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

    [Header("사운드")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip liftSound;

    private bool isMovingUp = false;
    private bool isMovingDown = false;

    private void Update()
    {
        if (isMovingUp || isMovingDown)
        {
            float targetY = isMovingUp ? topPoint.position.y : bottomPoint.position.y;
            Vector3 target = isMovingUp ? topPoint.position : bottomPoint.position;

            liftPlatform.position = Vector3.MoveTowards(liftPlatform.position, target, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(liftPlatform.position, target) < 0.01f)
            {
                isMovingUp = false;
                isMovingDown = false;
            }
        }
        
    }

    /// <summary>
    /// 외부에서 호출하여 리프트를 위로 이동시키기 시작 (외부 호출용)
    /// </summary>
    public void ActivateLiftUp()
    {
        isMovingUp = true;
        isMovingDown = false;
        audioSource?.PlayOneShot(liftSound);
    }

    /// <summary>
    /// 리프트를 아래로 이동 시작 (외부 호출용)
    /// </summary>
    public void ActivateLiftDown()
    {
        isMovingUp = false;
        isMovingDown = true;
        audioSource?.PlayOneShot(liftSound);
    }

}
