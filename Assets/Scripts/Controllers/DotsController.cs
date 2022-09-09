using System.Collections.Generic;
using UnityEngine;

namespace DunkShot.Controllers
{
    public class DotsController : MonoBehaviour
    {
        public float power;
        
        public static DotsController Instance { get; private set; }
        
        public int dotsValue;
        
        public GameObject dotPrefab;
        
        public Transform dotsTransform;

        public BallController ball;
        
        public GameManager gameManager;
        
        private readonly List<GameObject> _dotsObjects = new List<GameObject>();

        public void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            float tempValue = 0.2f;

            for (int i = 0; i < dotsValue; i++)
            {
                GameObject dot = Instantiate(dotPrefab, dotsTransform, true);
                if (i > 1)
                {
                    dot.transform.localScale = new Vector2(tempValue, tempValue);
                    tempValue -= 0.01f;
                }
            
                _dotsObjects.Add(dot);
            }

            dotsTransform.gameObject.SetActive(false);
        }
        
        public void Aim()
        {
            if (GameManager.CursorOverUI()) return;
            if (ball.isShot) return;
            if (Input.GetMouseButton(0))
            {
                if (!gameManager.IsPlay && !gameManager.IsPause)
                    gameManager.Play();
                if (gameManager.IsPause)
                    return;

                StartAim();
            }
            else if (ball.aiming)
            {
                EndAim();
            }
        }

        private void StartAim()
        {
            if (!ball.aiming)
            {
                ball.aiming = true;
                ball.startPos = Input.mousePosition;
                CalculatePath(GetComponent<Rigidbody2D>().mass, ball.startPos);
                Instance.ShowPath();
            }
            else
                CalculatePath(GetComponent<Rigidbody2D>().mass, ball.startPos);
        }

        private void EndAim()
        {
            AudioController.Instance.PlayAudio(AudioController.Instance.shotSound);
            ball.ShootBall();
            ball.aiming = false;
            ball.isShot = true;
            Instance.HidePath();
        }

        private void CalculatePath(float mass, Vector2 startPos)
        {
            dotsTransform.gameObject.SetActive(true);

            Vector2 vel = GetForce(Input.mousePosition, startPos) * Time.fixedDeltaTime / mass;
            for (int i = 0; i < dotsValue; i++)
            {
                float t = i / 10f;
                Vector3 point = PathPoint(transform.position, vel, t);
                point.z = -1.0f;
                _dotsObjects[i].transform.position = point;
            }

        }

        //Get point position
        private Vector2 PathPoint(Vector2 startP, Vector2 startVel, float t)
        {
            return startP + startVel * t + Physics2D.gravity * (0.5f * t * t);
        }

        //Hide all used dots
        private void HidePath()
        {
            dotsTransform.gameObject.SetActive(false);
        }

        //Show all used dots
        private void ShowPath()
        {
            dotsTransform.gameObject.SetActive(true);
        }
        
        public Vector2 GetForce(Vector3 mouse, Vector2 startPos)
        {
            return (new Vector2(startPos.x, startPos.y) - new Vector2(mouse.x, mouse.y)) * power;
        }
    }
}
