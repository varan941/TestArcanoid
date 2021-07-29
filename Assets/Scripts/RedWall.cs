using UnityEngine;

public class RedWall : MonoBehaviour
{
    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Ball")
        {
            GameManager.I.RedCounter++;
        }
    }
}
