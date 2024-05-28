using IF.Utils;
using IF.WorkUnit;
using UnityEngine;

public class GameManager : SingletonMonoBase<GameManager>
{
    public IUnitOfWork unitOfWork;


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
