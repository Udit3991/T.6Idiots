using UnityEngine;


namespace IF.WorkUnit
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork()
        {
            var gameObject = new GameObject(nameof(GPS));
            gameObject.transform.SetParent(GameManager.instance.transform);
            gps = gameObject.AddComponent<GPS>();
        }


        public IGPS gps { get; private set; }
    }
}
