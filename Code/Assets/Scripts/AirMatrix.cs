using UnityEngine;
using System.Collections;

public class AirMatrix : MonoBehaviour {

    int x = 10;
    int y = 10;
    int z = 10;

    public Air[,,] grid;

	// Use this for initialization
	void Start () {

        //Air grid[,,] = new Air[x, y, z];

        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                for (int k = 0; k < z; k++)
                {
                    Vector3 ptLoc = new Vector3(i * 10, j * 10, 0);
                    //grid[i][j][k] = new Air(ptLoc, i, j);
                }
                    
            }
        }

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
