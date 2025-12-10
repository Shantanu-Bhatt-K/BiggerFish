using GogoGaga.OptimizedRopesAndCables;
using System.Collections.Generic;
using UnityEngine;

public class RodBend : MonoBehaviour
{
    public Transform highestBone;
    public Transform lowestBone;
    public Vector3 appliedForce;
    public Rope rope; 
    public Transform bendTransform;
    public Transform linePoint;
    [Header("Bend Settings")]
    public float bendIntensity = 1f; // How strongly the rod bends
    public float smoothness = 5f;    // Smooth transition
    public Transform rod;
    private List<Quaternion> initialRotations = new List<Quaternion>();

    private List<Transform> rodBones = new List<Transform>();


    void Start()
    {
        // Build list of bones from highest to lowest
        Transform currentBone = highestBone;
        while (true)
        {
            rodBones.Add(currentBone);
            initialRotations.Add(currentBone.localRotation);
            if (currentBone == lowestBone) break;
            currentBone = currentBone.parent;
        }

        
    }
    private void Update()
    {
        ApplyBend();
    }
    void ApplyBend()
    {
        
        appliedForce = bendTransform.position - linePoint.position;

        Vector3 localForce = Vector3.zero;
        if (appliedForce.magnitude >= rope.ropeLength )
        {
            localForce = appliedForce;
        }
        // Direction of force in local space
        

        for (int i = 0; i < rodBones.Count; i++)
        {
            float t = (float)(i + 1) / rodBones.Count;

            // Smaller bones (closer to tip) bend more
            Vector3 bendAxis = Vector3.Cross(rodBones[i].up, localForce).normalized;
            float bendAmount = localForce.magnitude * bendIntensity * t;

            Quaternion targetRotation = Quaternion.AngleAxis(bendAmount, bendAxis);
            rodBones[i].localRotation = Quaternion.Slerp(rodBones[i].localRotation, initialRotations[i] * targetRotation, Time.deltaTime * smoothness);
        }
    }

    // Optional: public method to set force from outside (e.g. when a fish pulls)
    public void SetForce(Vector3 force)
    {
        appliedForce = force;
    }

}
