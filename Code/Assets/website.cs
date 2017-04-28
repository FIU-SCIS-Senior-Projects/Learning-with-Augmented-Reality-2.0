using UnityEngine;
using System.Collections;

public class ExampleClass : MonoBehaviour
{
    void Start()
    {
        if (GUILayout.Button("Click Me"))
        {
            Application.OpenURL("http://unity3d.com/");
        }
    }
}