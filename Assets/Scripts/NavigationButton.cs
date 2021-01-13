using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NavigationButton : MonoBehaviour, IPointerClickHandler
{
    public GameObject navBtn;
    public Button scaleBtn;
    public Button rotateBtn;
    public Button deleteBtn;
    public Button markBtn;
    public GameObject editPlane;
    public GameObject MarkMenu;

    private Map Map;
    private Room Room;
    private Button editableObject;
    private Dropdown roomMarks;
    private bool editActive = false;
    private bool showNav = false;

    void Start()
    {
        Map = GameObject.Find("Map").GetComponent<Map>();
        editableObject = gameObject.GetComponent<Button>();
        Room = gameObject.GetComponent<Room>();
        roomMarks = MarkMenu.GetComponent<Dropdown>();

        roomMarks.AddOptions(Room.GetAllMarks());

        deleteBtn.onClick.AddListener(() => {
            DeleteElement();
        });

        rotateBtn.onClick.AddListener(() => {
            RotateElement();
        });

        editableObject.onClick.AddListener(() =>
        {
            /*foreach (GameObject item in Map.GetAllElementsInScene())
            {
                bool thisNav = item.GetComponent<NavigationButton>().showNav;
                if (thisNav == true)
                {
                    thisNav = false;
                    ToggleInterface(item, thisNav);
                }
            }*/

            showNav = !showNav;
            ToggleInterface(showNav);
        });

        roomMarks.onValueChanged.AddListener(delegate
        {
            Room.CreateMark(Room.GetAllMarks()[roomMarks.value - 1]);
            Room.fieldMark();
            ToggleInterface(false);
        });
    }

    public void DeleteElement()
    {
        Destroy(gameObject);
    }

    public void RotateElement()
    {
        navBtn.transform.Rotate(0f, 0f, -90f);
        gameObject.transform.Rotate(0f, 0f, 90f);
    }

    public void ToggleInterface(bool isShow)
    {
        navBtn.SetActive(isShow);
        MarkMenu.SetActive(isShow);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        int clickCount = eventData.clickCount;

        if (clickCount == 2)
            OnDoubleClick();
    }

    void OnDoubleClick()
    {
        if(gameObject.GetComponent<Element>().additionallyInfo.Count > 0)
        {
            ToggleInterface(false);
            ToggleEditPlane(true);
        }
    }

    public void ToggleEditPlane(bool editValue) {
        foreach (GameObject item in gameObject.GetComponent<Element>().additionallyInfo)
        {
            gameObject.GetComponent<EditButton>().GetListChangedInput().Add(item.GetComponent<InputField>().text);
        }

        editActive = editValue;
        editPlane.SetActive(editActive);
    }
}
