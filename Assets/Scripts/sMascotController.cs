using UnityEngine;
using UnityEngine.Splines;

public class sMascotController : MonoBehaviour
{
    [SerializeField] private SplineAnimate mascotSplineAnimate;
    [SerializeField] Animator animator;
    [SerializeField] private GameObject popUpObject;

    private bool walk;
    private bool canBeTouched = true;
    
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

    public bool IsMascotWalking()
    {
        return walk;
    }

    public void SetCanBeTouched(bool newTouchStatus)
    {
        canBeTouched = newTouchStatus;
    }

    public void MascotTouched()
    {
        if (!walk && canBeTouched)
        {
            if (popUpObject.activeInHierarchy == false)
            {
                popUpObject.SetActive(true);
            }
        }
    }
}
