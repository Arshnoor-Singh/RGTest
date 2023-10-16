using UnityEngine;
using UnityEngine.Splines;

public class sMascotController : MonoBehaviour
{
    [SerializeField] private SplineAnimate mascotSplineAnimate;
    [SerializeField] private Rigidbody rigid;
    private bool walk; 

    [SerializeField] Animator animator;

    //Function will be called by the SceneController when the player will have to move
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        walk = mascotSplineAnimate.IsPlaying;
        animator.SetBool("isWalking", walk);
    }

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
