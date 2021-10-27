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
                print("點擊座標: " + positionMouse);
            }
        }


    }
}

