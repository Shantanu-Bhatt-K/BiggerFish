using Unity.VisualScripting;
using UnityEngine;

public class WorldPlayer : MonoBehaviour
{

    private Vector3 _input;

    public Vector3 Input{ get { return _input; } set { _input = value; } }
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float moveSpeed = 5f;  
    public Interactable currentInteractable;

    // Event that passes the Collider to subscribers when the player enters a trigger
    public event System.Action<Collider> OnTriggerEnterEvent;
    public event System.Action<Collider> OnTriggerExitEvent;

    void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        rb.MovePosition(transform.position + moveSpeed * Time.fixedDeltaTime * _input);
    }
    void OnTriggerEnter(Collider collision)
    {
        OnTriggerEnterEvent?.Invoke(collision);
    }
    void OnTriggerExit(Collider collision)
    {
        OnTriggerExitEvent?.Invoke(collision);
    }
}
