using UnityEngine;

public class Ball : Singleton<Ball>
{
    [SerializeField] private float speed, maxSpeed = 800;
    [SerializeField] private float step = 20;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.maxAngularVelocity = 14;
    }

    public void AddForce(float x, bool speedUp = true)
    {
        if (speedUp && speed < maxSpeed)
            speed += step;

        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
        gameObject.transform.rotation = Quaternion.Euler(0, -x, 0);

        var forceVector = new Vector3(x, transform.position.y, speed);
        var rotateVector = Quaternion.Euler(0, 90, 0) * forceVector;

        _rigidbody.AddForce(x, transform.position.y, speed);
        _rigidbody.AddTorque(rotateVector * speed);
    }

    public void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Wall")
        {
            var velocity = _rigidbody.angularVelocity;

            _rigidbody.angularVelocity = Vector3.zero;
            gameObject.transform.rotation = Quaternion.Euler(0, -transform.rotation.y, 0);
            velocity.x = (velocity.x * speed) * -1;

            _rigidbody.AddTorque(velocity);
        }
    }
}