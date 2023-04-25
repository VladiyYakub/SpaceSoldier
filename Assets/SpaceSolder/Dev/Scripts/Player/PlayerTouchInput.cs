using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerTouchInput : MonoBehaviour, IDragHandler
{
    [SerializeField] private float _rotateSpeed = 5f;

    private Vector2 _lastPosition;

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.pointerId != -1)
        {
            Vector2 delta = eventData.position - _lastPosition;
            transform.Rotate(0f, delta.x * _rotateSpeed, 0f);
        }
        _lastPosition = eventData.position;
    }
}
