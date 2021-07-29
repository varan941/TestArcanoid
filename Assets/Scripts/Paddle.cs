using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private float speed = 10f, angle = 200;
    private float _paddleInitialY, _paddleInitialZ;

    public Transform leftBorder, rightBorder;

    private void Start()
    {
        _paddleInitialY = transform.position.y;
        _paddleInitialZ = transform.position.z;
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        mousePos.x = Mathf.Clamp(mousePos.x, leftBorder.position.x, rightBorder.position.x);
        Vector3 targetPos = new Vector3(mousePos.x, _paddleInitialY, _paddleInitialZ);

        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Ball")
        {
            AddForceToBall(coll);
            GameManager.I.GreenCounter++;
        }
    }

    private void AddForceToBall(Collision coll)
    {
        Vector3 hitPoint = coll.contacts[0].point;
        Vector3 paddleCenter = transform.position;

        var difference = hitPoint.x - paddleCenter.x;

        float x = difference * angle;
        Ball.I.AddForce(x);
    }
}
