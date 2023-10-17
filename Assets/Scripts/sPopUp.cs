using UnityEngine;

public class sPopUp : MonoBehaviour
{
    [SerializeField] private GameObject popUpCanvas;
    [SerializeField] private sVPController videoController;
    [SerializeField] private GameObject vpGameObject;

    // Function to execute when Yes is clicked
    public void OnYesClicked()
    {
        vpGameObject.SetActive(true);
        videoController.RandomiseVideo();
        videoController.PlayVideo();
        
        //youtubeAPI.FetchVideoInfo();
        popUpCanvas.SetActive(false);
    }
    
    // Function to execute when No is clikced
    public void OnNoClicked()
    {
        popUpCanvas.SetActive(false);
    }
}
