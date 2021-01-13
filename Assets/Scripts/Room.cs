using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room : MonoBehaviour
{
    private Camera Cam;
    private string markName;
    public GameObject textMark;
    private Button room;
    private List<string> allMarks = new List<string> { "Спортзал", "Столовая", "Кабинет" };

    void Start()
    {
        room = GetComponent<Button>();
    }

    public List<string> GetAllMarks()
    {
        return allMarks;
    }

    public void CreateMark(string markName) {
        this.markName = markName;
    }

    public void fieldMark()
    {
        textMark.GetComponent<Text>().text = markName;
    }

}
