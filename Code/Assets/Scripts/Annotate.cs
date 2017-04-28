using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(LineRenderer))]
public class Annotate : DetailLoader
{

    ////I have a list of details(xml)
    ////Create a list with the same order as its corredsponding xml data

    ////Major Components
    ////list of details(XmlImaginary based on the data)
    ////foreach detail(3D model) link it to gameobject

    ////Put this script on each model to be annotated
    ////assign each model a value

    //private static int NUM_OF_FIELDS = 6;
    //private static int FONT_SIZE = 80;
    //private bool created = false;

    ////For Lines
    //private LineRenderer line;
    //private Vector3[] points = new Vector3[2];
    //public Material material;
    //public Texture tex;
    //public Color pColorA = Color.cyan;
    //public Color pColorB = Color.clear;
    //private List<LineRenderer> lines = new List<LineRenderer>();
    //public List<Vector3> oldPos = new List<Vector3>();
    //public List<Vector3> newPos = new List<Vector3>();
    //private bool activate = false;
    //private bool moved = false;

    //public TextMesh text;
    //public int excelNum;
    //public List<Transform> models = new List<Transform>();
    //public List<TextMesh> texts = new List<TextMesh>();

    //private OrganizedDetail od;

    //// Use this for initialization
    //void Start()
    //{
    //    //material = (Material)Resources.Load("Lines");
    //    createTextMesh();
    //    getPositions();
    //    toggleData();
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    ray();

    //    if(ray().Equals("activate"))
    //    {
    //        //toggleData();
    //        activateExplode();
    //        drawLines();
    //    }

        
    //    /*
    //    for (int i = 0; i < lines.Count; i++)
    //    {
    //        lines[i].SetPositions(AddLines(texts[i], i));
    //    }
    //    */
    //}

    ////ACCESSORS//    
    //public string getData(int number)
    //{
    //    int num = number;
    //    string value = "";

    //    switch (num)
    //    {

    //        case 1:
    //            value = getDetailType();

    //            break;

    //        case 2:
    //            value = getName();

    //            break;

    //        case 3:
    //            value = getMaterial();

    //            break;

    //        case 4:
    //            double r = getRValue();
    //            value = "" + r;

    //            break;

    //        case 5:
    //            double u = getUValue();
    //            value = "" + u;

    //            break;

    //        case 6:
    //            double c = getCost();
    //            value = "$" + c;

    //            break;

    //        default:
    //            value = "Field Missing";

    //            break;
    //    }
    //    return value;
    //}

    //public string getDetailType()
    //{
    //    return dc.details[excelNum].detailType;
    //}

    //public string getName()
    //{
    //    return dc.details[excelNum].name;
    //}

    //public string getMaterial()
    //{
    //    return dc.details[excelNum].material;
    //}

    //public double getRValue()
    //{
    //    return dc.details[excelNum].rValue;
    //}

    //public double getUValue()
    //{
    //    return dc.details[excelNum].uValue;
    //}

    //public double getCost()
    //{
    //    return dc.details[excelNum].cost;
    //}

    //public string ray()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        //RaycastHit hit;
    //        RaycastHit hit = new RaycastHit();

    //        //if raycast hit
    //        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
    //        {
    //            if (hit.collider == gameObject.GetComponent<MeshCollider>())
    //            {

    //                //Debug.Log("Detail Hit!");
    //                /*
    //                if (created == false)
    //                {
    //                    createTextMesh();
    //                    //drawLines();
    //                }
    //                else
    //                {
    //                    toggleData();
    //                }
    //                */
    //                return "activate";
    //            }
    //        }
    //    }
    //    return "";
    //}

    ////Creates a new text mesh for each field
    //public void createTextMesh()
    //{
    //    for (int i = 1; i <= NUM_OF_FIELDS; i++)
    //    {
    //        text = Instantiate(text, gameObject.transform.position + new Vector3(0, i - 1, 0), Quaternion.identity) as TextMesh;
    //        text.text = getData(i);
    //        text.fontSize = FONT_SIZE;
    //        texts.Add(text);
    //    }
    //    created = true;
    //}

