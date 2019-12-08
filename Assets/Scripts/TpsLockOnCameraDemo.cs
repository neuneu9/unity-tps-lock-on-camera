using UnityEngine;

[RequireComponent(typeof(TpsLockOnCamera))]
public class TpsLockOnCameraDemo : MonoBehaviour
{
    [SerializeField]
    private TpsLockOnCamera _tpsLockOnCamera = null;

    [SerializeField]
    private Transform[] _targets = null;

    [SerializeField]
    private int _index = 0;

    private void Reset()
    {
        _tpsLockOnCamera = GetComponent<TpsLockOnCamera>();
    }

    private void Start()
    {
        _tpsLockOnCamera.ChangeTarget(_targets[_index]);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _index = _index < _targets.Length - 1 ? _index + 1 : 0;

            _tpsLockOnCamera.ChangeTarget(_targets[_index]);
        }
    }
}
