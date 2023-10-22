using UnityEngine;

namespace Scripts.Players.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerTag _playerTag;
    
        [SerializeField] private float _accelerationTime ;
        [SerializeField] private float _targetSpeed ;
        private float _currentSpeed;
        private float _elapsedTime;
    
        [SerializeField] private Rigidbody _rigidbody;

        public PlayerTag PlayerTag => _playerTag;

        private void OnValidate()
        {
            _rigidbody ??= GetComponent<Rigidbody>();
        }

        public void Move(Vector2 input)
        {
            // if (input.magnitude < 0.01f)
            // {
            //     _rigidbody.velocity = Vector3.zero;
            //     _elapsedTime = 0.0f;
            //     return;
            // }
        
            _elapsedTime += Time.deltaTime;
        
            float interpolationFactor = _elapsedTime / _accelerationTime;

            _currentSpeed = Mathf.Lerp(0.0f, _targetSpeed, interpolationFactor);
        
            _rigidbody.velocity = new Vector3(input.x, 0, input.y)  * _currentSpeed;
        }
    }
}

