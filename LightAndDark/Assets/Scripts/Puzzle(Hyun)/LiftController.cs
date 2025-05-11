using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// LiftComtroller
/// ����Ʈ �÷����� ���� �̵���Ű�� ������ ����ϴ� ��Ʈ�ѷ�
/// SwitchTriggerComponent���� ActivatiteLift()�� ȣ���ϸ� �̵� ����
/// </summary>
public class LiftController : MonoBehaviour
{
    [SerializeField] private Transform liftPlatform;
    [SerializeField] private Transform topPoint;
    [SerializeField] private Transform bottomPoint;
    [SerializeField] private float moveSpeed = 2f;

    private bool isMoving = false;

    /// <summary>
    /// �ܺο��� ȣ���Ͽ� ����Ʈ�� ���� �̵���Ű�� ����
    /// </summary>
    public void ActivateLift()
    {
        isMoving = true;
    }

    /// <summary>
    /// �� �����Ӹ��� ����Ʈ�� �̵� ������ üũ�ϰ�, ���������� �̵� ó��
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
