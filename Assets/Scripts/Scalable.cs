using UnityEngine;
using UnityEngine.EventSystems;

public class Scalable : EventTrigger
{
    public bool scalable;
    private Vector3 pastMousePosition;

    public override void OnDrag(PointerEventData eventData)
    {
        if (scalable)
        {
            Vector3 deltaMouse = Input.mousePosition - pastMousePosition;
            pastMousePosition = Input.mousePosition;
            Transform scalableEl = transform.parent.parent;
            scalableEl.gameObject.GetComponent<RectTransform>().sizeDelta += (Vector2)deltaMouse;
        }
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        pastMousePosition = Input.mousePosition;
        scalable = true;
    }


    public override void OnPointerUp(PointerEventData eventData)
    {
        scalable = false;
    }
}
