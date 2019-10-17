using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SplashScreen : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private GameObject videoShow;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.loopPointReached += EndReached;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void EndReached(VideoPlayer vp)
    {
        vp.loopPointReached -= EndReached;
        videoShow.SetActive(false);
    }
}
