using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int Score = 0; // ������ �⺻ ��

    public void StageClear() // Ŭ���� �� ȣ���ؼ� ������ �߰�����
    {
        CheckLevelClear();
        CheckTimeLimit();
        Check();
    }

    public void CheckLevelClear() // �������� Ŭ���� �� ���޵Ǵ� ����
    {
        Score += 1; 
        //�������� Ŭ���� �� ȣ��ǹǷ� ������ ���� ����
    }


    public void CheckTimeLimit() // �ð� ���� �������� Ŭ���� �� ���޵Ǵ� ����
    {
        //IF (���� �ð� <= Ŭ������� �ɸ� �ð� )
        Score += 1; 
    }

    public void Check() // 3��° ����
    {
        //IF (3��° ����)
        Score += 1;
    }






}


// ���� ���� �� ���ǿ� ���� �ִ� 3���� ȹ���Ѵ�.

// ���� ������ 0���� �������ش�.
// ���Ǹ��� ���� void�� ���� �������� �� ���� ��� �ҷ����� void�� ������ش�.

//�� ���� ���� void�� Ŭ���� �Ŀ� �ҷ��ͼ� ������ ä���Ѵ�.

// ���� ȹ�� ���� �� ���� �ð��� ���� ��쿡�� ������������ �ٸ��״� �������� ��ũ��Ʈ���� ������ �ҷ��ͼ� ������ش�.
// �������� ��ũ��Ʈ���� �������� Ŭ���� �ð��� ����ϱ� ���� 1�ʸ��� 1�� �����ϴ� ������ �����ؾ��� �� ��