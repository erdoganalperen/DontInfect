using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject obj = new GameObject();
                _instance = obj.AddComponent<T>();
                obj.name = typeof(T).ToString();
                DontDestroyOnLoad(_instance);
            }
            return _instance;
        }
    }
    protected virtual void Awake()
    {
        _instance = this as T;
    }
}
