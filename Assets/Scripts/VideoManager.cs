using System.Collections;
using UnityEngine;
using UnityEngine.Video;

/// <summary>
/// Represents the gestion of the current 360 video.
/// </summary>
public class VideoManager : MonoBehaviour
{
    public Animator fadeAnim;

    /// <summary>
    /// Changes to the sphere of the button pushed.
    /// </summary>
    /// <param name="destination">Sphere of the 360 video wanted.</param>
    public void ChangeSphere(GameObject destination)
    {
        GameObject currentSphere = FindObjectOfType<VideoPlayer>().gameObject;
        StartCoroutine(StartNextVideo(currentSphere, destination));
    }

    /* Coroutine to load the next video during the transition animation. */
    private IEnumerator StartNextVideo(GameObject currentSphere, GameObject destination)
    {
        VideoPlayer videoPlayer = destination.GetComponentInChildren<VideoPlayer>();

        fadeAnim.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        destination.SetActive(true);
        transform.position = destination.transform.position;
        while (!videoPlayer.isPlaying)
            yield return null;
        ActivateCanvas(currentSphere, destination.GetComponentInChildren<Canvas>());
    }

    /* Activates the canvas of the current sphere. */
    private void ActivateCanvas(GameObject currentSphere, Canvas destinationCanvas)
    {
        GameObject[] informations = GameObject.FindGameObjectsWithTag("Informations");

        currentSphere.SetActive(false);

        foreach (GameObject infoBubble in informations)
            infoBubble.SetActive(false);

        destinationCanvas.enabled = true;
    }
}
