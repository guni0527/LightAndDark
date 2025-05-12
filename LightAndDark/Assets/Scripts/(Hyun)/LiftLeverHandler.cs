using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftLeverHandler : MonoBehaviour
{
    [SerializeField] private Animator leverAnimator;
    [SerializeField] private LiftController liftController;

    private bool isActivated = false;

    public void PullLever()
    {
        if (isActivated)
        {
            return;
        }

        isActivated = true;
        leverAnimator.SetTrigger("LiftLever_Down");
        liftController.ActivateLift();
    }
}
