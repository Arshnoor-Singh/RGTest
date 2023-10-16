using UnityEngine;
using UnityEngine.UI;

public class sTouchScreen : MonoBehaviour
{
    public Text PhaseDisplayText;
    private Touch theTouch;
    private float timeTouchedEnded;
    private float displayTime = 0.5f;


    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            theTouch = Input.GetTouch(0);
            if (theTouch.phase == TouchPhase.Ended)
            {
                PhaseDisplayText.text = theTouch.phase.ToString();
                timeTouchedEnded = Time.time;
            }
            else if (Time.time - timeTouchedEnded > displayTime)
            {
                PhaseDisplayText.text = theTouch.phase.ToString();
                timeTouchedEnded = Time.time;
            }
        }
        else if (Time.time - timeTouchedEnded > displayTime)
        {
            PhaseDisplayText.text = " ";
        }
    }
}
