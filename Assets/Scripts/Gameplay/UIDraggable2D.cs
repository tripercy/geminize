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
    private bool isInParent;
    private bool isMoveable;
    private Vector3[] parentCorners;
    private Vector3[] currentCorners;

    void Start()
    {
        parent = transform.parent.gameObject;
        transform.GetChild(0).GetChild(0).GetComponent<ScrollRectNoDrag>().SetParent(this.transform.gameObject);
        isInParent = true;
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
        if (!isMoveable) {
            rectTransform.anchoredPosition = new Vector2(ClampToParent(transform.localPosition).x, ClampToParent(transform.localPosition).y);
        }
        // CalculateValidPosition();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isInParent)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
            parent.transform as RectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out Vector2 localPoint);

            offset = rectTransform.anchoredPosition - localPoint;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isInParent)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
            parent.transform as RectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out Vector2 localPoint);

            Vector2 newPosition = localPoint + offset;
            rectTransform.anchoredPosition = ClampToParent(newPosition);
            // print(ClampToParent(rectTransform.anchoredPosition));
            // print(rectTransform.anchoredPosition);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // You can add code here if you need to do something when dragging ends.
    }

    private Vector2 ClampToParent(Vector2 position)
    {
        Vector3 pBottomLeft = parentCorners[0];
        Vector3 pTopRight = parentCorners[2];

        Vector3 cBottomLeft = currentCorners[0];
        Vector3 cTopRight = currentCorners[2];

        float minX = cBottomLeft.x;
        float maxX = cTopRight.x;
        float minY = cBottomLeft.y;
        float maxY = cTopRight.y;

        Vector2 clampedPosition = position;

        // Clamp X
        if (minX <= pBottomLeft.x)
        {
            clampedPosition.x = position.x + (pBottomLeft.x - minX);
            isMoveable = false;
        }
        else if (maxX >= pTopRight.x)
        {
            clampedPosition.x = position.x - (maxX - pTopRight.x);
            isMoveable = false;
        }

        // Clamp Y
        if (minY <= pBottomLeft.y)
        {
            clampedPosition.y = position.y + (pBottomLeft.y - minY);
            isMoveable = false;
        }
        else if (maxY >= pTopRight.y)
        {
            clampedPosition.y = position.y - (maxY - pTopRight.y);
            isMoveable = false;
        }

        return clampedPosition;
    }

    private void CalculateValidPosition()
    {
        Vector3 pBottomLeft = parentCorners[0];
        Vector3 pTopRight = parentCorners[2];

        Vector3 cBottomLeft = currentCorners[0];
        Vector3 cTopRight = currentCorners[2];

        float parentMinX = pBottomLeft.x;
        float parentMaxX = pTopRight.x;
        float parentMinY = pBottomLeft.y;
        float parentMaxY = pTopRight.y;

        float childMinX = cBottomLeft.x;
        float childMaxX = cTopRight.x;
        float childMinY = cBottomLeft.y;
        float childMaxY = cTopRight.y;

        isInParent = parentMaxX >= childMaxX && parentMaxY >= childMaxY && parentMinX <= childMinX && parentMinY <= childMinY;
    }
}
