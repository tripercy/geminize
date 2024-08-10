using System.Numerics;
using UnityEngine;
using UnityEngine.EventSystems;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class UIDraggable2D : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector2 offset;
    private RectTransform rectTransform;
    public GameObject parent;
    private bool isMoveable;
    private Vector3[] parentCorners;
    private Vector3[] currentCorners;

    void Start()
    {
        parent = transform.parent.gameObject;
        transform.GetChild(0).GetChild(0).GetComponent<ScrollRectNoDrag>().SetParent(this.transform.gameObject);
        isMoveable = true;

        parentCorners = new Vector3[4];
        parent.GetComponent<RectTransform>().GetWorldCorners(parentCorners);

        currentCorners = new Vector3[4];
        rectTransform = GetComponent<RectTransform>();
        rectTransform.GetWorldCorners(currentCorners);
    }
    void Update()
    {
        rectTransform.GetWorldCorners(currentCorners);
        if (!isMoveable)
        {
            rectTransform.anchoredPosition = new Vector2(ClampToParent(transform.localPosition).x, ClampToParent(transform.localPosition).y);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
        parent.transform as RectTransform,
        eventData.position,
        eventData.pressEventCamera,
        out Vector2 localPoint);

        // Calculate offset in local space
        offset = rectTransform.localPosition - (Vector3)localPoint;
    }

    public void OnDrag(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
        parent.transform as RectTransform,
        eventData.position,
        eventData.pressEventCamera,
        out Vector2 localPoint);

        // Calculate the new position in local space
        Vector2 newPosition = localPoint + (Vector2)offset;

        // Clamp the new position to the parent's bounds in local space
        rectTransform.localPosition = ClampToParent(newPosition);
    }

    private Vector2 ClampToParent(Vector2 position)
{
    RectTransform parentRectTransform = parent.GetComponent<RectTransform>();
    RectTransform childRectTransform = rectTransform;

    // Get the world corners of the parent RectTransform
    Vector3[] parentCorners = new Vector3[4];
    parentRectTransform.GetWorldCorners(parentCorners);

    // Convert parent corners to local space of the parent
    Vector3 bottomLeftLocal = parentRectTransform.InverseTransformPoint(parentCorners[0]);
    Vector3 topRightLocal = parentRectTransform.InverseTransformPoint(parentCorners[2]);

    // Calculate half size of the child RectTransform
    Vector2 childHalfSize = new Vector2(childRectTransform.rect.width / 4, childRectTransform.rect.height / 4);

    // Clamp the position considering the size of the child RectTransform
    float clampedX = Mathf.Clamp(position.x, bottomLeftLocal.x + childHalfSize.x, topRightLocal.x - childHalfSize.x);
    float clampedY = Mathf.Clamp(position.y, bottomLeftLocal.y + childHalfSize.y, topRightLocal.y - childHalfSize.y);

    return new Vector2(clampedX, clampedY);
}


    public void OnEndDrag(PointerEventData eventData)
    {
    }
}
