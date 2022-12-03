using System;
using UnityEngine;

namespace Manager
{
    public class FxController : MonoBehaviour
    {
        public static FxController instance;
        public GameObject[] attackFx;

        private void Awake()
        {
            instance = this;
        }

        public void SpawnFx(int index)
        {
            attackFx[index].SetActive(true);
        }
        public void QuitFx(int index)
        {
            attackFx[index].SetActive(false);
        }
    }
}