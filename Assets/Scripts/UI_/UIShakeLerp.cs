using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI_
{
    public class UIShakeLerp : MonoBehaviour
    {
        public float UpDownScale_y=0.05f;
        public float UpDownScale_frequency = 5f;
        private RectTransform thisTransform;
        private Vector3 targetBodPos;
        private Vector3 originTransPos;
        private float counter;
        public Button thisButton;

        private void Start()
        {
            print("second loaded!");
            thisTransform = GetComponent<RectTransform>();
            originTransPos = thisTransform.localPosition;
        }
        private void FixedUpdate()
        {
            if (thisButton != null)
            {
                if (thisButton.interactable == true)
                {
                    HeadBob(counter, 0, UpDownScale_y);
                    thisTransform.localPosition =
                        Vector3.Lerp(thisTransform.localPosition, targetBodPos, Time.deltaTime * 10f);
                    counter += Time.fixedDeltaTime * UpDownScale_frequency;
                }
                else return;
            }
            else
            {
                HeadBob(counter, 0, UpDownScale_y);
                thisTransform.localPosition =
                    Vector3.Lerp(thisTransform.localPosition, targetBodPos, Time.deltaTime * 10f);
                counter += Time.fixedDeltaTime * UpDownScale_frequency;
            }
        }
        void HeadBob(float p_z, float p_x_intensity, float p_y_intensity)
        {
            targetBodPos = originTransPos + new Vector3( (float)Math.Cos(p_z) * p_x_intensity, (float)Math.Cos(p_z) * p_y_intensity*2,
                0f);
        }
    }
}