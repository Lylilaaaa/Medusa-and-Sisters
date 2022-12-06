using System;
using UnityEngine;
namespace UI_
{
    public class UILookAtCam: MonoBehaviour
    { 
        //挂在需要看向摄像机的UI物体上（例如血条，伤害冒字）
        public Camera refCamera;
        public bool reverFace = false;
        private Transform mRoot;
        private Transform originalTrans;
        private void Awake()
        {
            if (!refCamera)
            {
                refCamera = Camera.main;
            }
            mRoot = transform;
            originalTrans = mRoot;
        }
        

        private void Update()
        {
            Vector3 targetPos = mRoot.position + refCamera.transform.rotation * (reverFace?Vector3.back:Vector3.forward);
            Vector3 targetOrientation = refCamera.transform.rotation * Vector3.up;
            mRoot.LookAt(targetPos, targetOrientation);
            //mRoot.position += mRoot.up * Time.deltaTime;
        }
    }
}