using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Player;
using UnityEngine;
using UnityEngine.UI;
using Cursor = UnityEngine.Cursor;
using Vector3 = UnityEngine.Vector3;

namespace Camera
{
    public class CameraController : MonoBehaviour
    {
        private IUserInput pi;
        public float horizontalSpeed = 100f;
        public float verticalSpeed = 80.0f;
        public Image lockDot;
        

        private GameObject playerHandler; //横着转动沿着y轴 //人物最母级
        private GameObject cameraHandler; //竖着转动沿着x轴 //挂载在人物下面的负责相机x方向
        private float tempEulerX;
        private GameObject model;
        private GameObject _camera;
        private GameObject lockTarget;
        private ActorController ac;
        private bool lockState;

        private void Start()
        {
            lockDot.enabled = false;
            cameraHandler = transform.parent.gameObject;
            playerHandler = cameraHandler.transform.parent.gameObject;
            tempEulerX = 20;
            ac = playerHandler.GetComponent<ActorController>();
            model = ac.model;
            pi = ac.pi;
            //获取main camera!!
            _camera = UnityEngine.Camera.main.gameObject;

            Cursor.lockState = CursorLockMode.Locked;
        }

        private void FixedUpdate()
        {
            if (!lockState)
            {
                //分别旋转x轴与y轴
                playerHandler.transform.Rotate(Vector3.up, pi.Jright * horizontalSpeed * Time.fixedDeltaTime);
                tempEulerX -= pi.Jup * verticalSpeed * Time.fixedDeltaTime;
                tempEulerX = Mathf.Clamp(tempEulerX, -40, 30);
                cameraHandler.transform.localEulerAngles = new Vector3(tempEulerX, 0, 0);
            }

            //控制模型不转动
            Vector3 tempModelEuler = model.transform.eulerAngles;
            model.transform.eulerAngles = tempModelEuler;
            

            //摄像机追踪来达到lerp的效果
            _camera.transform.position = Vector3.Lerp(_camera.transform.position, transform.position, 0.15f);
            _camera.transform.eulerAngles = transform.eulerAngles;
            //防止眩晕抖动
            _camera.transform.LookAt(cameraHandler.transform);
        }

        public void LockOnEnemy()
        {
            Collider[] cols = Physics.OverlapSphere(model.transform.position,ac.lockRadius , LayerMask.GetMask("Enemy"));
            if (cols.Length == 0)
            {
                lockState = false;
                return;
            }
            //确定了会有被锁定的敌人
            lockState = true;
            lockDot.enabled = true;
            float tempDist = 10000f;
            foreach (Collider col in cols)
            {
                float thisDist = Vector3.Distance(col.gameObject.transform.position, model.transform.position);
                if (thisDist < tempDist)
                {
                    tempDist = thisDist;
                    lockTarget = col.gameObject;
                }
            }

            lockDot.rectTransform.position = UnityEngine.Camera.main.WorldToScreenPoint(lockTarget.gameObject.transform.position);
        }

        public void LockingOnEnemy()
        {
            if (lockState == true)
            {
                lockDot.rectTransform.position =
                    UnityEngine.Camera.main.WorldToScreenPoint(lockTarget.gameObject.transform.position);
                Vector3 tempForward = lockTarget.transform.position - model.transform.position;
                tempForward.y = 0;
                playerHandler.transform.forward = tempForward;
            }
        }

        public void UnLockOnEnemy()
        {
            if (lockState == true)
            {
                lockState = false;
                lockDot.enabled = false;
                lockTarget = null;
            }
        }

        private IEnumerator Shake(float duration, float magnitude)
        {

            Vector3 originalPosition = transform.position;
            float currTime = 0f;
            while (currTime < duration)
            {

                float x = UnityEngine.Random.Range(-0.5f, 0.5f) * magnitude;
                float y = UnityEngine.Random.Range(-0.5f, 0.5f) * magnitude;

                transform.localPosition = originalPosition + new Vector3(x, y, 0);

                currTime += Time.deltaTime;
                yield return null;
            }

            transform.localPosition = originalPosition;
        }

    }
}