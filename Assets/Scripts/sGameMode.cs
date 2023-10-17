using UnityEngine;

public class sGameMode : MonoBehaviour
{
    [SerializeField] private sSceneController[] sceneControllers;
    [SerializeField] private sVPController videoPlayer;
    
    private int currentController;
    
    private void Awake()
    {
        sceneControllers[0].SetAsActiveController();
        currentController = 0;
    }

    
    //T his function changes the current chapter to the next one
    public void ChangeSceneController()
    {
        sceneControllers[currentController].DeActivateController();
        currentController++;

        if (sceneControllers.Length <= currentController)
        {
            // Some sort of a function to say congrats on reaching the last level of the last chapter
            Debug.Log("Last Chapter Reached");
            Application.Quit();
        }
        else
        {
            sceneControllers[currentController].SetAsActiveController(sceneControllers[currentController].GetFinalPoint());
            videoPlayer.UpdateSceneReference(sceneControllers[currentController]);
        }
    }

    
    // This function returns the current scene
    public sSceneController GetCurrentScene()
    {
        return sceneControllers[currentController];
    }
}
