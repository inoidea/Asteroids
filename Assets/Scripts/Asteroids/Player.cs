using UnityEngine;

namespace Asteroids
{
    internal sealed class Player : MonoBehaviour, IHealth
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _hp;
        [SerializeField] private float _force = 500;
        [SerializeField] private Rigidbody2D _bullet;
        [SerializeField] private Transform _barrel;

        private Camera _camera;
        private Ship _ship;

        public float Health { 
            get { return _hp; }
            set { _hp = value; }
        }

        private void Start()
        {
            _camera = Camera.main;
            var moveTransform = new AccelerationMove(transform, _speed, _acceleration);
            var rotation = new RotationShip(transform);
            _ship = new Ship(moveTransform, rotation);
        }

        private void Update()
        {
            var direction = Input.mousePosition - _camera.WorldToScreenPoint(transform.position);
            _ship.Rotation(direction);
            _ship.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _ship.AddAcceleration();
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _ship.RemoveAcceleration();
            }

            if (Input.GetButtonDown("Fire1"))
            {
                Attack.Fire(_bullet, _barrel, _force);
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            Damage.GetDamage(gameObject);
        }
    }
}
