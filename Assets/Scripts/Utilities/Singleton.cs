using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance != null)
                return instance;
            instance = FindObjectOfType<T>();
            if (instance != null)
                return instance;
            Create();
            return instance;
        }
    }

    private static T Create()
    {
        GameObject GameManagerObject = new GameObject(typeof(T).ToString());
        DontDestroyOnLoad(GameManagerObject);
        instance = GameManagerObject.AddComponent<T>();
        return instance;
    }

    private void Awake()
    {
        if (Instance != this) Destroy(gameObject);
        ServiceLocator.AddService(typeof(T), gameObject.GetComponent<T>());
    }
}
