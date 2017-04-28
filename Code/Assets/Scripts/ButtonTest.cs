using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonTest : MonoBehaviour 
{

	public Slider Slider;

	public void DoSomething()
	{
		Debug.Log (Slider.value.ToString ());
	}

	public void DoSomethingWithSlider(Slider slider)
	{
		Debug.Log (slider.value.ToString ());
	}
}