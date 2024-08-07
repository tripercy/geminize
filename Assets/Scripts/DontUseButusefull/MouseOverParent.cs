using UnityEngine;
using UnityEngine.EventSystems;

public class MouseOverParent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private GameObject parentElement;

    void Start()
    {
        parentElement = transform.parent.gameObject;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // When the mouse enters the child element
        Debug.Log("Mouse over child element");
        Debug.Log("Parent element: " + parentElement.name);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // When the mouse exits the child element
        Debug.Log("Mouse exited child element");
    }
}
