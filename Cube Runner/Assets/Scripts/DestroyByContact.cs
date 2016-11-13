using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {
    public GameController gameController;
    public GameObject playerExplosion;

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Obstacle"))
        {
            Instantiate(playerExplosion, transform.position, transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
            gameController.GameOver();
        }
        else if (other.CompareTag("Score"))
        {
            int score = other.GetComponent<ScoreController>().getScore();
            gameController.addScore(score);
        }
    }

}
