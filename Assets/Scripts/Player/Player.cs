using Scripts.Players.Controllers;
using UnityEngine;

namespace Scripts.Players
{
    public class Player : BasePlayer
    {
        private Vector2 _mouseDirection;
        
        public Player(PlayerController playerController) : base(playerController)
        {
        }
        
        public override void Update()
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            // mouseX *= sensitivity * Time.deltaTime;
            // mouseY *= sensitivity * Time.deltaTime;
            
            _mouseDirection += new Vector2(mouseX, mouseY);
        }

        private void ResetMouseDirectionDelta()=>
            _mouseDirection  = Vector2.zero;
        

        public override void FixedUpdate()
        {
            PlayerController.Move(_mouseDirection);
            ResetMouseDirectionDelta();
        }
    }
}