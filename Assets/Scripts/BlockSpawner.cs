using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject[] blockPrefabs;
    public Sprite[] spawnerSprites;

    private int currentBlockIndex = 0;
    public GameObject defaultBlockPrefab;
    private float speed = 2.0f;
    private float leftBoundary = -3f;
    private float rightBoundary = 3f;
    private SpriteRenderer _spriteRenderer;
    private bool movingRight = true;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        if (_spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer component not found!");
        }
    }

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

        if (blockPrefabs.Length > 0)
        {
            Instantiate(blockPrefabs[currentBlockIndex], spawnPosition, Quaternion.identity);

            if (currentBlockIndex == blockPrefabs.Length - 1)
            {
                currentBlockIndex = 0;
            }
            else
            {
                currentBlockIndex++;
            }

            if (spawnerSprites.Length > 0 && _spriteRenderer != null)
            {
                _spriteRenderer.sprite = spawnerSprites[currentBlockIndex];
            }
        }
        else
        {
            Instantiate(defaultBlockPrefab, spawnPosition, Quaternion.identity);
        }
        
    }
}
