using UnityEngine;

public class sPopUp : MonoBehaviour
{
    [SerializeField] private GameObject popUpCanvas;
    [SerializeField] private YouTubeAPIManager youtubeAPI;

    public void OnYesClicked()
    {
        Debug.LogWarning("Yes Clicked in UI");
        youtubeAPI.FetchVideoInfo();
        popUpCanvas.SetActive(false);
    }

    public void OnNoClicked()
    {
        popUpCanvas.SetActive(false);
    }
}
