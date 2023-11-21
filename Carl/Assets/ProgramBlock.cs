using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.EventSystems;
using UnityEngine.EventSystems;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class ProgramBlock : MonoBehaviour, /**IPointerDownHandler,**/ IEndDragHandler, IBeginDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private int snap;
    public RectTransform rectTransform;
    public GameObject ghost;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        ghost = Instantiate(gameObject, canvas.transform);
        ghost.GetComponent<Image>().color = new Color32(200, 200, 200, 100);
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        ghost.GetComponent<ProgramBlock>().rectTransform.anchoredPosition = new Vector2(-300, Mathf.Round(rectTransform.anchoredPosition.y / 50) * 50);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        dropHandler();
    }

    public void dropHandler()
    {
        Destroy(ghost);
        if (rectTransform.anchoredPosition.x > 0)
        {
            Destroy(gameObject);
        }
        rectTransform.anchoredPosition = new Vector2(-300, Mathf.Round(rectTransform.anchoredPosition.y / 50) * 50);
    }

    public void dropHandler(int index)
    {
        
    }
}
