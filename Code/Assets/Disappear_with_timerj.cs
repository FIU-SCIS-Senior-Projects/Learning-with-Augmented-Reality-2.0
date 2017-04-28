using UnityEngine;
using System.Collections;

public class Disappear_with_timer : MonoBehaviour {

    public GameObject viewport;

	// Use this for initialization
	void Start () {
        if (Time.time > 10)
        {
            viewport.SetActive(false);
        }

    }
}
