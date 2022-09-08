using UnityEngine;

namespace DunkShot.Controllers
{
    public class BallController : MonoBehaviour
    {
        public GameManager gameManager;
        
        [HideInInspector]
        public bool aiming = false;
        public Vector3 startPos;
        public bool isShot = false;
        private bool _isCollision = true;
        
        private int _basketCounter = 0;

        private Rigidbody2D _rb;
        private Collider2D _col;

        private void Start()
        {
            _rb = transform.GetComponent<Rigidbody2D>();
            _col = transform.GetComponent<Collider2D>();
            _rb.isKinematic = true;
            _col.enabled = false;
            startPos = transform.position;
        }

        public void ShootBall()
        {
            _rb.isKinematic = false;
            _col.enabled = true;
            _rb.AddForce(DotsController.Instance.GetForce(Input.mousePosition, startPos));
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ring"))
            {
                isShot = false;
                AudioController.Instance.PlayAudio(AudioController.Instance.ringSound);
            }
            if (collision.gameObject.CompareTag("Wall"))
            {
                isShot = false;
                AudioController.Instance.PlayAudio(AudioController.Instance.bounseSound);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Floor"))
            {
                gameManager.GameOver();
            }
            if (collision.gameObject.CompareTag("Net"))
            {
                isShot = false;
                GameObject net = collision.gameObject;
                net.GetComponent<Animator>().SetTrigger("IsDunk");
                net.GetComponent<Collider2D>().enabled = false;
                Transform basket = net.transform.parent;
                basket.GetComponent<BasketController>().ChangeColorRingGray();

                ScoreController.Instance.AddScore(1);
                CameraFollow.CameraIsMove = true;
                AudioController.Instance.PlayAudio(AudioController.Instance.netSound);

                // Create new basket
                GameObject newBasket = BasketPool.Instace.GetPooledObject();
                if (newBasket != null)
                {
                    switch (_basketCounter)
                    {
                        case 0:
                            newBasket.transform.position = new Vector2(-2f, transform.position.y + Random.Range(2f, 4f));
                            newBasket.transform.rotation = Quaternion.Euler(0, 0, Random.Range(-50f, 0f));
                            newBasket.SetActive(true);
                            _basketCounter++;
                            break;
                        case 1:
                            newBasket.transform.position = new Vector2(2f, transform.position.y + Random.Range(2f, 4f));
                            newBasket.transform.rotation = Quaternion.Euler(0, 0, Random.Range(50f, 0f));
                            newBasket.SetActive(true);
                            _basketCounter = 0;

                            break;
                    }
                }
            }
            // Add star
            if (collision.gameObject.CompareTag("Star"))
            {
                collision.gameObject.SetActive(false);
                StarController.Instance.AddStar(1);
                AudioController.Instance.PlayAudio(AudioController.Instance.coinSound);
            }
        }
    }
}
