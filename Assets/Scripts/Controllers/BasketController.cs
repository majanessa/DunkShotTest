using UnityEngine;

namespace DunkShot.Controllers
{
    public class BasketController : MonoBehaviour 
    {
        public Collider2D coll;
        
        public GameObject star;

        private void OnEnable()
        {
            if (star != null)
            {
                int random = Random.Range(1, 4);
                if (random == 1)
                {
                    star.SetActive(true);
                }
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("DestroyPool"))
            {
                coll.enabled = true;
                gameObject.SetActive(false);
            }
        }

        private void ChangeColorRing(Color color)
        {
            Transform hoopOne = gameObject.transform.GetChild(0);
            Transform hoopTwo = gameObject.transform.GetChild(1);
            hoopOne.gameObject.GetComponent<SpriteRenderer>().color = color;
            hoopTwo.gameObject.GetComponent<SpriteRenderer>().color = color;
        }

        public void ChangeColorRingGray()
        {
            ChangeColorRing(new Color32(173, 173, 173, 255));
        }
        
        public void ChangeColorRingRed()
        {
            ChangeColorRing(new Color32(207, 0, 0, 255));
        }
    }
}
