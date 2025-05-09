using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int Score = 0; // 점수의 기본 값

    public void StageClear() // 클리어 시 호출해서 점수를 추가해줌
    {
        CheckLevelClear();
        CheckTimeLimit();
        Check();
    }

    public void CheckLevelClear() // 스테이지 클리어 시 지급되는 점수
    {
        Score += 1; 
        //스테이지 클리어 시 호출되므로 조건은 넣지 않음
    }


    public void CheckTimeLimit() // 시간 내에 스테이지 클리어 시 지급되는 점수
    {
        //IF (제한 시간 <= 클리어까지 걸린 시간 )
        Score += 1; 
    }

    public void Check() // 3번째 조건
    {
        //IF (3번째 조건)
        Score += 1;
    }






}


// 게임 종료 시 조건에 따라서 최대 3점을 획득한다.

// 점수 변수를 0으로 선언해준다.
// 조건마다 각각 void로 만들어서 세가지를 한 번에 묶어서 불러오는 void를 만들어준다.

//세 개가 묶인 void를 클리어 후에 불러와서 점수를 채점한다.

// 점수 획득 조건 중 제한 시간과 같은 경우에는 스테이지마다 다를테니 스테이지 스크립트에서 변수를 불러와서 계산해준다.
// 스테이지 스크립트에서 스테이지 클리어 시간을 계산하기 위해 1초마다 1씩 증가하는 변수도 존재해야할 듯 함