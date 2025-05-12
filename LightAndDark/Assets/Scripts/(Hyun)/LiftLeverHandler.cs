using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftLeverHandler : MonoBehaviour
{
    [SerializeField] private Animator leverAnimator;
    [SerializeField] private LiftController liftController;

    public void PullLeverDown()
    {
        leverAnimator.SetTrigger("LiftLever_Down");
    }

    public void PullLeverUp()
    {        
        leverAnimator.SetTrigger("LiftLever_Up");
    }
}
