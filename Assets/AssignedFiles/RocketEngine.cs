using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PhysicsEngine))]
public class RocketEngine : MonoBehaviour
{
    public float fuelMass;              // kg
    public float maxThrust;             // kN [kg m s^-2]

    [Range(0, 1f)]
    public float thrustPercent;         // [none]

    public Vector3 thrustUnitVector;    // [none]

    private PhysicsEngine physicsEngine;
    private float currentThrust;        // N

    // Use this for initialization
    void Start()
    {
        physicsEngine = GetComponent<PhysicsEngine>();
        physicsEngine.mass += fuelMass;
    }

    void FixedUpdate()
    {
        if (fuelMass > FuelThisUpdate())
        {
            fuelMass -= FuelThisUpdate();
            physicsEngine.mass -= FuelThisUpdate();

            physicsEngine.AddForce(thrustUnitVector);
            ExertForce();
        }
        else
        {
            Debug.LogWarning("Out of rocket fuel");
        }

        float FuelThisUpdate()
        {
            float exhastMassFlow;    //
            float effectiveExhastVelocity;   //

            effectiveExhastVelocity = 4462f;   //[m s^-1] 
            exhastMassFlow = currentThrust / effectiveExhastVelocity;

            return exhastMassFlow * Time.deltaTime; //kg

        }
        void ExertForce()
        {
            currentThrust = thrustPercent * maxThrust * 1000f;
            Vector3 thrustVector = thrustUnitVector.normalized * currentThrust; //N
            physicsEngine.AddForce(thrustVector);

        }
    }
}