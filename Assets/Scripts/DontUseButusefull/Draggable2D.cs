using UnityEngine;

public class Draggable2D : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging = false;


    
    void OnMouseOver() {
        print(transform.gameObject.name);
    }

    void OnMouseDown()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset = transform.position - new Vector3(mousePosition.x, mousePosition.y, 0);
        isDragging = true;
        print(mousePosition);
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
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        // Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // print(mousePosition);
        // print(this.transform.position);
    }
}
