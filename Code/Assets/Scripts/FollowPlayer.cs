using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

    private TextMesh text;
    private Rigidbody r;
    private GameObject player;
    public bool icon;

	// Use this for initialization
	void Start ()
    {
        text = gameObject.GetComponentInChildren<TextMesh>();
        r = gameObject.AddComponent<Rigidbody>();
        r.isKinematic = true;
        r.useGravity = false;
        player = GameObject.FindGameObjectWithTag("IconCamera");
	}
	
	// Update is called once per frame
	void Update ()
    {
        followData();
	}

    public void followData()
    {
        //Debug.Log(texts[i].name + "rotating");
        r.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        r.transform.LookAt(player.transform.parent.position);
        if (icon)
        {
            r.transform.Rotate(new Vector3(90, 0, 0));
        }
        else
        {
            r.transform.Rotate(new Vector3(270, 180, 90));
        }
    }
}
