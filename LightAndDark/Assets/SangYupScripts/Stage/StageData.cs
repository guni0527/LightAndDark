using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StageData
{
    public string stageName; // 스테이지 이름    
    public float timeLimit; // 제한 시간 (초 단위)
    public string sceneName; // 해당 스테이지가 로드할 씬 이름

    public StageData(string stageName, int stageIndex, float timeLimit, string sceneName)
    {
        this.stageName = stageName;
        this.timeLimit = timeLimit;
        this.sceneName = sceneName;
    }    
}
