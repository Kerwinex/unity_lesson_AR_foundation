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

        private Transform traSpawn;
        private List<ARRaycastHit> hits = new List<ARRaycastHit>();
        
        private bool InputMouseLeft { get => Input.GetKeyDown(KeyCode.Mouse0); }

        private void Update()
        {
            ClickandDetechGround();
        }

        private void ClickandDetechGround()
        {
            if (InputMouseLeft) {
                Vector2 positionMouse = Input.mousePosition;
                print("�I���y��: " + positionMouse);
            }
        }


    }
}

