using UnityEngine;

public class PersistentSingleton<T> : MonoBehaviour where T : Component
{
    protected static T _instance;

    public static bool existInstance
    {
        get { return _instance != null; }
    }
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject();
                    _instance = obj.AddComponent<T>();
                }
            }
            return _instance;
        }
    }

    protected virtual void Awake()
    {
        if (!Application.isPlaying)
        {
            return;
        }

        if (_instance == null)
        {
            //If I am the first instance, make me the Singleton
            _instance = this as T;
            DontDestroyOnLoad(transform.gameObject);
        }
        else if (this != _instance)
        {
            //If a Singleton already exists and you find
            //another reference in scene, kill itself !
            Destroy(this.gameObject);

        }
    }
}
