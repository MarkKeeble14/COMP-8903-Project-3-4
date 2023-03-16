using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PhysicsEngine))]
public class Drag : MonoBehaviour
{

    /* -------------------- PART 3 ------------------------------------*/
    // Velocity Exponent: ----- (velocityExponent)
    // Define a public float variable for velocityExponent: 
    //NOTE: This value cannot be more than 2, so define a range first.
    [Range(0, 2)] public float velocityExponent;

    /* -------------------- PART 3 ------------------------------------*/
    // Drag constant: ----- (dragConstant)
    // Define a public float for dragConstant:
    public float dragConstant;

    private PhysicsEngine physicsEngine;

    // Use this for initialization
    void Start()
    {
        physicsEngine = GetComponent<PhysicsEngine>();
    }

    /* -------------------- PART 3 ------------------------------------*/
    // Follow comment
    void FixedUpdate()
    {
        // Define Vector 3 for the velocityVector from the physicsEngine:
        Vector3 velocityVector = physicsEngine.velocityVector;

        // Find the magnitude of the velocityVector:
        float magnitude = velocityVector.magnitude;

        // Call the fundtion CalculateDrag to find the magnitude of the drag force:
        float dragSize = CalculateDrag(magnitude);

        //Normalizing and find the dragVector
        // Comment out the line below:
        Vector3 dragVector = dragSize * -velocityVector.normalized;

        /// Add the force to the list of the forces on physicsEngine;
        physicsEngine.AddForce(dragVector);
    }


    /* -------------------- PART 3 ------------------------------------*/
    // calculate the drag force here:
    // F = dragConstant * v^(velocityExponent)
    // Use Mathf.Pow
    float CalculateDrag(float speed)
    {
        // TODO
        return dragConstant * Mathf.Pow(speed, velocityExponent);
    }
}