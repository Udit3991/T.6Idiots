using IF.WorkUnit;
using UnityEngine;


namespace IF.WorkUnit
{
    public class MockUnitOfWork : IUnitOfWork
    {
        public MockUnitOfWork()
        {
            var gameObject = new GameObject(nameof(MockGPS));
            gameObject.transform.SetParent(GameManager.instance.transform);
            gps = gameObject.AddComponent<MockGPS>();
        }


        public IGPS gps { get; private set; }
    }
}
