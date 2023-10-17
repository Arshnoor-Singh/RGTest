using UnityEngine;
using UnityEngine.Splines;

public class sMascotController : MonoBehaviour
{
    // Operational References
    [SerializeField] private SplineAnimate mascotSplineAnimate;
    [SerializeField] Animator animator;
    [SerializeField] private GameObject popUpObject;

    // Private variables
    private bool walk;
    private bool canBeTouched = true;
    
    // Unity Start Event
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Unity Update Event
    void Update()
    {
        walk = mascotSplineAnimate.IsPlaying;
        animator.SetBool("isWalking", walk);
    }

    // Event to instruct the mascot to move from the start of the current spline
    public void MoveMascot()
    {
        mascotSplineAnimate.Restart(false);
        mascotSplineAnimate.Play();
    }

    // Event to assign a new Spline for the Mascot to move
    public void SetMascotSpline(SplineContainer splineContainer)
    {
        mascotSplineAnimate.Container = splineContainer;
    }

    // Event to move the character to the next chapter
    // The functionality to use JumpStart and the JumpEnd to make the character jump is deprecated
    public void JumpToNewChapter(Vector3 jumpStart, Vector3 jumpEnd, SplineContainer targetSpline)
    {
        mascotSplineAnimate.Container = targetSpline;
        mascotSplineAnimate.Restart(false);
    }

    // Function to check if the character is walking
    public bool IsMascotWalking()
    {
        return walk;
    }
    
    // Function to Set a bool if the character can be touched or not
    public void SetCanBeTouched(bool newTouchStatus)
    {
        canBeTouched = newTouchStatus;
    }

    // Function to execute when the actual Mascot is clicked on
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
