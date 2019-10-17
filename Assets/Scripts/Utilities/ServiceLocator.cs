using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ServiceLocator
{
    static Dictionary<object, object> container = null;

    public static T GetService<T> () where T : Object
    {
        if (container == null) container = new Dictionary<object, object>();

        return (T)container[typeof(T)];
    }

    public static void AddService (object key, object service)
    {
        if (container == null) container = new Dictionary<object, object>();

        container.Add(key, service);
    }
}