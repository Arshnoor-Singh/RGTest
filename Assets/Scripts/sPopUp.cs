using UnityEngine;

public class sPopUp : MonoBehaviour
{
    [SerializeField] private GameObject popUpCanvas;
    [SerializeField] private sVPController videoController;
    [SerializeField] private GameObject vpGameObject;

    public void OnYesClicked()
    {
        Debug.LogWarning("Yes Clicked in UI");
        
        
        
        vpGameObject.SetActive(true);
        videoController.RandomiseVideo();
        videoController.PlayVideo();
        
        //youtubeAPI.FetchVideoInfo();
        popUpCanvas.SetActive(false);
    }

    public void OnNoClicked()
    {
        popUpCanvas.SetActive(false);
    }
}
