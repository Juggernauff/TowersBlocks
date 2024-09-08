using UnityEngine;

public class Block : MonoBehaviour
{
    public delegate void BlockLandedHandler();
    public static event BlockLandedHandler OnBlockLanded;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Block"))
        {
            OnBlockLanded?.Invoke();
        }
    }
}
