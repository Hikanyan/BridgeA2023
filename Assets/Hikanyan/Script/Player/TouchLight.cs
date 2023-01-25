using Hikanyan.Runner;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hikanyan.Core;

namespace Hikanyan.Gameplay
{
    public class TouchLight : MonoBehaviour, InputInterface
    {
        [SerializeField]
        float Speed = 3.0f;
        [SerializeField]
        private Material normalMaterial;

        private Renderer rend;
        private float alfa = 0.0f;

        private void Start()
        {
            rend = GetComponent<Renderer>();
        }

        void ColorChange()
        {
            alfa = 0.5f;
            //Materialのカラーを変える RGBA
            rend.material = normalMaterial;
            rend.material.color = new Color(rend.material.color.r, rend.material.color.g, rend.material.color.b, alfa);
        }
        void Update()
        {
            if (!(rend.material.color.a <= 0))
            {
                rend.material.color = new Color(rend.material.color.r, rend.material.color.g, rend.material.color.b, alfa);
            }

            alfa -= Speed * Time.deltaTime;
        }
        /// <summary>
        /// Playerが対応するキーを押したときに呼び出されるインターフェース
        /// </summary>
        public void Press()
        {
            ColorChange();
        }
    }
}