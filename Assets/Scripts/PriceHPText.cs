using UnityEngine;
using UnityEngine.UI;

public class PriceHPText : MonoBehaviour
{
   public Text priceText;

   private void Update()
   {
      int priceGet = PlayerPrefs.GetInt("Price");
      priceText.text = priceGet.ToString();
   }
}
