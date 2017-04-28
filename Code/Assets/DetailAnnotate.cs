using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(LineRenderer))]
//[RequireComponent(typeof(MeshCollider))]
public class DetailAnnotate : DetailLoader
{
    //Major Components
    //Put this script on each model to be annotated.
    //Assign each model a value.

    //Initialises the annotation materials, player, and parts from root's children.
    //Disables the exception colliders if any, at start.
    //Hides the transparent copy if there is on, at start.
    //Activates the subcomponets only when the return button is active.

    private static int NUM_OF_FIELDS = 7;
    private static int FONT_SIZE = 80;
    private bool created = false;
    public Transform root;

    public List<Collider> colliders = new List<Collider>();
    public Transform[] parts;
    //public Transform hideAtStart;
    public Transform returnButton;

    //For Lines
    private LineRenderer line;
    private Vector3[] points = new Vector3[2];
    private Material lineMaterial;
    private Texture tex;
    private Color pColorA = Color.cyan;
    private Color pColorB = Color.clear;
    private List<LineRenderer> lines = new List<LineRenderer>();
    public List<Vector3> oldPos = new List<Vector3>();
    public List<Vector3> newPos = new List<Vector3>();
    private bool activate = false;
    private bool moved = false;
    private float width = .03f;

    private Collider currentCollider;

    public List<Collider> subColliders = new List<Collider>();

    public List<Transform> disableColliders = new List<Transform>();

    //For Text
    public TextMesh text;
    public int excelNum;
    private List<Transform> models = new List<Transform>();
    private List<TextMesh> texts = new List<TextMesh>();
    private Rigidbody r;

    SubComponent subComp;

    private GameObject player;

    //private OrganizedDetail od;

    // Use this for initialization
    void Start()
    {
        //Initializes text materials
        lineMaterial = (Material)Resources.Load("Lines");
        tex = (Texture)Resources.Load("White Aluminum");

        //Gets the player
        player = GameObject.FindGameObjectWithTag("User");

        //Gets all the subcomponent parts
        parts = root.GetComponentsInChildren<Transform>();
        //Debug.Log("test" + parts.Length);

        //Gets all the colliders from the subcomponets
        for (int i = 0; i < parts.Length; i++)
        {
            if (parts[i].GetComponent<Collider>() != null)
            {
                colliders.Add(parts[i].GetComponent<Collider>());
                //Debug.Log(colliders.Count);
            }
        }

        //Disables the exception colliders
        for (int i = 0; i < disableColliders.Count; i++)
        {
            disableColliders[i].GetComponent<Collider>().enabled = false;
        }


        //for (int i = 0; i < colliders.Count; i++)
        //{
        //colliders[i].enabled = false;
        //}

        //hideAtStart.gameObject.SetActive(false);

        //GameObject.Object Prefab
        //text = (TextMesh)Resources.Load("Annotation");
    }

    // Update is called once per frame
    void Update()
    {
        ray();

        if (returnButton.gameObject.activeSelf == true)
        {
            for (int i = 0; i < colliders.Count; i++)
            {
                colliders[i].enabled = true;
            }
        }

        else
        {
            for (int i = 0; i < colliders.Count; i++)
            {
                colliders[i].enabled = false;
            }
        }
        /*
        if(ray().Equals("activate2"))
        {
            toggleData();
            activateExplode();
            drawLines();
        }
        */


        //updates the lines pt2 to follow the positions of the texts
        for (int i = 0; i < lines.Count; i++)
        {
            //Debug.Log(lines.Count);
            lines[i].SetPositions(addLines(texts[i], i));
        }

        followData();

    }

    //ACCESSORS//    
    public string getData(int number)
    {
        int num = number;
        string value = "";

        switch (num)
        {

            case 1:
                value = getDetailType();

                break;

            case 2:
                value = getName();

                break;

            case 3:
                value = getMaterial();

                break;

            case 4:
                double r = getRValue();
                value = "" + r;

                break;

            case 5:
                double u = getUValue();
                value = "" + u;

                break;

            case 6:
                double c = getCost();
                value = "" + c;

                break;

            default:
                value = "Field Missing";

                break;
        }
        return value;
    }

    public string getDetailType()
    {
        return dc.details[excelNum - 2].detailType;
    }

    public string getName()
    {
        return dc.details[excelNum - 2].name;
    }

    public string getMaterial()
    {
        return dc.details[excelNum - 2].material;
    }

    public double getRValue()
    {
        return dc.details[excelNum - 2].rValue;
    }

    public double getUValue()
    {
        return dc.details[excelNum - 2].uValue;
    }

    public double getCost()
    {
        return dc.details[excelNum - 2].cost;
    }

