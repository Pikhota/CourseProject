using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class MenuItems
    {
        [MenuItem("Tools/Clear PlayerPrefs")]
        private static void ClearPlayerPrefsAll()
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("All PlayerPrefs keys cleared");
        }
    }
}