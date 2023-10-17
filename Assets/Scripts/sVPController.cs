using UnityEngine;
using UnityEngine.Video;

public class sVPController : MonoBehaviour
{
    [SerializeField] private VideoClip[] vClips;
    [SerializeField] private VideoPlayer videoController;
    [SerializeField] private sSceneController sceneReference;
    [SerializeField] private GameObject vpGameObject;
    [SerializeField] private sMascotController mascotReference;

    public void RandomiseVideo()
    {
        int rand = Random.Range(0, 3);
        Debug.Log("random value = " + rand);
        videoController.clip = vClips[rand];
    }

    public void PlayVideo()
    {
        videoController.Play();
        mascotReference.SetCanBeTouched(false);
    }
    
    private void Start()
    {
        videoController.loopPointReached += OnVideoFinished;
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        vpGameObject.SetActive(false);
        mascotReference.SetCanBeTouched(true);
        Debug.LogError(sceneReference.name);
        sceneReference.VideoComplete();
    }

    public void UpdateSceneReference(sSceneController newSceneControllerReference)
    {
        sceneReference = newSceneControllerReference;
    }
}
