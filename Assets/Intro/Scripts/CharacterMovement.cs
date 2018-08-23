using System.Collections;
using UnityEngine;
namespace Intro
{
    [RequireComponent(typeof(CharacterController))]
    public class CharacterMovement : MonoBehaviour
    {
        [Header("Movement Variables")]
        [Space(30)]
        [Header("Mini Header")]
        [Range(0f, 100f)]
        public float speed = 6.0f;
        //How fast the character travels when moving. Set to 6.0f
        public float jumpSpeed = 8.0f;
        //Jump speed of character upon jumping, set to 8.0f
        public float gravity = 20.0f;
        //Gravity affecting player, set to 20.0f value
        private Vector3 moveDirection = Vector3.zero;
        //Characters move direction on the xyz axis is set to 0, so no input will occur when starting the scene
        public CharacterController controller;
        //Referencing the character controller in Unity

        private void Start()
        {
            controller = GetComponent<CharacterController>();
            //Obtains the CharacterController Game Component on scene start for the first time, does not continously try and obtain after void start
        }

        void Update()
        {
            if (controller.isGrounded)
            //If the character is resting on 0xyz axis
            {
                moveDirection = new Vector3(Input.GetAxis("Horizontal"),
                    //Obtains characters x coordinates. Upon character input, updates character coords on x axis
                    0, Input.GetAxis("Vertical"));//Does not affect Y axis, character stays grounded
                moveDirection = transform.TransformDirection(moveDirection);
                //Moves Character on x axis

                moveDirection *= speed;
                //When moving, moves character at speed of 6.0f
                if (Input.GetButton("Jump"))
                {
                    moveDirection.y = jumpSpeed;
                }
            }
            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);
        }
    }
}
