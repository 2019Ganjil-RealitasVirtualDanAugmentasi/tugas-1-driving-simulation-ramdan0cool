using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using DG.Tweening;
using UnityEngine.UI;

public class SplashScreen : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private GameObject videoShow;

    private SceneMaster sceneMaster;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.loopPointReached += EndReached;
        sceneMaster = ServiceLocator.GetService<SceneMaster>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void EndReached(VideoPlayer vp)
    {
        vp.loopPointReached -= EndReached;
        //videoShow.SetActive(false);
        videoShow.GetComponent<RawImage>().DOFade(0, 3f).OnComplete(() => { sceneMaster.SceneLoadAsync(1); });
    }
}
