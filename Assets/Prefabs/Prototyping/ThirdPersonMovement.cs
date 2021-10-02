using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Brackeys
{
    public class ThirdPersonMovement : MonoBehaviour
    {
        /// <summary>
        /// Script from the Brackeys "Third Person Movement in Unity" video, published May 24, 2020
        /// https://www.youtube.com/watch?v=4HpC--2iowE
        /// </summary>

        [SerializeField] private Transform cam;
        [SerializeField] private CharacterController _controller;
        [SerializeField] private float _speed = 6;
        [SerializeField] private float _turnSmoothTime = 0.1f;
        private float _turnSmoothVelocity;

        private void OnEnable()
        {
            
        }

        private void OnDisable()
        {
            
        }

        private void Update()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            if(direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                _controller.Move(moveDir.normalized * _speed * Time.deltaTime);
            }

        }
    }
}
