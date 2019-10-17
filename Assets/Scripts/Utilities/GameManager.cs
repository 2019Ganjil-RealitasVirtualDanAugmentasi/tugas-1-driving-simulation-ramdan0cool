using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CarTypes {
    SAPU_ANGIN,
    LOWO_IRENG
}

public class GameManager : MonoBehaviour
{

    #region Singleton
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance != null)
                return instance;
            instance = FindObjectOfType<GameManager>();
            if (instance != null)
                return instance;
            Create();
            return instance;
        }
    }

    private static GameManager Create()
    {
        GameObject GameManagerObject = new GameObject("GameManager");
        DontDestroyOnLoad(GameManagerObject);
        instance = GameManagerObject.AddComponent<GameManager>();
        return instance;
    }

    private void Awake()
    {
        if (Instance != this) Destroy(gameObject);
        ServiceLocator.AddService(this);
    }
    #endregion

    public CarTypes CarType { get; set; } = CarTypes.LOWO_IRENG;
}