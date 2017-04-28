using UnityEngine;
using System.Collections;

//An interface that controls the state of the objects in the Environment
public interface IARState
{
    void UpdateState();
    void OnTriggerClicked();
}
