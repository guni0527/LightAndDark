using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StageData
{
    public string stageName; // �������� �̸�    
    public float timeLimit; // ���� �ð� (�� ����)
    public string sceneName; // �ش� ���������� �ε��� �� �̸�

    public StageData(string stageName, int stageIndex, float timeLimit, string sceneName)
    {
        this.stageName = stageName;
        this.timeLimit = timeLimit;
        this.sceneName = sceneName;
    }    
}
