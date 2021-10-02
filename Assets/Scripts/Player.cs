using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeenieWalker
{
    public class Player : MonoBehaviour
    {

        [SerializeField] private float _moveSpeed = 3f;
        [SerializeField] private float _jumpHeight = 3f;
        [SerializeField] private float _fallMultiplier = 0.5f;
        [SerializeField] CharacterController _controller;

        //Make adjustable gravity
        [SerializeField] private float _gravity = -9.81f;
        public float Gravity { get { return _gravity; } set { _gravity = value; } }

        private bool _isGrounded = true;
        private Vector3 _velocity;



        [SerializeField] private Transform _groundCheck;
        [SerializeField] private float _groundDistance = 0.4f;
        [SerializeField] private LayerMask _groundMask;


        private void OnEnable()
        {
            
        }

        private void OnDisable()
        {
            
        }

        private void Start()
        {
            
        }

        private void Update()
        {


            Move();
            Jump();





        }

        private void Move()
        {

            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            if (direction.magnitude >= 0.1f)
            {
                _controller.Move(direction.normalized * _moveSpeed * Time.deltaTime);
            }


        }

        private void Jump()
        {
            //Use a physics sphere to see if colliding with the ground
            _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundMask);

            //Reset the velocity if on the ground
            if (_isGrounded && _velocity.y < 0f)
            {
                _velocity.y = -2f;
            }
            
            if (Input.GetButtonDown("Jump") && _isGrounded)
            {
                //Physics equation, provided by Brackeys
                _velocity.y = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
            }

            //Another physics equation provided by Brackeys
            _velocity.y += _fallMultiplier * _gravity * Time.deltaTime;
            _controller.Move(_velocity * Time.deltaTime);



        }


    }
}
