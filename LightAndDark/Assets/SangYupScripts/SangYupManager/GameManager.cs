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
}
