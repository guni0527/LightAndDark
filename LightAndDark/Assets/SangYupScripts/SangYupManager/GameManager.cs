using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Playing,        // ���� �������� �÷��� ��
        StageClear,     // �������� Ŭ����
        StageFail,      // ���� (�ð� �ʰ�, ĳ���� ��� ��)
    }

    public static GameManager Instance {  get; private set; }

    public GameState CurrentState { get; private set; } = GameState.Playing;
}
