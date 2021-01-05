using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System;

public class Draggable : EventTrigger
{
    public bool dragging;
    private Vector2 dragOffset;
    private Vector2 prevPos;
    /*private int gridSize = 50;
    private List<int> gridX;
    private List<int> gridY;*/


    public void Start()
    {
        /*int gridSizeX = Screen.currentResolution.width / gridSize;
        int gridSizeY = Screen.currentResolution.height / gridSize;
        gridX = new List<int>(gridSizeX);
        gridY = new List<int>(gridSizeY);
        for (int i = 50; i < gridSizeX; i += 50)
        {
            gridX.Add(i);
        }

        for (int i = 50; i < gridSizeY; i += 50)
        {
            gridY.Add(i);
        }*/
    }

    public void Update()
    {
        if (dragging)
        {
            transform.position = (Vector2)Input.mousePosition + dragOffset;
            /*Vector2 gridSize = new Vector2(50, 50);
            int gridOffset = 10;
            if( Input.mousePosition.x > prevPos.x + gridSize.x)
            {
                transform.position = new Vector3(transform.position.x + gridSize.x, transform.position.y);
            } else if (Input.mousePosition.x < prevPos.x - gridSize.x)
            {
                transform.position = new Vector3(transform.position.x - gridSize.x, transform.position.y);
            }
            else if (Input.mousePosition.y > prevPos.y + gridSize.y)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + gridSize.y);
            }
            else if (Input.mousePosition.y < prevPos.y - gridSize.y)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - gridSize.y);
            }
            dragging = false;*/
            /*if ( 
                (
                (
                (Input.mousePosition.x % gridSize >= 40 &&
                Input.mousePosition.x % gridSize <= 49)
                ) ||
                (
                (Input.mousePosition.x % gridSize >= 0 &&
                Input.mousePosition.x % gridSize <= 10)
                )
                )
                &&
                (
                (
                (Input.mousePosition.y % gridSize >= 40 &&
                Input.mousePosition.y % gridSize <= 49)
                ) ||
                (
                (Input.mousePosition.y % gridSize >= 0 &&
                Input.mousePosition.y % gridSize <= 10)
                )
                )
                )
            {
                transform.position = (Vector2)Input.mousePosition + dragOffset;
                Debug.Log("xy = " + Input.mousePosition);
            }*/

            /*if (
                ((Input.mousePosition.x - gridOffset) % (gridSize - gridOffset) == 0 ) &&
                ((Input.mousePosition.y - gridOffset) % (gridSize - gridOffset) == 0 )
                )
            {
                transform.position = (Vector2)Input.mousePosition + dragOffset;
            }*/
        }
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        dragging = true;
        prevPos = (Vector2)transform.position;
        dragOffset = (Vector2)transform.position - (Vector2)Input.mousePosition;
    }


    public override void OnPointerUp(PointerEventData eventData)
    {
        dragging = false;
    }
}