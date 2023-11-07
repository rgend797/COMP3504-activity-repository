using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.EventSystems;
using UnityEngine.EventSystems;
using Palmmedia.ReportGenerator.Core;

public class clickAndDrag : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private GameObject PB;
    private GameObject newPB;
    //private RectTransform rectTransform;

        /**private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
        }
        public void OnBeginDrag(PointerEventData eventData)
        {
            Debug.Log("BeginDrag");
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            Debug.Log("EndDrag");
        }

    **/
    public void OnPointerDown(PointerEventData eventData)
    {
        newPB = Instantiate(PB, canvas.transform);
        newPB.SetActive(true);

        Debug.Log("PointerDown");
        
        
    }
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");

        newPB.GetComponent<ProgramBlock>().movee(eventData);
    }

    /**public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
    }
    **/
}



