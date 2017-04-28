using UnityEngine;
using System.Collections;

public class DisplayLayer : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        //turns on gameObject this script is attached too
        gameObject.SetActive(true);
    }

    //FUNCTIONS//

    //toggles off and on a layer depending on its state
    public void toggle(GameObject model)
    {
        GameObject mod = model;

        if (mod.activeSelf == false)
        {
            open(mod);
        }

        else
        {
            close(mod);
        }
    }

    //turn on layer
    public void close(GameObject model)
    {
        GameObject mod = model;
        mod.SetActive(false);
    }

    //turn off layer
    public void open(GameObject model)
    {

        GameObject mod = model;
        mod.SetActive(true);

    }
}
