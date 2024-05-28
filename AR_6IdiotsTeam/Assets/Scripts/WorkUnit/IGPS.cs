using UnityEngine;


namespace IF.WorkUnit
{
    public interface IGPS
    {
        /// <summary> 사용 가능 여부 </summary>
        bool isValid { get; }

        /// <summary> 위도, 경도, 고도 </summary>
        Vector3 coordinate { get; }

        /// <summary> 위도 </summary>
        float latitude { get; }

        /// <summary> 경도 </summary>
        float longitude { get; }

        /// <summary> 고도 </summary>
        float altitude { get; }

        /// <summary> 갱신 여부 </summary>
        bool isDirty { get; }
    }
}
