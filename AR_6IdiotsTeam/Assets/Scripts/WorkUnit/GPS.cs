using System.Collections;
using UnityEngine;
using UnityEngine.Android;


namespace IF.WorkUnit
{
    public class GPS : MonoBehaviour, IGPS
    {
        public bool isValid { get; private set; }

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

        private bool _isDirty;
        private float _latitude;
        private float _longitude;
        private float _altitude;

        private WaitForSeconds second;
        private bool gpsStarted = false;
        private LocationInfo location;


        private void Awake()
        {
            second = new WaitForSeconds(1.0f);
        }

        IEnumerator Start()
        {
            //만일, GPS사용 허가를 받지 못했다면, 권한 허가 팝업을 띄움
            if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
            {
                Permission.RequestUserPermission(Permission.FineLocation);
                while (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
                {
                    yield return null;
                }
            }
            else
            {
                print($"[{GetType()}({name})]: Permitted");
            }

            // 유저가 GPS 사용중인지 최초 체크
            if (!Input.location.isEnabledByUser)
            {
                Debug.Log($"[{GetType()}({name})]: GPS is not enabled");
                yield break;
            }

            //GPS 서비스 시작
            Input.location.Start();
            Debug.Log($"[{GetType()}({name})]: Awaiting initialization");

            //활성화될 때 까지 대기
            int maxWait = 20;
            while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
            {
                Debug.Log($"[{GetType()}({name})]: {Input.location.status}");
                yield return second;
                maxWait -= 1;
            }

            //20초 지날경우 활성화 중단
            if (maxWait < 1)
            {
                Debug.Log($"[{GetType()}({name})]: Timed out");
                yield break;
            }

            //연결 실패
            if (Input.location.status == LocationServiceStatus.Failed)
            {
                Debug.Log($"[{GetType()}({name})]: Unable to determine device location");
                yield break;

            }
            else
            {
                //접근 허가됨
                isValid = true;
                gpsStarted = true;
                Debug.Log($"[{GetType()}({name})]: GPS start!");

                //현재 위치 갱신
                while (gpsStarted)
                {
                    location = Input.location.lastData;
                    latitude = location.latitude;
                    longitude = location.longitude;
                    altitude = location.altitude;
                    yield return second;
                }
            }

            // 더이상 사용하지 않으면 GPS를 끔
            StopGPS();
        }

        /// <summary>
        /// 위치 서비스 종료
        /// </summary>
        public void StopGPS()
        {
            if (Input.location.isEnabledByUser)
            {
                gpsStarted = false;
                Input.location.Stop();
            }
        }
    }
}
