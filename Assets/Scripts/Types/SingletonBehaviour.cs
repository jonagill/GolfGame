using UnityEngine;
using System.Collections.Generic;

public abstract class SingletonBehaviour<T> : MonoBehaviour where T:SingletonBehaviour<T>
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                T[] instancesInScene = FindObjectsOfType<T>();
                if (instancesInScene.Length == 0)
                {
                    Debug.LogWarning("Singleton instance of " + typeof(T).ToString() + " not found in scene.");
                }
                else
                {
                    Debug.Assert(instancesInScene.Length == 1,
                        "Multiple instances of " + typeof(T).ToString() + " found when assigning singleton.");
                    _instance = instancesInScene[0];
                }
            }
            return _instance;
        }
    }
}
