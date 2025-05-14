using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public enum GameState
    {
        Playing,        // 현재 스테이지 플레이 중
        StageClear,     // 스테이지 클리어
        StageFail,      // 실패 (시간 초과, 캐릭터 사망 등)
        GameOver        // 캐릭터 사망 후 연출 포함 게임 오버 상태
    }

    public GameState CurrentState { get; private set; } = GameState.Playing; // 현재 게임 상태

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this; // 싱글톤 패턴 적용 중복 인스턴스 방지
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetGameState(GameState newState) // 게임 상태 설정
    {
        CurrentState = newState;

        switch (newState)
        {
            case GameState.Playing:
                break;

            case GameState.StageClear:
                Debug.Log("스테이지 클리어");
                StageManager.Instance.LoadNextStage(); // 다음 스테이지 해금
                break;
            case GameState.StageFail:
                Debug.Log("스테이지 실패");
                SetGameState(GameState.GameOver); // 실패 시 게임오버 상태
                break;
            case GameState.GameOver:
                Debug.Log("게임 오버"); // 실제 게임 오버 처리 수행
                HandleGameOver();       // 캐릭터 사망 애니메이션 처리
                break;
        }
    }

    private void HandleGameOver() // 캐릭터 사망 처리 함수
    {
        PlayerState[] players = FindObjectsOfType<PlayerState>();

        foreach (var player in players)
        {
            if (!player.IsDead)
            {
                player.Die();
            }
        }
    }

    public void RetryStage()
    {
        int currentIndex = StageManager.Instance.CurrentStageIndex;
        StageManager.Instance.LoadStage(currentIndex); // 현재 씬 이름 가져오기
    }    
}
