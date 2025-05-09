using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftComtroller : MonoBehaviour
{
    [SerializeField] private Transform liftPlatform;
    [SerializeField] private Transform topPoint;
    [SerializeField] private Transform bottomPoint;
    [SerializeField] private float moveSpeed = 2f;

    private bool isMoving = false;

    public void ActivateLift()
    {
        isMoving = true;
    }

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
