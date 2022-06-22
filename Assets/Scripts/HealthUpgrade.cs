using UnityEngine;
using UnityEngine.UI;

public class HealthUpgrade : MonoBehaviour
{
   public string product;

   public Image[] emptyIcon;
   public Sprite fillIcon;
   public int upgradeLimit;

   public AudioSource accessUp;
   public AudioSource failedUp;

   private void Start()
   {
      if (!PlayerPrefs.HasKey("Price"))
         PlayerPrefs.SetInt("Price", 5);
      iconsUpdate();
   }

   public void productUpgrade()
   {
      int score = PlayerPrefs.GetInt("Score");
      int count = PlayerPrefs.GetInt(product);
      int price = PlayerPrefs.GetInt("Price");


      if (count < upgradeLimit && score >= price)
      {
         count++;
         PlayerPrefs.SetInt(product, count);

         emptyIcon[count - 1].overrideSprite = fillIcon;

         PlayerPrefs.SetInt("Score", score - price);
         price = PlayerPrefs.GetInt("Price") + 5;

         PlayerPrefs.SetInt("Price", price);

         accessUp.Play();
      }
      else
         failedUp.Play();
   }

   void iconsUpdate()
   {
      int count = PlayerPrefs.GetInt(product);

      for (int i = 0; i < count; i++)
      {
         emptyIcon[i].overrideSprite = fillIcon;
      }
   }
}
