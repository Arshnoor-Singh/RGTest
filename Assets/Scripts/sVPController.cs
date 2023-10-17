using UnityEngine;
using UnityEngine.Video;

public class sVPController : MonoBehaviour
{
    [SerializeField] private VideoClip[] vClips;
    [SerializeField] private VideoPlayer videoController;
    [SerializeField] private sSceneController sceneReference;
    [SerializeField] private GameObject vpGameObject;
    [SerializeField] private sMascotController mascotReference;

    private void Start()
    {
        // Calls the function when the OnVideoFinished when the Video stops playing
        videoController.loopPointReached += OnVideoFinished;
    }
    
    // This function randomises which video will be played when a video is requested
    public void RandomiseVideo()
    {
        int rand = Random.Range(0, 3);
        videoController.clip = vClips[rand];
    }

    // Function is used to start video playback
    public void PlayVideo()
    {
        videoController.Play();
        mascotReference.SetCanBeTouched(false);
    }
    
    // The things needed to be done when a Video Finishes
    private void OnVideoFinished(VideoPlayer vp)
    {
        vpGameObject.SetActive(false);
        mascotReference.SetCanBeTouched(true);
        Debug.LogError(sceneReference.name);
        sceneReference.VideoComplete();
    }
    
    // Changes the Scene/Chapter Reference Whenever a Scene/Chapter Changes
    public void UpdateSceneReference(sSceneController newSceneControllerReference)
    {
        sceneReference = newSceneControllerReference;
    }
}
