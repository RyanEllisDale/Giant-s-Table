// Includes : 
using UnityEngine;

[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent (typeof(Collider))]
public class Knockable_CS : MonoBehaviour
{
    [Header("References : ")]
    [SerializeField] private Player_CS Player;
    [SerializeField] private GameObject Table;

    [Header("Knockable :")]
    [SerializeField] private float ObjectValue = 1.0f;

    private void OnValidate()
    {
        Player = FindAnyObjectByType<Player_CS>();
        Table = GameObject.Find("Table");
    }

    private void Awake()
    {
        Player = FindAnyObjectByType<Player_CS>();
        Table = GameObject.Find("Table");
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
