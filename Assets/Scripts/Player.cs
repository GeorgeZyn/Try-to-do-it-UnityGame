using UnityEngine;

public class Player : MonoBehaviour
{
   // public GameObject Enemy;
   private float horizontal;
   public float speed = 8f;
   public float myHealth;
   public float jumpingPower = 20f;

   public AudioSource hitSound;

   public GameObject particleDestroyedEnemyTypeOne;
   public GameObject particleDestroyedEnemyTypeTwo;
   public GameObject particleJump;

   [SerializeField] private Rigidbody2D rb;
   [SerializeField] private Transform groundCheck;
   [SerializeField] private LayerMask groundLayer;

   // Update is called once per frame
   private void Start()
   {
      rb = GetComponent<Rigidbody2D>();

      myHealth = PlayerPrefs.GetInt("PlayerHP");
      if (myHealth == 0) PlayerPrefs.SetInt("PlayerHP", 1);
      myHealth *= 5;
   }
   void Update()
   {
      horizontal = Input.GetAxisRaw("Horizontal");

      if (Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded())
      {
         rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
         Instantiate(particleJump, groundCheck.transform.position, Quaternion.identity);
      }
   } 

   private void FixedUpdate()
   {
      rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
   }

   private bool IsGrounded()
   {
      return Physics2D.OverlapCircle(groundCheck.position, 0.45f, groundLayer);
   }


   private void OnTriggerEnter2D(Collider2D collision)
   {
      if (collision.CompareTag("Enemy")) {
         Instantiate(particleDestroyedEnemyTypeOne, collision.transform.position, Quaternion.identity);
         hitSound.Play(); 
      }

      if (collision.CompareTag("Enemy2"))
      {
         Instantiate(particleDestroyedEnemyTypeTwo, collision.transform.position, Quaternion.identity);
         hitSound.Play();
      }

   }
}
