using UnityEngine;

public class EnemyTypeTwo : MonoBehaviour
{
   public float speed;
   public float stopingdistance;
   public float retreatDistance;

   public Transform player;

   public float fireRate = 1f;
   private float nextFireTime;
   public GameObject bullet;
   public GameObject bulletParent;

   private float StartTime;
   public float EndTime;

   private void Start()
   {
      player = GameObject.FindGameObjectWithTag("Player").transform;
   }

   private void Update()
   {
      if (Vector2.Distance(transform.position, player.position) > stopingdistance)
         transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
      else if (Vector2.Distance(transform.position, player.position) < stopingdistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
         transform.position = this.transform.position;
      else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
         transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);

      if(nextFireTime < Time.time)
         Shoot();

      // Object lifetime
      StartTime += 1f * Time.deltaTime;
      if (StartTime >= EndTime)
         Destroy(gameObject);
   }

   void Shoot()
   {
      Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
      nextFireTime = Time.time + fireRate;
   }

}
