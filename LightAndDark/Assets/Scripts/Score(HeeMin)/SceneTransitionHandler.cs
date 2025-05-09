using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionHandler : MonoBehaviour
{
    public void MainScene() // 메인 화면으로 이동하기
    {
        SceneManager.LoadScene("MainScene");
    }

    public void StageSetScene() // 스테이지 선택 화면으로 이동하기
    {
        SceneManager.LoadScene("StageSetScene");
    }


    public void StageScene1() // 1번 스테이지로 이동하기
    {
        SceneManager.LoadScene("StageScene1");
    }


    public void StageScene2() // 2번 스테이지로 이동하기
    {
        SceneManager.LoadScene("StageScene2");
    }


    public void StageScene3() // 3번 스테이지로 이동하기
    {
        SceneManager.LoadScene("StageScene3");
    }


    public void StageScene4() // 4번 스테이지로 이동하기
    {
        SceneManager.LoadScene("StageScene4");
    }


    public void StageScene5() // 5번 스테이지로 이동하기
    {
        SceneManager.LoadScene("StageScene5");
    }


    public void StageClearScene() // 스테이지 클리어 씬 이동하기
    {
        // 그런데 스테이지 클리어는 단순히 스테이지 창에서 이미지를 만들어두고
        // 클리어하면 그 창을 활성화 하는 식으로 쓰는게 더 나을 수도 있을 듯 함.

        SceneManager.LoadScene("StageClearScene");
    }
}
