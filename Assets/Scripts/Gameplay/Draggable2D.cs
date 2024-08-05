using UnityEngine;

public class Draggable2D : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging = false;

    private void OnMouseOver() {
        print("Draggable2D");
    }
    void OnMouseDown()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset = transform.position - new Vector3(mousePosition.x, mousePosition.y, 0);
        isDragging = true;
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y, 0) + offset;
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
    }
}
