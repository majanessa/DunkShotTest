using UnityEngine;

namespace DunkShot
{
    public class CameraFollow : MonoBehaviour 
    {
        public static CameraFollow Instace { get; private set; }

        public GameObject target;

        public static bool CameraIsMove = false;
        
        private void Awake() 
        {
            Instace = this;
        }

        public void CameraMove()
        {
            if (CameraIsMove)
            {
                var position = transform.position;
                position = new Vector3(position.x, 
                    Mathf.Lerp(position.y, target.transform.position.y + 4f, 0.02f), 
                    position.z);
                transform.position = position;

                if (transform.position.y >= target.transform.position.y + 3.5f)
                {
                    CameraIsMove = false;
                }
            }
        }
    }
}
