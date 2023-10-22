using System;
using UnityEngine;

namespace Scripts.Table
{
    public class PacHandler : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;

        public void ResetPac(Vector3 resetPosition)
        {
            _rigidbody.velocity  = Vector3.zero;

            transform.position = resetPosition;
        }
    
        private void OnValidate()
        {
            _rigidbody ??= GetComponent<Rigidbody>();
        }
    }
}

