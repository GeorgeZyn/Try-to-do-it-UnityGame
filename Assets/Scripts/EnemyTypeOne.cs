using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyTypeOne : MonoBehaviour
{
   public Transform target;
   public float speed = 5f;
   public float rotateSpeed = 200f;
   private Rigidbody2D rb;
   Player player;

   Coin coin;
   private int coinHave;

   // Time for destroy
   private float StartTime;
   public float EndTime;


   private void Start()
   {
      rb = GetComponent<Rigidbody2D>();
      player = FindObjectOfType<Player>();
      target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
      coinHave = PlayerPrefs.GetInt("Score");
      coin = FindObjectOfType<Coin>();
   }

   private void FixedUpdate()
   {
      // Player harassment
      Vector2 direction = (Vector2)target.position - rb.position;
      direction.Normalize();
      float rotateAmount = Vector3.Cross(direction, transform.right).z;

      rb.angularVelocity = -rotateAmount * rotateSpeed;
      rb.velocity = transform.right * speed;

      // Object lifetime
      StartTime += 1f * Time.deltaTime;
      if (StartTime >= EndTime)
         Destroy(gameObject);
   }

   // Actions when colliding with a player
   private void OnTriggerEnter2D(Collider2D collision)
   {
      if (collision.CompareTag("Player")) {
         Destroy(gameObject);
         if (player.myHealth > 5)
            player.myHealth -= 5f;
         else
         {
            PlayerPrefs.SetInt("Score", coinHave + coin.score);
            SceneManager.LoadScene(1);
         }                   
      }
   }
}
