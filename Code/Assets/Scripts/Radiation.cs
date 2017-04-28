using UnityEngine;
using System.Collections;

public class Radiation : MonoBehaviour {

    //Input Variables
    public float
        gridSizeX,
        gridSizeY,
        gridSizeZ;

    public GameObject[] transferPoints;

    public GameObject obj1;
    private GameObject obj;
    private GameObject[,,] M1;
    private bool[,,] M2;
    private bool running = false, autoApply = true, cube = false;
    private float objS = 6; // object size
    private float lifeP = 12f; // % random life
    private int
        gridS = 20, gS = 20,  // grid size
        popMin = 2, popMax = 12, // min, max live neighbors
        repMin = 5, repMax = 12, // min, max live neighbors for reproduction
        gen = 0, // generation count
        cells = 0; // live cell count


    // Use this for initialization
    void Start ()
    {
        obj = obj1;

        obj1.GetComponent<MeshRenderer>().enabled = true;

        InitGrid();
	}

    //Initializes Sphere Matrix
    void InitGrid()
    {
        //sets the initial scale of the spheres
        obj.transform.localScale = new Vector3(objS * .1f, objS * .1f, objS * .1f);
        //intializes a matrix of gameobjects and a boolean value for each point on this matirx
        M1 = new GameObject[gridS, gridS, gridS];
        M2 = new bool[gridS, gridS, gridS];
        //Initialization
        for (int z = 0; z < gridS; z++)
            for (int y = 0; y < gridS; y++)
                for (int x = 0; x < gridS; x++)
                {
                    //creates a clone of the input object, a position(depending on matrix position) for it, and a rotation for it 
                    M1[x, y, z] = Instantiate(obj, new Vector3((float)x, (float)y * -1, (float)z), transform.rotation) as GameObject;
                    
                    //Sets these clones to a default blue
                    M1[x, y, z].GetComponent<MeshRenderer>().material.color = Color.blue;
                }
        //chosses random startpoints
        M1[Random.Range(0, 1), Random.Range(0, 0), Random.Range(0, 2)].GetComponent<MeshRenderer>().material.color = Color.red;
        
        //hides the initial sphere
        obj.GetComponent<MeshRenderer>().enabled = false;
    }

    IEnumerator ApplyRules()
    {
        while (running || autoApply)
        {
            for (int z = 0; z < gridS; z++)
                for (int y = 0; y < gridS; y++)
                    for (int x = 0; x < gridS; x++)
                    {
                        //Checks for the number of nieghbors, 6x6 matrix
                        int n = 0; // neighbor count
                        for (int l = -1; l < 2; l++)
                            for (int k = -1; k < 2; k++)
                                for (int j = -1; j < 2; j++)

                                    //makes sure the loop skips the outer bounds of the grid
                                    if (x == 0 && j == -1 || y == 0 && k == -1 || z == 0 && l == -1)
                                    {
                                    }
                                    else if (x == gridS - 1 && j == 1 || y == gridS - 1 && k == 1 || z == gridS - 1 && l == 1)
                                    {
                                    }

                                    //if any of these points in the local matrix are red then add to the nieghboor total
                                    else if (M1[x + j, y + k, z + l].GetComponent<MeshRenderer>().material.color != Color.blue) n++;

                        //if any point in the world matrix are red
                        //if (M1[x, y, z].GetComponent<MeshRenderer>().material.color == Color.red)
                        if (M2[x, y, z] == true)
                        {

                            if (n == 0)
                            {
                                M2[x, y, z] = false;
                                cells--;
                            }
                            else
                            {
                                M2[x, y, z] = true;
                            }

                            //Die
                            //if the number of nieghbors for each local matrix are not within life ranges set them to false/ dead and subtract these cells from the world matrix
                            //else set them to true/ alive
                            //if (n < popMin || n > popMax) { M2[x, y, z] = false; cells--; } else { M2[x, y, z] = true; }
                        }
                        else {


                            if (n > Random.Range(0, 6))
                            {
                                M2[x, y, z] = true;
                                cells--;
                            }
                            else
                            {
                                M2[x, y, z] = false;
                            }

                            //Reproduce
                            //if the number of reproduction nieghbors for each local matrix are within life ranges then set them to true/ alive and add these cells to the world matrix
                            //else set them to false/ dead
                            //if (n > repMin && n < repMax) { M2[x, y, z] = true; cells++; } else { M2[x, y, z] = false; }
                        }

                    }

            //Enables the rendering of each point for each generation in regards to the parameters above
            for (int z = 0; z < gridS; z++)
            {
                //delay each generation
                //yield return new WaitForSeconds(1f);
                for (int y = 0; y < gridS; y++)
                    for (int x = 0; x < gridS; x++)
                    {

                        if (M2[x, y, z] == true)
                        {
                            //iSphere = M1[x, y, z];
                            //for (int t = 1; t < 10; t++)
                            //{
                            //M1[x, z, y].GetComponent<MeshRenderer>().material.color = Color.Lerp(b, r, .5f);
                            M1[x, z, y].GetComponent<MeshRenderer>().material.color = Color.red;
                            //}
                            //ColorChanger(iSphere);

                            //for (int t = 1; t < 10; t++)
                            //{
                            //yield return new WaitForSeconds(.01f);
                            //change = Color.Lerp(Color.blue, Color.red, (t/10) *Time.deltaTime);
                            //M1[x, z, y].GetComponent<MeshRenderer>().material.color = change;
                            //}
                            //gradualchange
                            //r = Color.Lerp(Color.blue, Color.red, .5f * Time.deltaTime);
                            //r = Color.Lerp(Color.blue, Color.red, Time.time);
                            //yield return WaitUntil
                        }
                        else
                        {
                            M1[x, z, y].GetComponent<MeshRenderer>().material.color = Color.blue;
                        }
                    }
            }
            //t++;
            gen++;
            running = false;
            yield return new WaitForSeconds(.01f);
            //yield return new WaitForSeconds(1 - (.0001f * gridS));
        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}
