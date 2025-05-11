using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionHandler : MonoBehaviour
{
    StageData stageData;
    private string targetScene;

    void Start()
    {
        targetScene = stageData.sceneName;
    }

    public void MainScene() // ���� ȭ������ �̵��ϱ�
    {
        SceneManager.LoadScene("MainScene");
    }

    public void StageSetScene() // �������� ���� ȭ������ �̵��ϱ�
    {
        SceneManager.LoadScene("StageSetScene");
    }


    public void StageScene() // ������ ���������� �̵��ϱ�
    {
        SceneManager.LoadScene(targetScene);
    }

    public void StageClearScene() // �������� Ŭ���� �� �̵��ϱ�
    {
        // �׷��� �������� Ŭ����� �ܼ��� �������� â���� �̹����� �����ΰ�
        // Ŭ�����ϸ� �� â�� Ȱ��ȭ �ϴ� ������ ���°� �� ���� ���� ���� �� ��.

        SceneManager.LoadScene("StageClearScene");
    }
}
