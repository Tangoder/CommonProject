using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class FloatUI : MonoBehaviour, IDragHandler, IPointerDownHandler,IPointerClickHandler
{
    [SerializeField] private RectTransform dragRectTransform;

    [SerializeField] private Canvas canvas;

    public RectTransform canvasRectTransform;

    public RectTransform backgroundRectTransform;

    public GameObject panel;

    void Update()
    {
        Vector2 anc = transform.GetComponent<RectTransform>().anchoredPosition;
        if(anc.x  > 910)
        {
            anc.x = 910;
        }
        if (anc.x < -910)
        {
            anc.x = -910;
        }
        if (anc.y > 490)
        {
            anc.y = 490;
        }
        if (anc.y < -490)
        {
            anc.y = -490;
        }
        transform.GetComponent<RectTransform>().anchoredPosition = anc;
    }

    public void OnDrag(PointerEventData eventData)
    {
        dragRectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }



    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        dragRectTransform.SetAsLastSibling();
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        panel.SetActive(true);
        gameObject.SetActive(false);
    }


}