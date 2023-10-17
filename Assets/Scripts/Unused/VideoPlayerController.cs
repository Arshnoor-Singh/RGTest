using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerController : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    public void PlayVideo(string videoUrl)
    {
        videoPlayer.url = videoUrl;
        videoPlayer.Play();
    }
}