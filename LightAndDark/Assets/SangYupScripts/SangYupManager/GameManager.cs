using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Playing,        // 현재 스테이지 플레이 중
        StageClear,     // 스테이지 클리어
        StageFail,      // 실패 (시간 초과, 캐릭터 사망 등)
    }

    public static GameManager Instance {  get; private set; }

    public GameState CurrentState { get; private set; } = GameState.Playing;

    private void Awake()
    {
        if (Instance == null) Instance = this; // 싱글톤 패턴 적용 중복 인스턴스 방지
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
                Debug.Log("스테이지 클리어");
                StageManager.Instance.UnlockNextStage(); // 다음 스테이지 해금
                break;
            case GameState.StageFail:
                Debug.Log("스테이지 실패");
                break;
        }
    }

    public void RetryStage()
    {
        //SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex); // 현재 씬 다시 로드 (재시작)
    }    
}
