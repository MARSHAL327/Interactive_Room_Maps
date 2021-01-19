using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class UserData
{
    public static string name;
    public static string role;
}

public class Map : MonoBehaviour
{
    public Dropdown dropdown;
    public List<GameObject> objects = new List<GameObject>();
    public Transform parentCreatedElement;
    public GameObject roomPrefab;
    public GameObject roomPointOnCreate;
    public Text UserName;

    private GameObject selectedObject;
    private List<string> allElementNames = new List<string> { };
    private List<GameObject> allElementsInScene = new List<GameObject>();
    private GameObject createdElement; 
    private Vector3 roomPos1;
    private Vector3 roomPos2;
    private static GameObject activeNav;

    void Start()
    {    
        foreach (GameObject objectItem in objects) {
            allElementNames.Add(objectItem.GetComponent<Element>().elementName);
        }
        
        dropdown.AddOptions(allElementNames);

        UserName.text = UserData.name;
    }

    void Update()
    {

    }

    public List<GameObject> GetAllElementsInScene()
    {
        return allElementsInScene;
    }

    public void SelectedDropdownItem(int dropdownItem)
    {
        if(allElementNames.Count > 0 && dropdown.value != 0)
        {
            selectedObject = objects[dropdownItem - 1];
            CreateElement(selectedObject, parentCreatedElement);
        }
    }

    public IEnumerator CreateRoom()
    {
        int clickCounter = 0;

        while (clickCounter != 2)
        {
            roomPointOnCreate.SetActive(true);
            StartCoroutine(DragElement(roomPointOnCreate));
            if (Input.GetMouseButtonDown(0))
            {
                clickCounter++;
                switch (clickCounter)
                {
                    case 1:
                        roomPos1 = Input.mousePosition;
                        break;
                    case 2:
                        roomPointOnCreate.SetActive(false);
                        roomPos2 = Input.mousePosition;
                        GameObject newRect = Instantiate(roomPrefab, parentCreatedElement);
                        Vector2 roomSize = new Vector2(Mathf.Abs(roomPos1.x - roomPos2.x), Mathf.Abs(roomPos1.y - roomPos2.y));
                        newRect.GetComponent<RectTransform>().sizeDelta = roomSize;
                        newRect.GetComponent<RectTransform>().position = new Vector2((roomPos1.x + roomPos2.x) / 2, (roomPos1.y + roomPos2.y) / 2);
                        newRect.GetComponent<BoxCollider2D>().size = roomSize;
                        yield return null;
                        break;
                }
            }

            yield return new WaitForSeconds(0.01f);
        }
    }

    public void startCouratineCreateRoom()
    {
        StartCoroutine(CreateRoom());
    }

    public IEnumerator DragElement(GameObject el)
    {
        while (!Input.GetMouseButtonDown(0))
        {
            el.transform.position = Input.mousePosition;
            yield return new WaitForSeconds(0.01f);
        }
    }

    public void CreateElement(GameObject selectedObject, Transform parentElement)
    {
        createdElement = Instantiate(selectedObject, Input.mousePosition, Quaternion.identity, parentElement);
        allElementsInScene.Add(createdElement);

        dropdown.value = 0;
        StartCoroutine(DragElement(createdElement));
    }
}
