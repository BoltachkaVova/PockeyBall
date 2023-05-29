using System;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    [SerializeField] private float jumpForce;

    private Rigidbody _rigidbody;

    public event Action Finish;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.isKinematic = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Finish>())
            Debug.Log("Win");
    }

    private void Update()
    {
        Ray ray = new Ray(transform.position, Vector3.forward);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (hitInfo.collider.TryGetComponent(out Segment segment))
                {
                    _rigidbody.isKinematic = false;
                    _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                if (hitInfo.collider.TryGetComponent(out Segment segment))
                {
                    _rigidbody.isKinematic = true;
                    _rigidbody.velocity = Vector3.zero;
                }
            }
        }

        Debug.DrawRay(transform.position, transform.forward * 5f, Color.red);
    }
}
