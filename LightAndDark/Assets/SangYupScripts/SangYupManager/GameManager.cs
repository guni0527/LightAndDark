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

    private void Awake()
    {
        if (Instance == null) Instance = this; // �̱��� ���� ���� �ߺ� �ν��Ͻ� ����
        else Destroy(gameObject);
    }

    public void SetGameState(GameState newState)
    {
        CurrentState = newState;

        switch (newState)
        {
            case GameState.Playing:
                break;

            case GameState.StageClear:
                Debug.Log("�������� Ŭ����");
                //StageManager.Instance.UnlockNextStage(); // ���� �������� �ر�
                break;
            case GameState.StageFail:
                Debug.Log("�������� ����");
                break;
        }
    }

    public void RetryStage()
    {
        //SceneManager.LoadScene(UnityEngine.SceneManagment.SceneManager.GetActiveScene().buildIndex); // ���� �� �ٽ� �ε� (�����)
    }    
}
