using UnityEngine;
using UnityEngine.SceneManagement;

public class Scorer : MonoBehaviour
{
    int hits = 0;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Win"))
        {
            Destroy(other.gameObject);
            Debug.Log("You win!");
            Invoke(nameof(LoadNextScene), 1f);
        }
        else if (other.gameObject.CompareTag("obsticle"))
        {
            hits++;
            Debug.Log("You bumped into Obstilce " + hits + " times");
            other.gameObject.GetComponent<MeshRenderer>().material.color = Color.lightSteelBlue;
            other.gameObject.tag = "Hit";
        }
        else if (other.gameObject.CompareTag("Death"))
        {
            ReloadLevel();
        }
        
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("No more scenes to load");
        }
    }
}
