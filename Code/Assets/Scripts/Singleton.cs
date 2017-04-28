using UnityEngine;
using System.Collections;

public class Singleton : MonoBehaviour {

    private static Singleton instance;

    public static Singleton Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Singleton>();

                if (instance == null)
                {
                    GameObject go = new GameObject("Singleton");
                    instance = go.AddComponent<Singleton>();
                    Debug.Log("Singleton created!");
                }
            }
            return instance;
        }
    }
}
