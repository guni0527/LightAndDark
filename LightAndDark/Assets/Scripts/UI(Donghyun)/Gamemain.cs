using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Gamemain : MonoBehaviour
{
    [SerializeField]
    private Image[] SelectImages;
    [SerializeField]
    private int SelectNum = 0;
    [SerializeField]
    private Image cursurImage;


    private void Start()
    {
        for (int i = 0; i < SelectImages.Length; i++)
        {
            int index = i;

            EventTrigger trigger = SelectImages[i].gameObject.GetComponent<EventTrigger>();
            if (trigger == null)
            {
                trigger = SelectImages[i].gameObject.AddComponent<EventTrigger>();
            }

            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerEnter;
            entry.callback.AddListener((data) => { HandleMouseEnter(index); });
            trigger.triggers.Add(entry);
        }
    }

    private void HandleMouseEnter(int index)
    {
        SelectNum = index;
        UpdateSelectionVisual();
    }

    private void UpdateSelectionVisual()
    {
        for (int i = 0; i < SelectImages.Length; i++)
        {
            SelectImages[i].color = new Color(1f, 1f, 1f, 0.2f);
        }
        SelectImages[SelectNum].color = new Color(1f, 1f, 1f, 1f);

        cursurImage.rectTransform.position = new Vector3(cursurImage.rectTransform.position.x, SelectImages[SelectNum].rectTransform.position.y, cursurImage.rectTransform.position.z);
    }
}
