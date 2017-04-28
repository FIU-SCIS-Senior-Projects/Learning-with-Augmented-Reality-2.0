using UnityEngine;
using System.Collections;

public class DetailLoader : MonoBehaviour {

    public const string path = "details";

    public DetailContainer dc;

    // Use this for initialization
    void Awake()
    {

        dc = DetailContainer.Load(path);
    }
}
