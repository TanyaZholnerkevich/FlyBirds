using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Text choosenText;

    public void OnPointerDown(PointerEventData eventData)
    {
        string name = gameObject.name;
        choosenText.text = name;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale *= 1.1f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale /= 1.1f;
    }
}
