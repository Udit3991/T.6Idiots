using UnityEngine;


namespace IF.WorkUnit
{
    public class MockGPS : MonoBehaviour, IGPS
    {
        public bool isValid => true;

        public Vector3 coordinate
        {
            get => new Vector3(latitude, longitude, altitude);
            set
            {
                if (!isDirty)
                {
                    latitude = value.x;
                    longitude = value.y;
                    altitude = value.z;
                }
            }
        }

        public float latitude
        {
            get => _latitude;
            set
            {
                _latitude = value;
                isDirty = true;
            }
        }

        public float longitude
        {
            get => _longitude;
            set
            {
                _longitude = value;
                isDirty = true;
            }
        }

        public float altitude
        {
            get => _altitude;
            set
            {
                _altitude = value;
                isDirty = true;
            }
        }

        public bool isDirty
        {
            get
            {
                if (_isDirty)
                {
                    _isDirty = false;
                    return true;
                }

                return false;
            }
            set
            {
                _isDirty = value;
            }
        }


        [SerializeField] private float _latitude;
        [SerializeField] private float _longitude;
        [SerializeField] private float _altitude;
        [SerializeField] private bool _isDirty;


        private void Awake()
        {
            _latitude = 37.51423263549805f;
            _longitude = 127.03033447265625f;
            _altitude = 0f;
        }
    }
}
