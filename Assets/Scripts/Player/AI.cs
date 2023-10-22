using Scripts.Players.Controllers;
using Scripts.Table;
using UnityEngine;

namespace Scripts.Players.AI
{
    public class AI : BasePlayer
    {
        private const float OFF_SET = 1.5f;
        private const float MINIMUM_STRIKE_DISTANCE = 0.3f;
        private const float STRIKE_POSITION_Z_TO_PAC = 2f;
        private const float CONST_Y_VALUE = 0.2f;
        private const float PETROL_Z_POSITION = 6;
        private const float PETROL_MOVE_SPEED = 5;

        private bool _isPacInMySide;
        private bool _firstFrameThatPacInMySide = true;
        
        private bool _reachToTheStrikePosition = false;

        private Vector3 _offsetPacPosition;

        private Vector2 _input;
        
        public AI(PlayerController playerController) : base(playerController)
        {
        }

        public override void Update()
        {
            _isPacInMySide = TableHandler.PacSide == PlayerTag.Red;
            
            if (_isPacInMySide)
            {
                float xOffset = 0;
                float zOffset = 0;
                
                if (_firstFrameThatPacInMySide)
                {
                    _firstFrameThatPacInMySide = false;
                    xOffset = Random.Range(-OFF_SET, OFF_SET);
                    zOffset = Random.Range(-OFF_SET, OFF_SET);
                    _reachToTheStrikePosition = false;
                }
                
                if (_reachToTheStrikePosition)
                {
                    _offsetPacPosition = new Vector3(TableHandler.PacPosition.x + xOffset, CONST_Y_VALUE,
                        TableHandler.PacPosition.z + zOffset);
                
                    Vector3 direction = _offsetPacPosition - PlayerController.transform.position;
                    _input = new Vector2(direction.x, direction.z);
                }
                else
                {
                    Vector3 strikePosition = new Vector3(TableHandler.PacPosition.x + xOffset, CONST_Y_VALUE,
                        TableHandler.PacPosition.z + STRIKE_POSITION_Z_TO_PAC + zOffset);
                    
                    _reachToTheStrikePosition = Vector3.Distance(
                        strikePosition,
                        PlayerController.transform.position) < MINIMUM_STRIKE_DISTANCE;
                    
                    Vector3 direction = strikePosition - PlayerController.transform.position;
                    _input = new Vector2(direction.x, direction.z);
                }
            }
            else
            {
                if (!_firstFrameThatPacInMySide)
                    _firstFrameThatPacInMySide = true;
                
                _input = Vector2.zero;

                PlayerController.transform.position = Vector3.MoveTowards(PlayerController.transform.position,
                    new Vector3(TableHandler.PacPosition.x, CONST_Y_VALUE, PETROL_Z_POSITION),PETROL_MOVE_SPEED * Time.deltaTime);
            }
        }

        public override void FixedUpdate()
        {
            //Vector2.ClampMagnitude(_input, 1.5f);
            PlayerController.Move(_input.normalized);
        }
    }
}