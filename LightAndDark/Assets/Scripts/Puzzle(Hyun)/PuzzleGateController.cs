using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���� ����Ʈ ���� ������Ʈ
/// PuzzleSystem�� ���� ������ �� ����
/// </summary>
public class PuzzleGateController : MonoBehaviour
{
    [Header("���� ��ġ ������")]
    [SerializeField] private Vector3 openOffset = new Vector3(0, 3, 0);

    [Header("���� �ӵ�")]
    [SerializeField] private float openSpeed = 2f;

    private bool isOpened = false;
    private Vector3 closedPosition;
    private Vector3 openedPosition;

    void Start()
    {
        closedPosition = transform.position;
        openedPosition = closedPosition + openOffset;
    }

    /// <summary>
    /// �ܺο��� ȣ��Ǿ� ���� ���� �ż���
    /// �ߺ� ȣ���� �����ϰ� �ڷ�ƾ ����
    /// </summary>
    public void OpenGate()
    {
        if (isOpened)
        {
            return;
        }

        isOpened = true;
        StartCoroutine(OpenGateRoutine());
    }

    /// <summary>
    /// ���� �ε巴�� ������ �ڷ�ƾ
    /// ��ǥ ��ġ���� ���� �ӵ��� �̵�
    /// </summary>
    /// <returns></returns>
    private IEnumerator OpenGateRoutine()
    {
        while ((transform.position - openedPosition).sqrMagnitude > 0.0001f)
        {
            transform.position = Vector3.MoveTowards(transform.position, openedPosition, openSpeed * Time.deltaTime);

            yield return null;
        }
        transform.position = openedPosition;
    }
}
