using UnityEngine;

public class Barrel : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag ("Player"))
        {
            GameManager.gamePlayManager.LifeDown();
            Destroy(gameObject);
        }
    }

}
