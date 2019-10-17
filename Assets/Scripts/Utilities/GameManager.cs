using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CarTypes {
    SAPU_ANGIN,
    LOWO_IRENG
}

public class GameManager : Singleton<GameManager>
{
    public CarTypes CarType { get; set; } = CarTypes.LOWO_IRENG;
}