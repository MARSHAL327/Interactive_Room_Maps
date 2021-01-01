using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Room : MonoBehaviour
{
    private Camera Cam;
    private string markName;
    private Button room;

    void Start()
    {
        room = GetComponent<Button>();
    }

    void Update()
    {
    }

    public void CreateMark(string markName) {

    }
}
