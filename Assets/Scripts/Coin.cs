using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
   public AudioSource coinSound;
   public int score;
   [SerializeField] Text scoreText;

   public GameObject particleCoin;


   private void OnTriggerEnter2D(Collider2D collision)
   {
      if (collision.CompareTag("Coin"))
      {
         Instantiate(particleCoin, collision.transform.position, Quaternion.identity);
         coinSound.Play();
         score++;
         Destroy(collision.gameObject);
      }
   }

   private void Update()
   {
      scoreText.text = score.ToString();
   }
}