    ///*
    ////Creates a new LineRenderers each TextMesh
    //public void createLineRenderers()
    //{
    //    for (int i = 1; i <= texts.Count; i++)
    //    {
    //        line = Instantiate(line, gameObject.transform.position + new Vector3(0, i - 1, 0), Quaternion.identity) as LineRenderer;
    //        lines.Add(line);
    //    }
    //}
    //*/

    //public void toggleData()
    //{
    //    for (int i = 0; i < texts.Count; i++)
    //    {
    //        if (texts[i].transform.gameObject.activeSelf == true)
    //        {
    //            texts[i].transform.gameObject.SetActive(false);
    //        }
    //        else
    //        {
    //            texts[i].transform.gameObject.SetActive(true);
    //        }
    //    }
    //}

    //public void drawLines()
    //{
    //    for (int i = 0; i < texts.Count; i++)
    //    {
    //        line = texts[i].transform.gameObject.AddComponent<LineRenderer>();
    //        line.SetPositions(addLines(texts[i], i));
    //        line.SetWidth(.03f, .03f);
    //        line.material.SetTexture("_MainTex", tex);
    //        line.material = material;
    //        line.SetColors(pColorA, pColorB);
    //    }
    //}

    //private Vector3[] addLines(TextMesh t, int i)
    //{
    //    points[0] = oldPos[i];
    //    //points[1] = gameObject.transform.position + new Vector3(0, i - 1, 0);
    //    points[1] = texts[i].transform.position;
    //    return points;
    //}

    ///*
    //public void explodeData()
    //{
    //    for(int i = 0; i < texts.Count; i++)
    //    {
    //        //texts[i].transform.Translate(Vector3.Slerp(p)
    //    }
    //}
    //*/

    //public void getPositions()
    //{
    //    for (int i = 0; i < texts.Count; i++)
    //    {
    //        oldPos.Add(texts[i].transform.position);

    //        Vector3 tempPos = (oldPos[i] + new Vector3(-5, 0, 0));
    //        newPos.Add(tempPos);

    //        //Debug.Log("old: " + oldPos[i] + "new: " + newPos[i]);
    //        //With Physics (not working yet)
    //        //bodies[i].AddForce(Vector3.forward);
    //    }
    //}


    //public void activateExplode()
    //{
    //    if (moved == false)
    //    {
    //        StartCoroutine(explodeData());
    //        moved = true;
    //    }
    //    else
    //    {
    //        StartCoroutine(explodeBackData());
    //        moved = false;
    //    }
    //}


    ////Move layers transform
    //IEnumerator explodeData()
    //{
    //    toggleData();
    //    float timeSinceStarted = 0f;
        
    //    while (Vector3.Distance(texts[0].transform.position, newPos[0]) > 0f)
    //    {
    //        timeSinceStarted += Time.deltaTime;
    //        for (int i = 0; i < texts.Count; i++)
    //        {
    //            texts[i].transform.position = Vector3.Slerp(oldPos[i], newPos[i], timeSinceStarted);
    //        }

    //        for (int i = 0; i < texts.Count; i++)
    //        {
    //            if (texts[i].transform.position == newPos[i])
    //            {
    //                Debug.Log("moved");
    //                yield break;
    //            }
    //            yield return null;
    //        }
    //    }
    //}

    //IEnumerator explodeBackData()
    //{
    //    float timeSinceStarted = 0f;

    //    while (Vector3.Distance(texts[0].transform.position, oldPos[1]) > 0f)
    //    {
    //        timeSinceStarted += Time.deltaTime;
    //        for (int i = 0; i < texts.Count; i++)
    //        {
    //            texts[i].transform.position = Vector3.Slerp(newPos[i], oldPos[i], timeSinceStarted);
    //        }

    //        for (int i = 1; i < texts.Count; i++)
    //        {
    //            if (texts[i].transform.position == oldPos[i])
    //            {
    //                toggleData();
    //                Debug.Log("moved back");
    //                yield break;
    //            }
    //            yield return null;
    //        }
    //    }
    //}
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

