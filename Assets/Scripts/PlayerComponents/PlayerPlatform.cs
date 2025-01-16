using Traps;
using UnityEngine;

namespace PlayerComponents
{
    public class PlayerPlatform : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            Platform platform = other.GetComponent<Platform>();
            if (platform != null)
            {
                transform.SetParent(other.transform);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            Platform platform = other.GetComponent<Platform>();
            if (platform != null)
            {
                transform.SetParent(null); 
            }
        }
    }
}