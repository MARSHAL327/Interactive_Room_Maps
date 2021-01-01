using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*[System.Serializable]
public struct AdditionallyInfo
{
    public Text infoName;
    public InputField infoValue;
}*/

public class Element : MonoBehaviour
{
    public List<GameObject> additionallyInfo;
    public string elementName;

    void Start()
    {
    }

    void Update()
    {
    }

    public void SetAdditionallyInfo(List<GameObject> newList)
    {
        additionallyInfo = newList;
    }
}
