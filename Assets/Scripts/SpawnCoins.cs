using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SpawnCoins : MonoBehaviour
{
   public GameObject coin;
   public Transform[] spawnPoint;

   private int randPosition;

   public float TimeStep;

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
      Instantiate(coin, spawnPoint[randPosition].transform.position, Quaternion.identity);

      Repeat();
   }
}
