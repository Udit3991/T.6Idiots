using IF.WorkUnit;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject(nameof(GameManager)).AddComponent<GameManager>();
            }

            return _instance;
        }
    }
    private static GameManager _instance;

    public IUnitOfWork unitOfWork;


    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(_instance);
    }

    private void OnEnable()
    {
#if UNITY_EDITOR
        unitOfWork = new MockUnitOfWork();
#elif UNITY_ANDROID
        unitOfWork = new UnitOfWork();
#else
#endif
    }
}
