using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

///
/// 필요한 화면을 불러올 수 있는 함수를 만들어두고 저장해두는 SceneTransitionHandler
///
public class SceneTransitionHandler : MonoBehaviour
{
    public GameObject MainScreen;
    public GameObject ClearScreen;
    public GameObject CreditScreen;
    public GameObject SelectStageScreen;

    public GameObject ScoreStar; // 결과창 3번째 별 이미지

    private ScoreManager scoremanager;

    public void ShowMainScreen() // 다른 창 끄고 메인 화면만 출력하기
    {
        Debug.Log("메인 화면 호출 시도");

        if (MainScreen != null)
        {
            HideAllScreens();
            MainScreen.SetActive(true);
        }
        else
        {
            Debug.LogWarning("MainScreen 연결 안됨");
        }
    }    

    public void ShowCreditScreen() // 다른 창 끄고 크레딧 화면만 출력하기
    {
        if (CreditScreen != null)
        {
            HideAllScreens();
            CreditScreen.SetActive(true);
        }
    }

    public void ShowSelectStageScreen() // 다른 창 끄고 스테이지 선택 화면만 출력하기
    {
        HideAllScreens();
        if (SelectStageScreen != null)
        {
            SelectStageScreen.SetActive(true);
        }
    }

    public void ShowClearScreen() // 클리어 화면 출력하기
    {
        if (ClearScreen != null)
        {
            ClearScreen.SetActive(true);

            if (ScoreStar != null)
            {
                if (scoremanager.Score <= 2)
                {
                    ScoreStar.SetActive(false); // 점수가 2 이하라면 마지막 별 별 하나 비활성화
                }
                else
                {
                    ScoreStar.SetActive(true); // 점수가 3 이상이라면 마지막 별 하나 활성화
                }
            }
        }
    }

    public void HideAllScreens() // 모든 창 끄기
    {
        MainScreen.SetActive(false);
        ClearScreen.SetActive(false);
        CreditScreen.SetActive(false);
        SelectStageScreen.SetActive(false);
    }
}
