using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameObjects
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float jumpStrength = 6f;
        [SerializeField] private float speed = 2f;
        
        private Rigidbody2D _rb;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            _rb.velocity = new Vector2(speed, _rb.velocity.y);
        }

        private void GameOver()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.GetComponent<Platform>() != null)
            {
                var sign = transform.position.y - collision.transform.position.y;
                sign /= Math.Abs(sign);
                _rb.velocity = new Vector2(_rb.velocity.x, jumpStrength * sign);
            }
            else
            {
                GameOver();
            }
        }
    }
}
