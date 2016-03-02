using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIObjectDropdown : MonoBehaviour {

    //These are the variables of the actual UI elements themselves, not the text that they hold
    public RectTransform infoContainer;
    public Text uIndexNumber;
    public Text uName;
    public Text uDescription;
    public Text uObjectType;
    //These two are the changable Extra Information blocks
    public Text uExtra1;
    public Text uExtra2;
    //These are the GameObjects of those two changable Extra Information Blocks
    public GameObject gExtra1;
    public GameObject gExtra2;

 
    [HideInInspector]
    public bool foundAllElements=false;
    public bool isOpen;

    void Awake()
    {
        if(!foundAllElements)
            FindAllNeededUIElements();
        isOpen = false;
    }
    void Update()
    {
        Vector3 scale = infoContainer.localScale;
        scale.y = Mathf.Lerp(scale.y,isOpen ? 1:0, Time.deltaTime * 20);
        infoContainer.localScale = scale;
    }
    public void OnButtonPress()
    {
        //This controls whether the dropdown is open or not
        isOpen = !isOpen;
    }
    public void FindAllNeededUIElements()
    {
        infoContainer = transform.FindChild("InfoContainer").GetComponent<RectTransform>();
        uIndexNumber = transform.FindChild("IndexLabel").GetComponent<Text>();
        uName = transform.FindChild("NameLabel").GetComponent<Text>();
        uDescription = infoContainer.transform.FindChild("Description").transform.GetChild(0).GetComponent<Text>();
        uObjectType = infoContainer.transform.FindChild("ObjectType").transform.GetChild(0).GetComponent<Text>();
        uExtra1 = infoContainer.transform.FindChild("ExtraInfo1").transform.GetChild(0).GetComponent<Text>();
        uExtra2 = infoContainer.transform.FindChild("ExtraInfo2").transform.GetChild(0).GetComponent<Text>();
        gExtra1 = infoContainer.transform.FindChild("ExtraInfo1").gameObject;
        gExtra2 = infoContainer.transform.FindChild("ExtraInfo2").gameObject;
        foundAllElements = true;
    }
}
