using UnityEngine;
using UnityEngine.UI;

public class ShopScoreText : MonoBehaviour
{
   public int score;
   public Text scoreText;

   private void Update()
   {
      score = PlayerPrefs.GetInt("Score");
      scoreText.text = score.ToString();
   }
}
