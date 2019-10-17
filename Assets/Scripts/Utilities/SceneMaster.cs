using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMaster : Singleton<SceneMaster>
{
    public void SceneLoadAsync(int index)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(index, LoadSceneMode.Single);
    }
}
