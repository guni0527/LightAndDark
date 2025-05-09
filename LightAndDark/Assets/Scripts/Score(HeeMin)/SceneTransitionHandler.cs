using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionHandler : MonoBehaviour
{
    public void MainScene() // ���� ȭ������ �̵��ϱ�
    {
        SceneManager.LoadScene("MainScene");
    }

    public void StageSetScene() // �������� ���� ȭ������ �̵��ϱ�
    {
        SceneManager.LoadScene("StageSetScene");
    }


    public void StageScene1() // 1�� ���������� �̵��ϱ�
    {
        SceneManager.LoadScene("StageScene1");
    }


    public void StageScene2() // 2�� ���������� �̵��ϱ�
    {
        SceneManager.LoadScene("StageScene2");
    }


    public void StageScene3() // 3�� ���������� �̵��ϱ�
    {
        SceneManager.LoadScene("StageScene3");
    }


    public void StageScene4() // 4�� ���������� �̵��ϱ�
    {
        SceneManager.LoadScene("StageScene4");
    }


    public void StageScene5() // 5�� ���������� �̵��ϱ�
    {
        SceneManager.LoadScene("StageScene5");
    }


    public void StageClearScene() // �������� Ŭ���� �� �̵��ϱ�
    {
        // �׷��� �������� Ŭ����� �ܼ��� �������� â���� �̹����� �����ΰ�
        // Ŭ�����ϸ� �� â�� Ȱ��ȭ �ϴ� ������ ���°� �� ���� ���� ���� �� ��.

        SceneManager.LoadScene("StageClearScene");
    }
}
