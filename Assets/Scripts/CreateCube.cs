using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class CreateCube : MonoBehaviour
{
    [SerializeField] private ARRaycastManager raycastManager;

    private List<ARRaycastHit> _hits = new();

    private void Update()
    {
        if (Input.touchCount <= 0)
            return;
        {
            // 사용자가 터치한 곳의 정보를 Touch 라는 변수에 담아 가져올 수 있다.
            Touch touch = Input.GetTouch(0);

            // 사용자가 터치(손가락이 닿음)을 감지
            if (touch.phase != TouchPhase.Began)
                return;

            // 레이캐스트매니저가 사용자의 터치 장소를 이용해
            if (raycastManager.Raycast(touch.position, _hits, TrackableType.PlaneWithinPolygon) == false)
                return;

            // _hits에 정보가 담지기 않았으면 리턴
            if (_hits.Count <= 0)
                return;

            Pose pose = _hits[0].pose;

            Instantiate(raycastManager.raycastPrefab, pose.position, pose.rotation);
        }
    }
}
