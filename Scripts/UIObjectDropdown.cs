using UnityEngine;
using System.Collections;

public class UIObjectDropdown : MonoBehaviour {
    public RectTransform infoContainer;
    public bool isOpen;
    void Start()
    {
        infoContainer = transform.FindChild("InfoContainer").GetComponent<RectTransform>();
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
        isOpen = !isOpen;
        Debug.Log("trying to open");
    }
}
