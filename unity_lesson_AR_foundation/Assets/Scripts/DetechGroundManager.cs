using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

namespace Ker.ARFoundation
{
    public class DetechGroundManager : MonoBehaviour
    {
        [Header("點擊後生成的物件")]
        public GameObject goSpawn;
        [Header("AR 射線管理器"), Tooltip("須放在攝影機origin物件")]
        public ARRaycastManager arraycastManager;
        [Header("生成物件要面向的攝影機物件")]
        public Transform tracam;
        [Header("面向攝影機的速度")]
        public float speedLookAt=3.5f;

        private Transform traSpawn;
        private List<ARRaycastHit> hits = new List<ARRaycastHit>();
        
        private bool InputMouseLeft { get => Input.GetKeyDown(KeyCode.Mouse0); }

        private void Update()
        {
            ClickandDetechGround();
            SpawnLookAt();
        }

        private void ClickandDetechGround()
        {
            if (InputMouseLeft) {
                Vector2 positionMouse = Input.mousePosition;
                //print("點擊座標: " + positionMouse);
                //Ray ray = Camera.main.ScreenPointToRay(positionMouse);

                if(arraycastManager.Raycast(positionMouse, hits, TrackableType.PlaneWithinPolygon)) {
                    Vector3 positionhit = hits[0].pose.position;

                    if (traSpawn == null) {
                        traSpawn = Instantiate(goSpawn, positionhit, Quaternion.identity).transform;
                        traSpawn.localScale = Vector3.one * 0.5f;
                    }
                    else {
                        traSpawn.position = positionhit;
                    }
                    
                }
            }
        }

        private void SpawnLookAt()
        {
            if (traSpawn == null) return;
            Quaternion angle = Quaternion.LookRotation(tracam.position - traSpawn.position);
            traSpawn.rotation = Quaternion.Lerp(traSpawn.rotation, angle, Time.deltaTime * speedLookAt);
            Vector3 angleOriginal = traSpawn.localEulerAngles;
            angleOriginal.x = 0;
            angleOriginal.z = 0;
            traSpawn.localEulerAngles = angleOriginal;
        }

    }
}

