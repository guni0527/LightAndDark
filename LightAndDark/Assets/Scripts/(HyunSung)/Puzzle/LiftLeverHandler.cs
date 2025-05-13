using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// LiftLeverHandler
/// - 리프트 레버의 애니메이션 및 리프트 컨트롤러 연동을 담당.
/// - PullLeverDown() / PullLeverUp() 호출 시 레버 애니메이션 실행
/// </summary>
public class LiftLeverHandler : MonoBehaviour
{
    [SerializeField] private Animator leverAnimator;
    [SerializeField] private LiftController liftController;

    [Header("사운드")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip leverPullSound;

    /// <summary>
    /// 레버를 아래로 당겨서 애니메이션 실행
    /// </summary>
    public void PullLeverDown()
    {
        leverAnimator.SetTrigger("LiftLever_Down");
        audioSource?.PlayOneShot(leverPullSound);
    }

    /// <summary>
    /// 레버를 위로 올려서 애니메이션 실행
    /// </summary>
    public void PullLeverUp()
    {        
        leverAnimator.SetTrigger("LiftLever_Up");
        audioSource?.PlayOneShot(leverPullSound);
    }
}
