using UnityEngine;

public class sSceneController : MonoBehaviour
{
    [Header("Operational References")] 
    [SerializeField] private sLevelLocation[] levelsArray;
    [SerializeField] private sMascotController mascotReference;

    //Holds the value of the level the player is currently at for other scripts to reference
    private bool isActiveSceneController;
    private int currentLevel;
    private sGameMode gameModeReference;
    private Vector3 startPoint;

    
    //Unity Event
    private void Start()
    {
        gameModeReference = FindObjectOfType<sGameMode>();
        MascotInitialisation();
    }
    
    // Function Called by GameMode at Start of the game to activate the First Chapter/SceneController
    public void SetAsActiveController()
    {
        //Get the Start point of the chapter and Put the Mascot at that location
        isActiveSceneController = true;
        currentLevel = 0;
        startPoint = levelsArray[currentLevel].ReturnSplineStart();
    }

    
    
    // Function Called by GameMode Object to Change to the New Chapter/NextSceneController
    public void SetAsActiveController(Vector3 endOfPreviousChapter)
    {
        isActiveSceneController = true;
        currentLevel = 0;
        startPoint = levelsArray[currentLevel].ReturnSplineStart();
        
        mascotReference.JumpToNewChapter(endOfPreviousChapter, startPoint, levelsArray[currentLevel].GetAssociatedSpline());
    }
    

    //Function to Deactivate this chapter
    public void DeActivateController()
    {
        isActiveSceneController = false;
    }
    
    
    
    void MascotInitialisation()
    {
        if(isActiveSceneController) 
            mascotReference.SetMascotSpline(levelsArray[0].GetAssociatedSpline());
    }

    
    
    public void OnButtonClicked()
    {
        VideoComplete();
    }
    
    
    
    void VideoComplete()
    {
        if (isActiveSceneController)
        {
            //If the Mascot is at the final flag of the current chapter, Move it to the next chapter
            if (levelsArray[currentLevel].isFinal())
            {
                gameModeReference.ChangeSceneController();
                return;
            }

            //If the Mascot is not at the Final Flag, Change Spline and move the mascot to the next flag
            mascotReference.SetMascotSpline(levelsArray[currentLevel].GetAssociatedSpline());
            mascotReference.MoveMascot();
            currentLevel++;
        }
    }
   
    
    
    //Returns the location of the Final Flag
    public Vector3 GetFinalPoint()
    {
        return levelsArray[levelsArray.Length - 1].ReturnSplineEnd();
    }
    
}
