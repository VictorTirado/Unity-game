using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;



namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof(CarController))]
    public class CarUserControl : MonoBehaviourPun
    {
        private CarController m_Car; // the car controller we want to use
        private TextMesh Caption = null;

        void Start()
        {
            for (int i = 0; i < this.transform.childCount; i++)
            {
                if (this.transform.GetChild(i).name == "Caption")
                {

                    Caption = this.transform.GetChild(i).gameObject.GetComponent<TextMesh>();
                    Caption.text = string.Format("Car{0}", photonView.ViewID);
                }
            }
        }

        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }

        private void FixedUpdate()
        {
            // pass the input to the car!
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");
#if !MOBILE_INPUT
            float handbrake = CrossPlatformInputManager.GetAxis("Jump");
            if (photonView.IsMine == true)
                m_Car.Move(h, v, v, handbrake);
#else
            m_Car.Move(h, v, v, 0f);
#endif
        }
    }
}
