using UnityEngine;

[RequireComponent(typeof(BlockSpawner))]
public class PlayerÑonstruction : MonoBehaviour
{
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
        if (_blockSpawner != null)
        {
            _blockSpawner.SpawnBlock();
        }
    }
}
