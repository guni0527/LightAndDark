using UnityEngine;


///
/// 클리어 시 플레이어가 충족한 조건에 따라 점수를 계산해서 지급하는 ScoreManager
///
public class ScoreManager : MonoBehaviour
{
    private StageData stageData;

    int currentPlayTime = 0;
    public void Init(StageData data)
    {
        stageData = data;
    }

    public int Score { get; private set; } = 0; // 점수의 기본 값

    public void StageClear() // 클리어 시 호출해서 점수를 추가해줌
    {
        AddClearScore();
        AddTimeBonus();
        Debug.Log($"총 점수는 {Score}점 입니다.");
    }

    public void AddClearScore() // 스테이지 클리어 시 지급되는 점수
    {
        Score += 2; 
        //스테이지 클리어 시 호출되므로 조건은 넣지 않음
    }


    public void AddTimeBonus() // 시간 내에 스테이지 클리어 시 지급되는 점수
    {
        stageData.playTime = currentPlayTime;

        if (stageData != null && stageData.timeLimit >= stageData.playTime)
            Score += 1; 
    }
}
