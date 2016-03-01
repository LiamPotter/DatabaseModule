using UnityEngine;
using System.Collections;
using UnityEditor;


[CustomEditor(typeof(DataBaseObject))]
public class DataBaseObjectEditor : Editor {

    //This is the Editor Script for the DataBaseObject script
    //Creating this Editor Script allows for more flexibility in code
    //and makes it easier to quickly add new objects

    private int dietIndex;

    private int behaviourIndex;
  
    //Will hide the Fauna options if 0, will display if 1
    private int hidingFaunaInt;
    //The three Object Types
    private string[] objectTypes = new string[] { "Flora", "Fauna", "Mineral" };
    //This int will be 0 for Flora, 1 for Fuana and 2 for Mineral
    public int selectedObjectType;
    //The three different Diet Options 
    private string[] dietOptions = new string[] {"Omnivore","Herbivore","Carnivore"};
    //The three different Behaviour Options
    private string[] behaviourOptions = new string[] { "Passive", "Aggressive", "Docile" };
    private DataBaseObject thisDataBaseObject;
    void OnEnable()
    {
        thisDataBaseObject = (DataBaseObject)target;
        selectedObjectType = thisDataBaseObject.oObjectType;
        dietIndex = thisDataBaseObject.oDiet;
        behaviourIndex = thisDataBaseObject.oBehaviourNumber;
    }
    public override void OnInspectorGUI()
    {
        
        thisDataBaseObject.oName=EditorGUILayout.TextField("Name",thisDataBaseObject.oName);
        thisDataBaseObject.oDescription = EditorGUILayout.TextField("Description", thisDataBaseObject.oDescription);
        selectedObjectType = EditorGUILayout.Popup("Object Type", selectedObjectType, objectTypes);

        //Sets the various bools based on the SelectedObjectType variable
        thisDataBaseObject.oObjectType = selectedObjectType;
        //This will hide the Diet Popup if the object is a plant, because plants do eat things... usually
        if (selectedObjectType!=1)
        {
            hidingFaunaInt = 0;
        }
        else hidingFaunaInt = 1;
        if (EditorGUILayout.BeginFadeGroup(hidingFaunaInt))
        {
            dietIndex = EditorGUILayout.Popup("Diet", dietIndex, dietOptions);
            behaviourIndex = EditorGUILayout.Popup("Behaviour", behaviourIndex, behaviourOptions);
        }
        EditorGUILayout.EndFadeGroup();
        thisDataBaseObject.oDiet = dietIndex;
        thisDataBaseObject.oBehaviourNumber = behaviourIndex;

        EditorGUILayout.LabelField("Index Number", thisDataBaseObject.oIndexNumber.ToString());
        EditorGUILayout.LabelField("ObectType", thisDataBaseObject.oObjectType.ToString());
        thisDataBaseObject.oSeenByPlayer = EditorGUILayout.Toggle("Seen By Player?", thisDataBaseObject.oSeenByPlayer);
        base.OnInspectorGUI();
    }
   
}
