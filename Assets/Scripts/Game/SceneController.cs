using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public int sceneIndex;
    public Vector2 playerPosition;
    public VectorValue playerStorage;
    [SerializeField] Animator anim;

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.CompareTo("Player") == 0)
        {
            // print(transform.position);
            playerStorage.initialValue = playerPosition;
            StartCoroutine(LoadMap());
        }
    }

    private IEnumerator LoadMap()
    {
        anim.SetTrigger("End");
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Single);
        anim.SetTrigger("Start");
    }
}
