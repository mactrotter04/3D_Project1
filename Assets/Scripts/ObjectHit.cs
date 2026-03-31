using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("obsticle"))
        {
            Debug.Log("bumped into " + other.gameObject.name);
            other.gameObject.GetComponent<MeshRenderer>().material.color = Color.lightSteelBlue;
            other.gameObject.tag = "Hit";
        }
    }
}
