using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(DataBaseMain))]
public class DataBaseMainEditor : Editor {
    //This is the Editor Script for the DataBaseMain script

    private bool floraOpen;
    private bool fuanaOpen;
    private bool mineralOpen;
    //private bool[] floraInfoBools;
    public override void OnInspectorGUI()
    {
        DataBaseMain thisDataBaseMain = (DataBaseMain)target;
        //floraInfoBools = new bool[thisDataBaseMain.dObjectsFloraList.Count];
        EditorGUILayout.PrefixLabel("Database Objects");
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
        fuanaOpen = EditorGUILayout.Foldout(fuanaOpen, "Fuana");
        if (fuanaOpen)
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
    }
}
