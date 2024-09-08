using UnityEngine;

[RequireComponent(typeof(BlockSpawner))]
public class PlayerСonstruction : MonoBehaviour
{
    [SerializeField] private float timeBetweenBuilds = 2.0f;

    private float lastBuildTime = 0.0f;
    private PlayerInput _playerInput;
    private BlockSpawner _blockSpawner;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.Player.Build.performed += context => Build();

        _blockSpawner = FindObjectOfType<BlockSpawner>();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void Build()
    {
        if (Time.time - lastBuildTime >= timeBetweenBuilds)
        {
            if (_blockSpawner != null)
            {
                _blockSpawner.SpawnBlock();
                lastBuildTime = Time.time;
            }
        }
        else
        {
            Debug.Log("Слишком быстро! Подождите перед следующим нажатием.");
        }
    }
}
