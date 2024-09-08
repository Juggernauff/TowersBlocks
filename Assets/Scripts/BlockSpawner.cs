using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject blockPrefab;
    private float speed = 2.0f;
    private float leftBoundary = -3f;
    private float rightBoundary = 3f;

    private bool movingRight = true;

    private void Update()
    {
        MoveSpawner();
    }

    private void MoveSpawner()
    {
        if (movingRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            if (transform.position.x >= rightBoundary)
            {
                movingRight = false;
            }
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            if (transform.position.x <= leftBoundary)
            {
                movingRight = true;
            }
        }
    }

    public void SpawnBlock()
    {
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, 0);
        Instantiate(blockPrefab, spawnPosition, Quaternion.identity);
    }
}
