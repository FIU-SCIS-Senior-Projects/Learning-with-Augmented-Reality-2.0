using UnityEngine;

//Dependancy of this type of Component: Camera
[RequireComponent(typeof(Camera))]

//Vocab: 
//conduction - heat transfer through fluid or circulating medium
//convection - heat transfer through direct connection with neighbooring molcules
//radiation - heat transfer through waves, no medium required 

public class HeatTransFX : MonoBehaviour
{
    // Heat mode (Radiation, Convection, or Conduction)
    public enum HeatMode { Radiation, Convection, Conduction }
    [SerializeField]
    HeatMode _mode = HeatMode.Radiation;
    public HeatMode mode { get { return _mode; } set { _mode = value; } }

    // Heat direction (used only in the radiation mode)
    [SerializeField]
    Vector3 _direction = Vector3.forward;
    public Vector3 direction { get { return _direction; } set { _direction = value; } }

    // Wave Density (hot air rises)
    [SerializeField]
    Vector3 _density = Vector3.up;
    public Vector3 density { get { return _density; } set { _density = value; } }

    // Wave origin (used only in the convection mode)
    [SerializeField]
    Vector3 _origin = Vector3.zero;
    public Vector3 origin { get { return _origin; } set { _origin = value; } }

    // Base color (albedo)
    [SerializeField]
    Color _baseColor = new Color(0.2f, 0.2f, 0.2f, 0);
    public Color baseColor { get { return _baseColor; } set { _baseColor = value; } }

    // Wave color
    [SerializeField]
    Color _waveColor = new Color(1.0f, 0.2f, 0.2f, 0);
    public Color waveColor { get { return _waveColor; } set { _waveColor = value; } }

    // Wave color amplitude
    [SerializeField]
    float _waveAmplitude = 2.0f;
    public float waveAmplitude { get { return _waveAmplitude; } set { _waveAmplitude = value; } }

    // Exponent for wave color
    [SerializeField]
    float _waveExponent = 22.0f;
    public float waveExponent { get { return _waveExponent; } set { _waveExponent = value; } }

    // Wave speed
    [SerializeField]
    float _waveSpeed = 10.0f;
    public float waveSpeed { get { return _waveSpeed; } set { _waveSpeed = value; } }

    // Additional color (emission)
    [SerializeField]
    Color _addColor = Color.black;
    public Color addColor { get { return _addColor; } set { _addColor = value; } }

    // Reference to the shader.
    [SerializeField] Shader shader;

    // Private shader variables
    int baseColorID;
    int waveColorID;
    int waveParamsID;
    int waveVectorID;
    int addColorID;


    //Instatiating the shader variables with names
    void Awake()
    {
        baseColorID = Shader.PropertyToID("_SonarBaseColor");
        waveColorID = Shader.PropertyToID("_SonarWaveColor");
        waveParamsID = Shader.PropertyToID("_SonarWaveParams");
        waveVectorID = Shader.PropertyToID("_SonarWaveVector");
        addColorID = Shader.PropertyToID("_SonarAddColor");
    }

    void OnEnable()
    {
        GetComponent<Camera>().SetReplacementShader(shader, null);
        Update();
    }


    void OnDisable()
    {
        GetComponent<Camera>().ResetReplacementShader();
    }


    // Update is called once per frame
    void Update()
    {
        Shader.SetGlobalColor(baseColorID, _baseColor);
        Shader.SetGlobalColor(waveColorID, _waveColor);
        Shader.SetGlobalColor(addColorID, _addColor);

        var param = new Vector4(_waveAmplitude, _waveExponent, _waveSpeed);
        Shader.SetGlobalVector(waveParamsID, param);

        if (_mode == HeatMode.Radiation)
        {
            Shader.DisableKeyword("HEAT_CONVECTION");
            Shader.SetGlobalVector(waveVectorID, _direction.normalized);
        }
        else
        {
            Shader.EnableKeyword("HEAT_CONVECTION");
            Shader.SetGlobalVector(waveVectorID, _origin);
        }
    }
}
