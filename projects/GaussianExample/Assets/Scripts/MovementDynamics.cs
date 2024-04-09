using System;
using GaussianSplatting.Runtime;
using UnityEngine;

namespace ICTGS
{
    public class MovementDynamics : MonoBehaviour
    {
        [SerializeField] private GaussianSplatRenderer gs;
        [SerializeField] private float speed = 10f;
        [SerializeField] private Vector3 size;

        private readonly Vector3 _direction = new(-1, 0.0f, 1);
        
        private void Start()
        {
            var center = new Vector3();
            
            gs.editSelectedBounds = new Bounds(center, size);
        }

        private void Update()
        {
            var delta = _direction * (speed * Time.deltaTime);
            
            gs.EditTranslateSelection(delta);
            transform.position += delta;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireCube(transform.position, size);
        }
    }
}

