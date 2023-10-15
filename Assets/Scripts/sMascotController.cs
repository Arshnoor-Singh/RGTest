using UnityEngine;
using UnityEngine.Splines;

public class sMascotController : MonoBehaviour
{
    [SerializeField] private SplineAnimate mascotSplineAnimate;
    
    //Function will be called by the SceneController when the player will have to move
    public void MoveMascot()
    {
        mascotSplineAnimate.Restart(false);
        mascotSplineAnimate.Play();
    }

    public void SetMascotSpline(SplineContainer splineContainer)
    {
        mascotSplineAnimate.Container = splineContainer;
    }

    public void JumpToNewChapter(Vector3 jumpStart, Vector3 jumpEnd, SplineContainer targetSpline)
    {
        mascotSplineAnimate.Container = targetSpline;
        mascotSplineAnimate.Restart(false);
    }
}
