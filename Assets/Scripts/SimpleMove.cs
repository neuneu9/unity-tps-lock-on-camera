using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    [SerializeField]
    private Transform _cameraTransform = null;

    [SerializeField]
    private float _speed = 10f;


    private Vector3 _velocity = Vector3.zero;


    private void Update()
    {
        _velocity = Vector3.zero;

        if (Input.GetKey(KeyCode.A))
        {
            _velocity -= _cameraTransform.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _velocity += _cameraTransform.right;
        }
        if (Input.GetKey(KeyCode.W))
        {
            _velocity += _cameraTransform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _velocity -= _cameraTransform.forward;
        }

        transform.position += Vector3.ProjectOnPlane(_velocity * _speed * Time.deltaTime, Vector3.up);
    }
}
