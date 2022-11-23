using System;
using System.Numerics;
using Player;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Camera
{
    public class CameraController : MonoBehaviour
    {
        public PlayerInput pi;
        public float horizontalSpeed = 100f;
        public float verticalSpeed = 80.0f;

        private GameObject playerHandler; //横着转动沿着y轴 //人物最母级
        private GameObject cameraHandler; //竖着转动沿着x轴 //挂载在人物下面的负责相机x方向
        private float tempEulerX;
        private GameObject model;
        private GameObject camera;

        private void Awake()
        {
            cameraHandler = transform.parent.gameObject;
            playerHandler = cameraHandler.transform.parent.gameObject;
            tempEulerX = 20;
            model = playerHandler.GetComponent<ActorController>().model;
            //获取main camera！！
            camera = UnityEngine.Camera.main.gameObject;
        }

        private void FixedUpdate()
        {
            //分别旋转x轴与y轴
            Vector3 tempModelEuler = model.transform.eulerAngles;
            playerHandler.transform.Rotate(Vector3.up,pi.Jright*horizontalSpeed*Time.deltaTime);
            tempEulerX -= pi.Jup * verticalSpeed * Time.deltaTime;
            tempEulerX = Mathf.Clamp(tempEulerX, -40, 30);
            cameraHandler.transform.localEulerAngles = new Vector3(tempEulerX, 0, 0);
            
            //控制模型不转动
            model.transform.eulerAngles = tempModelEuler;
            
            //摄像机追踪来达到lerp的效果
            camera.transform.position = Vector3.Lerp(camera.transform.position, transform.position, 0.15f);
            camera.transform.eulerAngles = transform.eulerAngles;
        }
    }
}