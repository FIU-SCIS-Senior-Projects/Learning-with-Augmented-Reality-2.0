using UnityEngine;
using System.Collections;

/// <summary>
/// The M1 array contains GameObjects as cells.
/// M1[0, 0, 0].GetComponent<MeshRenderer>().enabled = true; // = living cell.
/// M1[0, 0, 0].GetComponent<MeshRenderer>().enabled = false; // = dead cell.
/// </summary>


public class AirVolume : MonoBehaviour {

    public GameObject obj1;
    private GameObject obj, cam, center;
    
    //an empty gameobject array called M1 with 3 arguments x,y,z
    //private GameObject[, ,] M1;
    private GameObject[, ,] M1;

    //The state of each point within M1
    private bool[, ,] M2;
	private bool running = false, autoApply = true, cube = false;
	private float
	lifeP = 12f, // % random life
	objS = 6; // object size

    //by adding a "," between each variable you can declare multiple variables with one label (ex. private int)
    //just make sure to finish with a standard ";"
    private int 
    gridS = 12, gS = 12,  // grid size
    popMin = 2, popMax = 12, // population min and population max of live neighbors
    repMin = 5, repMax = 12, // min and max number of possible live neighbors for reproduction
    cells = 0; // live cell count
    
    private bool state = false;


    /// <summary>
    /// Constructor
    /// </summary>
    void Start() {

        //Finds camera
		cam = GameObject.Find("Camera");
        //Debug.Log("The camera is found.", GameObject.Find("Camera"));
        center = GameObject.Find("Center");
        //initializes object1
        obj = obj1;
        //disables the 3D array grids of object2's so they don't render 
		//obj2.GetComponent<MeshRenderer>().enabled = false;
        InitGrid();
        //SetPointsState();
    }


	void InitGrid()
    {
        cells = 0;
        
        //controls the scale size of each cell
        obj.transform.localScale = new Vector3(objS * .1f, objS * .1f, objS * .1f);
        
        //creates a new array as a gameobject called M1 (which is the 3D grid) with the values given by variable
        M1 = new GameObject[gridS, gridS, gridS];
        
        //creates a new state variable for each point in M1
        M2 = new bool[gridS, gridS, gridS];
		for (int z = 0; z < gridS; z++)
			for (int y = 0; y < gridS; y++)
				for (int x = 0; x < gridS; x++)
                {
                    //Instantiates each point in M1 as a GameObject
					M1[x, y, z] = Instantiate(obj, new Vector3((float)x, (float)y * -1, (float)z), transform.rotation) as GameObject;
					cells++;
                }
        //Made the renderer always return true for each point
        //obj.GetComponent<MeshRenderer>().enabled = false;
        obj.GetComponent<MeshRenderer>().enabled = true;
        
        //I am hiding the inital obj's
        obj1.GetComponent<MeshRenderer>().enabled = false;
        //obj2.GetComponent<MeshRenderer>().enabled = false;
    }

    /*public GameObject[,,] GetHeatPoints(GameObject[,,] x, GameObject[,,]y, GameObject[,,] z)
    {
        return SetPointsState();
    }
    */

    public GameObject[,,] SetPointsState(GameObject[,,] M)
    {

        /*
        int x = gridS;
        int y = gridS;
        int z = gridS;
        */

        MeshRenderer mat;

        //GameObject[,,] StateList = new GameObject[x, y, z, state];

        for (int i = 0; i < gridS; i++)
        {
            state = M1[i, i, i];

            if (state == true)
            {
                mat = M1[i, i, i].GetComponent<MeshRenderer>();
                mat.material.color = Color.red;
            }
            else
            {
                mat = M1[i, i, i].GetComponent<MeshRenderer>();
                mat.material.color = Color.blue;
            }
            Debug.Log(M1[i, i, i].GetComponent<MeshRenderer>().material.color);
        }
        return M1;

            /*
            state = M1[i, i, i, state];

            if (state == true)
            {
                State[i, i, i, state] = M1[i, i, i];
            }
            else
            {
                StateList[i, i, i, state] = M1[i, i, i];
            }
        }
        return StateList;
        */
        }

    public void Radiate()
    {
        
    }

    public void ColorChange()
    {

    }

}
 