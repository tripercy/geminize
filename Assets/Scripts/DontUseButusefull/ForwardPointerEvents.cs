using UnityEngine;
using UnityEngine.EventSystems;

public class ForwardPointerEvents : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    private GameObject parentElement;

    void Start()
    {
        parentElement = transform.parent.gameObject;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ExecuteEvents.Execute(parentElement, eventData, ExecuteEvents.pointerEnterHandler);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ExecuteEvents.Execute(parentElement, eventData, ExecuteEvents.pointerExitHandler);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ExecuteEvents.Execute(parentElement, eventData, ExecuteEvents.pointerDownHandler);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ExecuteEvents.Execute(parentElement, eventData, ExecuteEvents.pointerUpHandler);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ExecuteEvents.Execute(parentElement, eventData, ExecuteEvents.pointerClickHandler);
    }
}
