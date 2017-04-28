using UnityEngine;

//Requires a HeatTransferFX component
[RequireComponent(typeof(HeatTransFX))]

public class HeatSwitcher : MonoBehaviour
{
    public Gradient baseAlbedo;
    public Gradient baseEmission;
    public Gradient waveColor;
    public float switchSpeed = 5;

    HeatTransFX fx;
    float parameter;
    float target;

    public bool state
    {
        get { return target > 0.0f; }
        set { target = state ? 1.0f : 0.0f; }
    }

    void Awake()
    {
        fx = GetComponent<HeatTransFX>();
    }

    void Update()
    {
        if (parameter < target)
        {
            parameter = Mathf.Min(1.0f, parameter + switchSpeed * Time.deltaTime);
            fx.enabled = true;
        }
        else if (parameter > target)
        {
            parameter = Mathf.Max(0.0f, parameter - switchSpeed * Time.deltaTime);
            if (parameter == 0.0f) fx.enabled = false;
        }

        if (parameter > 0.0f)
        {
            fx.baseColor = baseAlbedo.Evaluate(parameter);
            fx.addColor = baseEmission.Evaluate(parameter);
            fx.waveColor = waveColor.Evaluate(parameter);
        }
    }

    public void Toggle()
    {
        target = target > 0.0f ? 0.0f : 1.0f;
    }
}