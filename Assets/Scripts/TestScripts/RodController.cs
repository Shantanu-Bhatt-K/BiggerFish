using GogoGaga.OptimizedRopesAndCables;
using UnityEngine;
using UnityEngine.EventSystems;

public class RodController : MonoBehaviour
{
    public Transform rodTransform;
    public ConfigurableJoint baitJoint;
    public Rope fishRope;
    public Rigidbody baitRigidbody; // Assign this in the Inspector (the bait's Rigidbody)
    bool isThrown = false;
    private Quaternion initRotation;
    private bool isDragging = false;
    private Vector2 accumulatedDrag = Vector2.zero; // To store drag delta
    public float forceModifier = 0.1f;
    public float lateralForceModifier = 0.1f;
    public float fullLine = 10f;
    public Transform fishTip;
    void Start()
    {
        initRotation = rodTransform.localRotation;
    }

    void Update()
    {
        HandleDrag();
    }

    private void HandleDrag()
    {
        isDragging = Input.GetMouseButton(0);

        if (isDragging)
        {
            Cursor.lockState = CursorLockMode.Locked;

            // Accumulate drag delta
            Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * 10f; // You can scale this
            accumulatedDrag += mouseDelta;

            Quaternion rotation = Quaternion.Euler(-mouseDelta.y, mouseDelta.x, 0);
            rotation = rotation * rodTransform.localRotation;
            rodTransform.localRotation = Quaternion.Slerp(rodTransform.localRotation, rotation, 0.1f);
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            rodTransform.localRotation = Quaternion.Slerp(rodTransform.localRotation, initRotation, 0.1f);
        }

        if (Input.GetMouseButtonUp(0))
        {
            // Release joint lock
            SoftJointLimit limit = baitJoint.linearLimit;
            limit.limit = fullLine;
            baitJoint.linearLimit = limit;


            // Calculate force direction based on accumulated drag
            Vector3 forceDir = (Camera.main.transform.forward + Camera.main.transform.up).normalized ; 
            Vector3 lateralForceDir = Camera.main.transform.right;// Example: forward and upward
            float verticalForceStrength = -accumulatedDrag.y * forceModifier; // Scale to your needs
            float lateralForceStrength = -accumulatedDrag.x * lateralForceModifier;
            // Apply the force to the bait
            baitRigidbody.AddForce(forceDir * verticalForceStrength + lateralForceDir * lateralForceStrength, ForceMode.Impulse);

            // Reset drag accumulation
            accumulatedDrag = Vector2.zero;
            isThrown = true;
        }

        if(isThrown)
        {
            fishRope.ropeLength = (baitRigidbody.transform.position - fishTip.position).magnitude + 0.5f;
        }
    }
}
