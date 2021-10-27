using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

namespace Ker.ARFoundation
{
    public class DetechGroundManager : MonoBehaviour
    {
        [Header("�I����ͦ�������")]
        public GameObject goSpawn;
        [Header("AR �g�u�޲z��"), Tooltip("����b��v��origin����")]
        public ARRaycastManager arraycastManager;
        [Header("�ͦ�����n���V����v������")]
        public Transform tracam;
        [Header("���V��v�����t��")]
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
                //print("�I���y��: " + positionMouse);
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

