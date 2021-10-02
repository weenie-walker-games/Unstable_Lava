using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WeenieWalker
{
    public class Player : MonoBehaviour
    {

        [SerializeField] private float _moveSpeed = 3f;
        [SerializeField] private float _jumpForce = 2f;

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
            //Check for input
            if (Input.GetKeyDown(KeyCode.Space))
            {

            }





            Move();

        }

        private void Move()
        {

            Vector3 moveVector;
            moveVector.x = Input.GetAxis("Horizontal");
            moveVector.z = Input.GetAxis("Vertical");
            moveVector.y = 0;

            Debug.Log("pre: " + moveVector);

            moveVector.x = transform.position.x * (moveVector.x * _moveSpeed * Time.deltaTime);
            moveVector.z = transform.position.z * (moveVector.x * _moveSpeed * Time.deltaTime);
            moveVector.y = transform.position.y;
            Debug.Log("post: " + moveVector);

            //transform.position = moveVector;
        }

        private void Jump()
        {

        }
    }
}
