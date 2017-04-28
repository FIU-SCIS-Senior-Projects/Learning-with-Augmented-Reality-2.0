using UnityEngine;
using System.Collections;

//An interface that controls the state of the objects in the Environment
public interface IEnvironmentState
{
    void UpdateState();

    void OnTriggerClicked();
    //Passes System or Floating Button to acivate state

    void ToMainState();
    //Main Panel Activated
    //Path Actiaved
    //Floating Diagram Interface Activated

    void ToDiagramState();
    //Diagram Button that was clicked calls asscoiated event
    //Diagrams Panel Activated
    //Camera Switch to Aerial Camera

    void ToMajorComponentState();
    //System that was triggered becomes transparent
    //Pulsing of this System's MajorComponents
    //System's Major Annotation
    //System's Floating Major Interface Activated

    void ToSubComponentState();
    //Isolation of the System from Environment
    //Disables System's Major Colliders
    //Activaes the MajorAnnotation UI Panel
    //System's Sub Annotation
    //System's Floating Sub Interface Activated

    void ToBuildState();

    void ToMechanicalState();

    void ToMechanicalRoomState();
}
