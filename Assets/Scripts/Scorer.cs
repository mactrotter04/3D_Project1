using UnityEngine;

public class Scorer : MonoBehaviour
{
    int hits = 0;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("obsticle"))
        {
            hits++;
            Debug.Log("You bumped into Obstilce " + hits + " times");
        }
    }
}
