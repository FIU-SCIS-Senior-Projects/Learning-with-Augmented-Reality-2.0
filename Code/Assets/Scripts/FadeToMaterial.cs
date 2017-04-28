using UnityEngine;
using System.Collections;

public class FadeToMaterial : MonoBehaviour {

	void OnEnable()
    {
        EventManager.StartListening("MajorComponent", fadeTransparent);
    }

    void OnDisable()
    {

    }

    public void fadeTransparent()
    {

    }
}
