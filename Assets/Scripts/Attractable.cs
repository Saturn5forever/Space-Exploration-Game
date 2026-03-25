using Unity.VisualScripting;
using UnityEngine;

public class Attractable : MonoBehaviour
{
    private Rigidbody2D rb;
    private float playerMass;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerMass = rb.mass;
    }

    public void Attract(Gravity planetAttractor)
    {
        Transform planetTransform = planetAttractor.GetTransform();
        Vector2 directionToPlanet = (Vector2)planetTransform.position - rb.position;
        float distance = directionToPlanet.magnitude;

        if(distance == 0f) return;

        float forceMagnitude = planetAttractor.gravityStrength * playerMass * planetAttractor.rbMass / (distance * distance);

        Vector2 force = directionToPlanet.normalized * forceMagnitude;
        rb.AddForce(force);
    }
}
