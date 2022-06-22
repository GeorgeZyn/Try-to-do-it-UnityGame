using System.Collections;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
   public GameObject enemy;
   public Transform[] spawnPoint;

   private int randPosition;

   public float TimeStep;

   /*public float startTimeBtwSpawns;
   private float timeBtwSpawns;*/

   private void Start()
   {
      StartCoroutine(SpawnObjects());
   }

   private void Repeat()
   {
      StartCoroutine(SpawnObjects());
   }

   IEnumerator SpawnObjects()
   {
      yield return new WaitForSeconds(TimeStep);
      randPosition = Random.Range(0, spawnPoint.Length);
      Instantiate(enemy, spawnPoint[randPosition].transform.position, Quaternion.identity);

      Repeat();
   }
}
