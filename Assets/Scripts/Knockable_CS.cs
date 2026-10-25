// Includes : 
using UnityEngine;

[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent (typeof(Collider))]
public class Knockable_CS : MonoBehaviour
{
    [Header("References : ")]
    [SerializeField] protected Player_CS Player;
    [SerializeField] protected GameObject Table;
    [SerializeField] protected Rigidbody RigidBody;

    [Header("Knockable : ")]
    [SerializeField] protected float ObjectValue = 1.0f;
    [SerializeField] protected float Mass = 1.0f;

    protected void OnValidate()
    {
        Player = FindAnyObjectByType<Player_CS>();
        Table = GameObject.Find("Table");

        RigidBody = gameObject.GetComponent<Rigidbody>();
        RigidBody.mass = Mass;
    }

    protected void Awake()
    {
        Player = FindAnyObjectByType<Player_CS>();
        Table = GameObject.Find("Table");

        RigidBody = gameObject.GetComponent<Rigidbody>();
        RigidBody.mass = Mass;
    }

    // Death : 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor") == true && collision.gameObject != Table)
        {
            Player.Grow(ObjectValue);
            Destroy(gameObject);
        }
    }


}
