using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
   GameObject target;
   public float speed;
   private Rigidbody2D bulletRB;
   Player player;

   Coin coin;
   private int coinHave;

   private void Start()
   {
      player = FindObjectOfType<Player>();
      bulletRB = GetComponent<Rigidbody2D>();
      target = GameObject.FindGameObjectWithTag("Player");
      Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
      bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
      Destroy(this.gameObject, 2);
      coinHave = PlayerPrefs.GetInt("Score");
      coin = FindObjectOfType<Coin>();
   }

   private void OnTriggerEnter2D(Collider2D collision)
   {
      if (collision.CompareTag("Player"))
      {
         Destroy(gameObject);
         if (player.myHealth > 10)
            player.myHealth -= 10f;
         else
         {
            PlayerPrefs.SetInt("Score", coinHave + coin.score);
            SceneManager.LoadScene(1);
         }
      }
   }
}
