using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

    //----------------------------------------------------

    // Function to find the superstring containing the given substring in a JSON data string
    public string FindSuperstringWithSubstring(string jsonData, string substring)
    {
        try
        {
            // Parse the JSON data into a JToken (JSON object)
            JToken jToken = JToken.Parse(jsonData);

            // Call a recursive function to search for the substring
            JToken result = SearchSuperstring(jToken, substring);

            if (result != null)
            {
                // Serialize the JSON object back to a string
                return result.ToString(Formatting.None);
            }
        }
        catch (JsonReaderException e)
        {
            Debug.LogError("Error parsing JSON: " + e.Message);
        }

        return null;
    }

    // Recursive function to search for the substring in a JSON object (JToken)
    private JToken SearchSuperstring(JToken jToken, string substring)
    {
        if (jToken.Type == JTokenType.Object)
        {
            foreach (var property in jToken.Children<JProperty>())
            {
                if (property.Value.Type == JTokenType.String && property.Value.ToString().Contains(substring))
                {
                    // If the value is a string and contains the substring, return the superstring
                    return jToken;
                }
                else
                {
                    // Recursively search the property's value
                    JToken result = SearchSuperstring(property.Value, substring);
                    if (result != null)
                    {
                        return jToken;
                    }
                }
            }
        }
        else if (jToken.Type == JTokenType.Array)
        {
            foreach (var item in jToken.Children())
            {
                // Recursively search the array items
                JToken result = SearchSuperstring(item, substring);
                if (result != null)
                {
                    return jToken;
                }
            }
        }

        // If the substring is not found in this JSON object, return null
        return null;
    }

    //----------------------------------------------------

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
                //string videoUrl = "https://www.youtube.com/watch?v=RNUakOk4pXQ"; // Replace with the actual video URL

                string jsonResult = www.downloadHandler.text;
                Debug.Log(jsonResult);
                
                string videoURL = FindSuperstringWithSubstring(jsonResult, "https://i.ytimg.com");
                Debug.LogWarning(videoURL);

                // Construct the video URL.
                //string videoURL = "https://www.youtube.com/watch?v=" + videoId;
                
                // Call the PlayVideo function to start playing the video.
                VPlayer.PlayVideo(videoURL);
            }
        }
    }


}