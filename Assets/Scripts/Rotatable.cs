using UnityEngine;
using UnityEngine.EventSystems;

public class Rotatable : EventTrigger
{

    private bool rotating;

    public void Update()
    {
        if (rotating)
        {
            Transform rotateEl = transform.parent.parent;
            rotateEl.rotation = new Quaternion(0, 0, Input.mousePosition.x, 0); 
        }
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        rotating = true;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        rotating = false;
    }
}