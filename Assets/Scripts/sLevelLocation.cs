using UnityEngine;
using TMPro;
using UnityEngine.Splines;

public class sLevelLocation : MonoBehaviour
{
    [Header("Set Flag Number")]
    [SerializeField] private int flagLevel;
    
    [Header("First and Last Selection")]
    [SerializeField] private bool isFirst;
    [SerializeField] private bool isLast;
    
    [Header("Operational Fields, DO NOT CHANGE")]
    [SerializeField] private Material[] matsFL;
    [SerializeField] private TextMeshPro levelCountLabelF;
    [SerializeField] private TextMeshPro levelCountLabelB;
    [SerializeField] private MeshRenderer flagRenderer;
    [SerializeField] private SplineContainer associatedSpline;
    [SerializeField] private GameObject flag;

    // Unity Start Event
    private void Start()
    {
        // Generates Label At Level Start for all instances
        FlagInitialisation();
    }
    
    // Return the start Position of the associated Spline
    public Vector3 ReturnSplineStart()
    {
        return associatedSpline.EvaluatePosition(0);
    }

    // Returns the position the End point of the spline of the current chapter
    // Currently, This functionality is deprecated
    public Vector3 ReturnSplineEnd()
    {
        if (!isLast)
            return associatedSpline.EvaluatePosition(1);
        else
            return transform.position;
    }

    // Generates Label and Start for all instances
    private void FlagInitialisation()
    {
        if (isFirst)
        {
            levelCountLabelF.text = "1";
            levelCountLabelB.text = "1";
        }
        else if(isLast)
        {
            levelCountLabelF.text = flagLevel.ToString();
            levelCountLabelB.text = flagLevel.ToString();
        }
        else
        {
            levelCountLabelF.text = flagLevel.ToString();
            levelCountLabelB.text = flagLevel.ToString();
        }
    }
    
    // Event Executed when the Mascot enters the Trigger of the next Flag
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mascot"))
        {
            flag.GetComponent<Renderer>().materials[1].color = Color.HSVToRGB(169,31,65);
        }
    }

    // Returns the Associated Spline
    public SplineContainer GetAssociatedSpline()
    {
        return associatedSpline;
    }
    
    // Returns the value of the public boolean to check if this is the last flag
    public bool isFinal()
    {
        return isLast;
    }
}