    public string ray()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //RaycastHit hit;
            RaycastHit hit = new RaycastHit();

            //if raycast hit
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                //Debug.Log(hit.collider.tag);
                if (hit.collider == gameObject.GetComponent<MeshCollider>() || hit.collider == gameObject.GetComponent<Collider>() || hit.collider == gameObject.GetComponent<BoxCollider>())
                //if(hit.collider.tag == "SubComponent")
                {
                    //THIS SUBANNOTATE SCRIPT HAS TO BE ON EVERY SINGLE INDIVIDUAL SUBCOMPONET THAT WILL BE CLICKED
                    //NO IT DOSNT IF THEY ARE ALL THE SAME
                    //BUT THE FIRST OPTION IS FAR EASIER

                    //Debug.Log("Detail Hit!");
                    /*
                    currentCollider = hit.collider;
                        if(subColliders.Contains(currentCollider) == false)
                        {
                            subColliders.Add(currentCollider);
                            SubComponent subComp = new SubComponent(currentCollider.name, currentCollider.transform.position, true, currentCollider);
                            formatTextMesh(subComp);
                            getPositions();
                            drawLines();
                            activateExplode();
                        }
                        */


                    if (created == false)
                    {
                        //Debug.Log("First Click");
                        //createTextMesh();
                        formatTextMesh();
                        getPositions();
                        drawLines();
                        activateExplode();
                        //toggleData();
                    }


                    else
                    {
                        //Debug.Log("Not First Click");
                        //toggleData();
                        activateExplode();
                        drawLines();
                    }
                    return "activate2";
                }
            }
        }
        return "";
    }

    //Creates a new text mesh for each field
    public void createTextMesh()
    {
        for (int i = 1; i <= NUM_OF_FIELDS; i++)
        {
            text = Instantiate(text, gameObject.transform.position + new Vector3(0, i, 0), Quaternion.identity) as TextMesh;
            text.text = getData(i);
            text.fontSize = FONT_SIZE;
            texts.Add(text);
        }
        created = true;
    }

    //Formats a Standard text mesh for the subcomponent that was clicked
    public void formatTextMesh()//SubComponent sub)
    {
        text = Instantiate(text, gameObject.transform.position + new Vector3(0, 0, 0), Quaternion.identity) as TextMesh;
        if (getData(3) != null && getData(2) != null && getData(4) != null)
        {
            text.text = getData(3) + " " + getData(2) + "\n" + "Size: " + getData(4);
        }
        else
        {
            text.text = "Fields are missing";
        }
        text.fontSize = FONT_SIZE;
        texts.Add(text);
        created = true;
        r = texts[0].transform.gameObject.AddComponent<Rigidbody>();
        r.useGravity = false;
    }

    /*
    //Creates a new LineRenderers each TextMesh
    public void createLineRenderers()
    {
        for (int i = 1; i <= texts.Count; i++)
        {
            line = Instantiate(line, gameObject.transform.position + new Vector3(0, i - 1, 0), Quaternion.identity) as LineRenderer;
            lines.Add(line);
        }
    }
    */

    public void toggleData()
    {
        for (int i = 0; i < texts.Count; i++)
        {
            if (texts[i].transform.gameObject.activeSelf == true)
            {
                texts[i].transform.gameObject.SetActive(false);
            }
            else
            {
                texts[i].transform.gameObject.SetActive(true);
            }
        }
    }

    public void toggleColliders()
    {
        for (int i = 0; i < colliders.Count; i++)
        {
            if (colliders[i].enabled == true)
            {
                colliders[i].enabled = false;
            }
            else
            {
                colliders[i].enabled = true;
            }
        }
    }

    public void drawLines()
    {
        //for each text mesh
        for (int i = 0; i < texts.Count; i++)
        {
            //if it dosn't have a line renderer, add one
            if (texts[i].transform.gameObject.GetComponent<LineRenderer>() == null)
            {
                Debug.Log("TextMesh " + i + ": has no LineRenderer, so one was added.");
                line = texts[i].transform.gameObject.AddComponent<LineRenderer>();
            }
            else
            {
                line = texts[i].transform.gameObject.GetComponent<LineRenderer>();
            }
            line.SetPositions(addLines(texts[i], i));
            line.SetWidth(width, width);
            line.material.SetTexture("_MainTex", tex);
            line.material = lineMaterial;
            line.SetColors(pColorA, pColorB);
            if (lines.Count == 0)
            {
                lines.Add(line);
            }
        }
    }

    private Vector3[] addLines(TextMesh t, int i)
    {
        points[0] = oldPos[i];
        //points[1] = gameObject.transform.position + new Vector3(0, i - 1, 0);
        points[1] = texts[i].transform.position;
        return points;
    }

    /*
    public void explodeData()
    {
        for(int i = 0; i < texts.Count; i++)
        {
            //texts[i].transform.Translate(Vector3.Slerp(p)
        }
    }
    */

    public void getPositions()
    {
        //for each TextMesh
        for (int i = 0; i < texts.Count; i++)
        {
            //gets the original position of the texts 
            oldPos.Add(texts[i].transform.position);

            //for straight lined labels
            //Vector3 tempPos = (oldPos[i] + new Vector3(-5, 0, 0));

            //for labels come to player
            Vector3 tempPos = Vector3.Lerp(oldPos[i], (player.transform.position + new Vector3(0, i, 0)), 0.5f);
            newPos.Add(tempPos);

            //Debug.Log("old: " + oldPos[i] + "new: " + newPos[i]);
            //With Physics (not working yet)
            //bodies[i].AddForce(Vector3.forward);
        }
    }

    public void updatePositions()
    {
        newPos.Clear();

        for (int i = 0; i < texts.Count; i++)
        {
            //Straight lined labels
            //Vector3 tempPos = (oldPos[i] + new Vector3(-5, 0, 0));

            //Labels come to player
            Vector3 tempPos = Vector3.Lerp(oldPos[i], (player.transform.position + new Vector3(0, i, 0)), 0.5f);
            newPos.Add(tempPos);
        }
        //Debug.Log("Positions Updated");
    }

    public void activateExplode()
    {
        if (moved == false)
        {
            StartCoroutine(explodeData());
            moved = true;
        }
        else if (moved == true)
        {
            StartCoroutine(explodeBackData());
            moved = false;
        }
        else
        {
            Debug.Log("Text still moving, please click after it has stopped.");
        }
    }


    //Move layers transform
    IEnumerator explodeData()
    {
        for (int t = 0; t < texts.Count; t++)
        {
            if (texts[t].transform.gameObject.activeSelf == false)
            {
                toggleData();
            }
        }
        float timeSinceStarted = 0f;

        while (Vector3.Distance(texts[0].transform.position, newPos[0]) > 0f)
        {
            timeSinceStarted += Time.deltaTime;
            for (int i = 0; i < texts.Count; i++)
            {
                //Debug.Log("Explode[" + i + "]: newPos: " + newPos[i] + " currentPos: " + texts[i].transform.position + " oldPos: " + oldPos[i]);
                texts[i].transform.position = Vector3.Lerp(oldPos[i], newPos[i], timeSinceStarted);
            }

            for (int i = 0; i < texts.Count; i++)
            {
                if (texts[i].transform.position == newPos[i])
                {
                    //Debug.Log("moved");
                    moved = true;
                    yield break;
                }
                yield return null;
            }
        }
    }

    IEnumerator explodeBackData()
    {
        float timeSinceStarted = 0f;

        while (Vector3.Distance(texts[0].transform.position, oldPos[0]) > 0f)
        {
            timeSinceStarted += Time.deltaTime;
            for (int i = 0; i < texts.Count; i++)
            {
                //Debug.Log("Explode[" + i + "]: newPos: " + newPos[i] + " currentPos: " + texts[i].transform.position + " oldPos: " + oldPos[i]);
                texts[i].transform.position = Vector3.Lerp(newPos[i], oldPos[i], timeSinceStarted);
            }

            for (int i = 0; i < texts.Count; i++)
            {
                if (texts[i].transform.position == oldPos[i])
                {
                    //Debug.Log("moved back");
                    moved = false;
                    toggleData();
                    updatePositions();
                    yield break;
                }
                yield return null;
            }
        }
    }

    public void followData()
    {
        for (int i = 0; i < texts.Count; i++)
        {
            //Debug.Log(texts[i].name + "rotating");
            r.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            r.transform.LookAt(player.transform.parent.position);
            r.transform.Rotate(new Vector3(0, 180, 0));
        }
    }
}

//organizeData()

//explodeData() eg. move to the right


//drawLines() (1d)

//remove collider from transparent parts that are in the way and not going to be clickable (1/2d)

//add rim shader to show what you are clicking on (1d)

//use a sphere collider for pulse instead of a distance(1/2d)

//pulse for tansparent parts to return to opaque (maybe a button since the meshcollider will be removed) (1d)

//cut smaller hidden floor for foundation, as well as the ceiling (1d)

//switch everything to FPS camera instead of AR (1/2d)

//Add exterior landscape (1d) Hadi (AR)

//Rotate skybox slowly (1/2d)

//Heat transfer diagrams (convection, radiation, conduction) (1week) (AR)

//Wind diagram (2d) Hadi (AR)

//9days + 7days = 16 days (Due August 11th)


//Today:
//get excel sheet to shahin
//drawlines

