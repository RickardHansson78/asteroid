using DefaultNamespace.ScriptableEvents;
using UnityEngine;
using Variables;
using Random = UnityEngine.Random;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Asteroid : MonoBehaviour
    {
        [SerializeField] private ScriptableEventInt _onAsteroidDestroyed;

        [Header("References:")]
        [SerializeField] private Transform _shape;

        [SerializeField] private AsteroidStats _currentStats;

        private Rigidbody2D _rigidbody;
        private Vector3 _direction;
        private int _instanceId;

        public void SetStats(AsteroidStats stats) => _currentStats = stats;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _instanceId = GetInstanceID();
            
            SetDirection();
            AddForce();
            AddTorque();
            SetSize();
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (string.Equals(other.tag, "Laser"))
            {
               HitByLaser();
            }
        }

        private void HitByLaser()
        {
            _onAsteroidDestroyed.Raise(_instanceId);

            if(_currentStats.Split)
            {
                for(int i = 0; i < _currentStats.SplitNumber; i++)
                {
                    Asteroid asteroid = Instantiate(this, transform.position, Quaternion.identity);
                    asteroid.SetStats(_currentStats.SplitStats);
                }
            }

            Destroy(gameObject);
        }
        
        private void SetDirection()
        {
            var size = new Vector2(3f, 3f);
            var target = new Vector3
            (
                Random.Range(-size.x, size.x),
                Random.Range(-size.y, size.y)
            );

            _direction = (target - transform.position).normalized;
        }

        private void AddForce()
            {
                var force = Random.Range(_currentStats.MinForce, _currentStats.MaxForce);
            _rigidbody.AddForce( _direction * force, ForceMode2D.Impulse);
        }

        private void AddTorque()
        {
            var torque = Random.Range(_currentStats.MinTorque, _currentStats.MaxTorque);
            var roll = Random.Range(0, 2);

            if (roll == 0)
                torque = -torque;
            
            _rigidbody.AddTorque(torque, ForceMode2D.Impulse);
        }

        private void SetSize()
        {
            var size = Random.Range(_currentStats.MinSize, _currentStats.MaxSize);
            _shape.localScale = new Vector3(size, size, 0f);
        }
    }
}
