using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Video;

public class YouTubeAPIManager : MonoBehaviour
{
    [SerializeField] private string apiKey = "YOUR_API_KEY";
    private string videoId = "VIDEO_ID_TO_FETCH";

    [SerializeField] private string[] youtubeURLsArray;
    [SerializeField] private VideoPlayerController VPlayer;
 
    private string baseUrl = "https://www.googleapis.com/youtube/v3/videos";

    public void FetchVideoInfo()
    {
        string youtubeUrl = "https://www.youtube.com/watch?v=RNUakOk4pXQ";
        string videoId = youtubeUrl.Substring(youtubeUrl.IndexOf("v=") + 2);
        
        string url = $"{baseUrl}?part=snippet&id={videoId}&key={apiKey}";
        StartCoroutine(FetchVideoInfoCoroutine(url));
    }

    IEnumerator FetchVideoInfoCoroutine(string url)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error: " + www.error);
            }
            else
            {
                
                // Assuming you have already fetched the video URL using YouTubeAPIManager
                string videoUrl = "https://www.youtube.com/watch?v=RNUakOk4pXQ"; // Replace with the actual video URL

                
                string jsonResult = www.downloadHandler.text;
                //string videoURL = ParseVideoURLFromJSON(jsonResult);

                // Construct the video URL.
                string videoURL = "https://www.youtube.com/watch?v=" + videoId;
                
                
                
                
                // Call the PlayVideo function to start playing the video.
                VPlayer.PlayVideo(videoUrl);
            }
        }
    }
}