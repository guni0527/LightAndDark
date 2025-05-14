using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamemain : MonoBehaviour
{
    [SerializeField]
    private Image[] SelectImages;
    [SerializeField]
    private int SelectNum = 0;
    [SerializeField]
    private Image cursurImage;


    private void SelectBtn()
    {
        if (SelectNum > 0)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                SelectNum--;
            }
        }
        if (SelectNum < SelectImages.Length - 1)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                SelectNum++;
            }
        }
        for (int i = 0; i < SelectImages.Length; i++)
        {
            SelectImages[i].color = new Color(1f, 1f, 1f, 0.2f);
            if (SelectImages[SelectNum])
            {
                SelectImages[SelectNum].color = new Color(1f, 1f, 1f, 1f);
            }
        }

        cursurImage.rectTransform.position = new Vector3(cursurImage.rectTransform.position.x, SelectImages[SelectNum].rectTransform.position.y, cursurImage.rectTransform.position.z);
    }
    void Update()
    {
        SelectBtn();
    }
}
