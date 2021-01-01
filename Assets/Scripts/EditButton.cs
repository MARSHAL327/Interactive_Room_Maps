using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditButton : MonoBehaviour
{
    public Button saveBtn;
    public Button cancelBtn;

    private List<string> listChangedInput = new List<string>();

    public void Start()
    {
        saveBtn.onClick.AddListener(() =>
        {
            saveData();
            gameObject.GetComponent<NavigationButton>().ToggleEditPlane(false);
        });

        cancelBtn.onClick.AddListener(() =>
        {
            cancelData();
            gameObject.GetComponent<NavigationButton>().ToggleEditPlane(false);
        });
    }

    public void cancelData() {
        for (int i = 0; i < gameObject.GetComponent<Element>().additionallyInfo.Count; i++)
        {
            gameObject.GetComponent<Element>().additionallyInfo[i].GetComponent<InputField>().text = listChangedInput[i];
        }

        listChangedInput.Clear();
    }

    public List<string> GetListChangedInput()
    {
        return listChangedInput;
    }

     public void saveData() {
        listChangedInput.Clear();
    }
}
