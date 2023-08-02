using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{    
    public void ChangeSphere(GameObject destination)
    {
        GameObject currentSphere = FindObjectOfType<VideoPlayer>().gameObject;
        Transform viewer = GameObject.Find("Viewer").transform;

        destination.SetActive(true);
        viewer.position = destination.transform.position;
        currentSphere.SetActive(false);
    }
}
