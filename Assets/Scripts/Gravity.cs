using Mono.Cecil.Cil;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public float gravityStrength = 9.81f;
    public float attractionRadius = 10f;
    public LayerMask attractableLayer;
    private Transform planetTransform;
    public float rbMass;
    Rigidbody2D rb;


    void Awake()
    {
        planetTransform = transform; 
        rb = GetComponent<Rigidbody2D>(); 
        rbMass = rb.mass;     
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(planetTransform.position, attractionRadius, attractableLayer);
        foreach (Collider2D collider in colliders)
        {
            Attractable attractedObject = collider.GetComponent<Attractable>();
            if (attractedObject != null)
            {
                attractedObject.Attract(this);
            }
            
        }
    }
    public Transform GetTransform()
    {
        return planetTransform;
    }
}
