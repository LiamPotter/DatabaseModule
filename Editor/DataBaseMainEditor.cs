using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(DataBaseMain))]
public class DataBaseMainEditor : Editor {
    //This is the Editor Script for the DataBaseMain script

    private bool floraOpen;
    private bool faunaOpen;
    private bool mineralOpen;
    //private bool[] floraInfoBools;
    public override void OnInspectorGUI()
    {
        DataBaseMain thisDataBaseMain = (DataBaseMain)target;
        //floraInfoBools = new bool[thisDataBaseMain.dObjectsFloraList.Count];
        //EditorGUILayout.PrefixLabel("Database Objects");
        GUILayout.Label("Database Objects");
        EditorGUI.indentLevel = 1;
        floraOpen =EditorGUILayout.Foldout(floraOpen, "Flora");
        // int[] floraInfoInts = new int[thisDataBaseMain.dObjectsFloraList.Count];
        if (floraOpen)
        {
            for (int i = 0; i < thisDataBaseMain.dObjectsFloraList.Count; i++)
            {
                EditorGUI.indentLevel = 2;
                EditorGUILayout.Foldout(false, thisDataBaseMain.dObjectsFloraList[i].oName);
                Debug.Log("testForFloraOpening");
            }
        }
        EditorGUI.indentLevel = 1;
        faunaOpen = EditorGUILayout.Foldout(faunaOpen, "Fuana");
        if (faunaOpen)
        {
            for (int i = 0; i < thisDataBaseMain.dObjectsFaunaList.Count; i++)
            {
                EditorGUI.indentLevel = 2;
                EditorGUILayout.Foldout(false, thisDataBaseMain.dObjectsFaunaList[i].oName);
                Debug.Log("testForFuanaOpening");
            }
        }
        EditorGUI.indentLevel = 1;
        mineralOpen = EditorGUILayout.Foldout(mineralOpen, "Minerals");
        if(mineralOpen)
        {
            for (int i = 0; i < thisDataBaseMain.dObjectsMineralList.Count; i++)
            {
                EditorGUI.indentLevel = 2;
                EditorGUILayout.Foldout(false, thisDataBaseMain.dObjectsMineralList[i].oName);
                Debug.Log("testForMineralsOpening");
            }
        }

        if (GUILayout.Button("Find Database Objects"))
        {  
            DataBaseMain.FindAllDatabaseObjects(thisDataBaseMain.dObjectsList);
            DataBaseMain.SortAllDataBaseObjects(thisDataBaseMain.dObjectsList); 
            DataBaseMain.AddObjectsToSubLists(thisDataBaseMain.dObjectsList,thisDataBaseMain.dObjectsFloraList,thisDataBaseMain.dObjectsFaunaList,thisDataBaseMain.dObjectsMineralList);
            DataBaseMain.SortAllDataBaseObjects(thisDataBaseMain.dObjectsFloraList);
            DataBaseMain.SortAllDataBaseObjects(thisDataBaseMain.dObjectsFaunaList);
            DataBaseMain.SortAllDataBaseObjects(thisDataBaseMain.dObjectsMineralList);
            DataBaseMain.RemoveDuplicatesInDataBases(thisDataBaseMain.dObjectsList, thisDataBaseMain.dObjectsFloraList, thisDataBaseMain.dObjectsFaunaList, thisDataBaseMain.dObjectsMineralList);
            Debug.Log("HitButton");
        }
        if (GUILayout.Button("Reset Databases"))
        {
            thisDataBaseMain.dObjectsList.Clear();
            thisDataBaseMain.dObjectsFloraList.Clear();
            thisDataBaseMain.dObjectsFaunaList.Clear();
            thisDataBaseMain.dObjectsMineralList.Clear();
        }
    }
   
}
