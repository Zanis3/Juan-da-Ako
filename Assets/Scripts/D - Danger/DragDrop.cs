using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CanvasGroup))]
public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTrans;
    public Canvas myCanvas;
    private CanvasGroup canvasGroup;
    private Vector3 initWorldPos;
    private bool isFlyingAway = false;
    [Header("Fly away settings")]
    [Tooltip("How long the fly-away animation takes in seconds.")]
    public float flyDuration = 0.5f;
    [Tooltip("Extra distance (in pixels) beyond the screen edge to move to before destroying.")]
    public float flyExtraPixels = 200f;
    [Tooltip("Distance before reaching the edge of the screen to trigger fly-away (in pixels).")]
    public float triggerDistanceBeforeEdge = 200f;
    void Start()
    {
        rectTrans = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        initWorldPos = transform.position;
        if (myCanvas == null)
        {
            myCanvas = GetComponentInParent<Canvas>();
        }
        // Register with GameManager (if exists)
        if (GameManager.Instance != null)
        {
            GameManager.Instance.RegisterDraggable(this);
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        rectTrans.anchoredPosition += eventData.delta / myCanvas.scaleFactor;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        if (isFlyingAway)
        {
            return;
        }
        Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(myCanvas.worldCamera, rectTrans.position);
        bool nearEdge = IsNearScreenEdge(screenPoint, out Vector2 direction);
        if (nearEdge)
        {
            StartCoroutine(FlyAwayAndDestroy(direction));
        }
        else
        {
            ResetPosition();
        }
    }
    // ✅ Detect if object is NEAR (not past) the screen edge
    private bool IsNearScreenEdge(Vector2 screenPoint, out Vector2 dir)
    {
        dir = Vector2.zero;
        float sw = Screen.width;
        float sh = Screen.height;
        bool nearEdge = false;
        // left
        if (screenPoint.x < triggerDistanceBeforeEdge)
        {
            dir = Vector2.left;
            nearEdge = true;
        }
        // right
        else if (screenPoint.x > sw - triggerDistanceBeforeEdge)
        {
            dir = Vector2.right;
            nearEdge = true;
        }
        // bottom
        else if (screenPoint.y < triggerDistanceBeforeEdge)
        {
            dir = Vector2.down;
            nearEdge = true;
        }
        // top
        else if (screenPoint.y > sh - triggerDistanceBeforeEdge)
        {
            dir = Vector2.up;
            nearEdge = true;
        }
        return nearEdge;
    }
    private IEnumerator FlyAwayAndDestroy(Vector2 direction)
    {
        isFlyingAway = true;
        canvasGroup.blocksRaycasts = false;
        Vector2 startScreen = RectTransformUtility.WorldToScreenPoint(myCanvas.worldCamera, rectTrans.position);
        Vector2 endScreen = startScreen + (direction.normalized * (Mathf.Max(Screen.width, Screen.height) + flyExtraPixels));
        Vector3 startWorld = rectTrans.position;
        Vector3 endWorld;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(rectTrans, endScreen, myCanvas.worldCamera, out Vector3 worldPoint))
        {
            endWorld = worldPoint;
        }
        else
        {
            endWorld = startWorld + (Vector3)(direction.normalized) * (Mathf.Max(Screen.width, Screen.height) / myCanvas.scaleFactor);
        }
        float t = 0f;
        while (t < flyDuration)
        {
            t += Time.deltaTime;
            float normalized = Mathf.Clamp01(t / flyDuration);
            float ease = 1f - Mathf.Pow(1f - normalized, 3f); // ease-out
            transform.position = Vector3.Lerp(startWorld, endWorld, ease);
            transform.Rotate(Vector3.forward, 720f * Time.deltaTime);
            yield return null;
        }
        if (GameManager.Instance != null)
        {
            GameManager.Instance.NotifyDraggableDestroyed(this);
        }
        Destroy(gameObject);
    }
    public void ResetPosition()
    {
        transform.position = initWorldPos;
        isFlyingAway = false;
    }
    private void OnDestroy()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.UnregisterIfNeeded(this);
        }
    }
}
