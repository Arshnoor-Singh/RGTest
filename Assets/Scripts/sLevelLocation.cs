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
    
    [Header("DO NOT CHANGE")]
    [SerializeField] private Material[] mats_FL;
    [SerializeField] private TextMeshPro levelCountLabelF;
    [SerializeField] private TextMeshPro levelCountLabelB;
    [SerializeField] private MeshRenderer flagRenderer;
    [SerializeField] private SplineContainer associatedSpline;
    
    private sSceneController sceneController;
    private sMascotController mascot;

    //Unity Start Event
    private void Start()
    {
        //get scene controller reference
        sceneController = FindFirstObjectByType<sSceneController>();

        //get Mascot Reference
        mascot = FindFirstObjectByType<sMascotController>();
        
        //Generates Label At Level Start for all instances
        FlagInitialisation();
    }
    
    //Return the start Position of the associated Spline
    public Vector3 ReturnSplineStart()
    {
        return associatedSpline.EvaluatePosition(0);
    }

    public Vector3 ReturnSplineEnd()
    {
        if (!isLast)
            return associatedSpline.EvaluatePosition(1);
        else
            return transform.position;
    }

    //Generates Label and Start for all instances
    private void FlagInitialisation()
    {
        if (isFirst)
        {
            flagRenderer.sharedMaterials[1] = mats_FL[0];
            levelCountLabelF.text = "1";
            levelCountLabelB.text = "1";
        }
        else if(isLast)
        {
            flagRenderer.sharedMaterials[1] = mats_FL[1];
            levelCountLabelF.text = flagLevel.ToString();
            levelCountLabelB.text = flagLevel.ToString();
        }
        else
        {
            levelCountLabelF.text = flagLevel.ToString();
            levelCountLabelB.text = flagLevel.ToString();
        }
    }
    
    // ----- MAY NEED TO BE DEPRECATED ---- Event Executed when the Mascot enters the Trigger of the next Flag
    void OnTriggerEnter(Collider other)
    {
        //Do something on Entering the new level
    }
    
    //Returns the Associated Spline
    public SplineContainer GetAssociatedSpline()
    {
        return associatedSpline;
    }
    
    //Returns the value of the public boolean to check if this is the last flag
    public bool isFinal()
    {
        return isLast;
    }
}