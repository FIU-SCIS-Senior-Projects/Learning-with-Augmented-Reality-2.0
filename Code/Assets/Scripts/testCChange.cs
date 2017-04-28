using UnityEngine;
using System.Collections;

public class testCChange : MonoBehaviour
{

    float duration = 5f;
    private float t = 0;
    bool isReset = false;

    void Update()
    {
        //if (Input.GetKeyDown("space"))
        //{
            ColorChangerr();
        //}
    }


    void ColorChangerr()
    {
        //if (this.tag == true)
        //{
        duration = duration + (t * Time.deltaTime);

            GetComponent<Renderer>().material.color = Color.Lerp(Color.blue, Color.red, t);

            if (t < 1)
            {
                t += Time.deltaTime / duration;
            }

        //}

    }
}