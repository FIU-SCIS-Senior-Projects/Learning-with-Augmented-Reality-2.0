using UnityEngine;
using System.Collections;

//An interface that controls the state of the objects in the Environment
public interface IDiagramState
{
    void UpdateState();

    void ToWindState();
    //Main Panel Activated
    //Path Actiaved
    //Floating Diagram Interface Activated

    void ToSunState();
    //Diagram Button that was clicked calls asscoiated event
    //Diagrams Panel Activated
    //Camera Switch to Aerial Camera

    void ToSoilState();
    //System that was triggered becomes transparent
    //Pulsing of this System's MajorComponents
    //System's Major Annotation
    //System's Floating Major Interface Activated

    //void ToBuildState();
}
