using UnityEngine;
using System.Collections;

public class UniversalGravitation : MonoBehaviour
{
    private PhysicsEngine[] physicsEngineArray;

    /* -------------------- PART 2 ------------------------------------*/
    //Define the private constant for the G (gravitational coeeficient):
    private const float G = 6.6743e-11F;

    // Use this for initialization
    void Start()
    {
        physicsEngineArray = FindObjectsOfType<PhysicsEngine>();
    }

    void FixedUpdate()
    {
        CalculateGravity();
    }

    /* -------------------- PART 2 ------------------------------------*/
    void CalculateGravity()
    {
        // for each object in physicsEngineArray:
        foreach (PhysicsEngine ObjectA in physicsEngineArray)
        {
            // for each object in the physicsEngineArray:
            foreach (PhysicsEngine ObjectB in physicsEngineArray)
            {
                // Now we have two objects A and B; we can calulcate the Fg.
                //Eliminate duplicatation: if ObjectA is not Object B
                if (ObjectA == ObjectB) continue;
                //Eliminate gravity on itself: If objectA=!this
                if (ObjectA == this) continue;

                // Find the (r) distance between Object A and Object B:
                Vector3 offset = ObjectB.transform.position - ObjectA.transform.position;
                float r = offset.magnitude;

                // Find (r^2) distance to the power of two; use Mathf.Pow: 
                float rSquared = Mathf.Pow(r, 2);

                // Find (Fg) magnitude of the gravity force; 
                float gravityMagnitude = G * ObjectA.mass * ObjectB.mass / rSquared;

                // Normalizing the gravity; Just uncomment the line below:
                Vector3 gravityFeltVector = gravityMagnitude * offset.normalized;

                // Add the force to the list of the forces on physicsEngine for object A; 
                // Note that you need to take care of the negative sign (downward acceleration) manually:
                ObjectA.AddForce(gravityFeltVector);
            }
        }
    }
}