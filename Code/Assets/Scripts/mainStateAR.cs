public class mainStateAR : IARState
{
    private readonly StatePatternAR envi;

    public mainStateAR(StatePatternAR statePatternAR) { envi = statePatternAR; }

    public void UpdateState()
    {
        if (envi.isGetSubPanelCalled == true)
        {
            Description.Instance.setDescript(envi.currentSubPanelName);
            envi.isGetSubPanelCalled = false;
        }
    }

    // Use this for initialization
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    public void OnTriggerClicked()
    {
        
    }
}
