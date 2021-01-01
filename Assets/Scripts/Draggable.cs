using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : EventTrigger
{
    public bool dragging;
    private Vector2 dragOffset;

    public void Update()
    {
        if (dragging)
        {
            transform.position = (Vector2)Input.mousePosition + dragOffset;
        }
    }

    public override void OnPointerDown(PointerEventData eventData)
    {

        dragging = true;
        dragOffset = (Vector2)transform.position - (Vector2)Input.mousePosition;
    }


    public override void OnPointerUp(PointerEventData eventData)
    {
        dragging = false;
    }
}