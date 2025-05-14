using UnityEngine;
using UnityEngine.SceneManagement;

///
/// 필요한 씬을 불러올 수 있는 함수를 만들어두는 SceneTransitionHandler
///
public class SceneTransitionHandler : MonoBehaviour
{
    StageData stageData;
    private string sceneName;

    public void Init(StageData data)
    {
        stageData = data;
        sceneName = data.sceneName;
    }

    public void MainScene() // 메인 화면으로 이동하기
    {
        SceneManager.LoadScene("MainScene");
    }

    public void StageSetScene() // 스테이지 선택 화면으로 이동하기
    {
        SceneManager.LoadScene("StageSetScene");
    }


    public void StageScene() // 지정된 스테이지로 이동하기
    {
        SceneManager.LoadScene(sceneName);
    }

    public void StageClearScene() // 스테이지 클리어 씬 이동하기
    {
        // 그런데 스테이지 클리어는 단순히 스테이지 창에서 이미지를 만들어두고
        // 클리어하면 그 창을 활성화 하는 식으로 쓰는게 더 나을 수도 있을 듯 함.

        SceneManager.LoadScene("StageClearScene");
    }
}
