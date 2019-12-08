using UnityEngine;

public class TpsLockOnCamera : MonoBehaviour
{
    /// <summary>
    /// 取りつくキャラクター
    /// </summary>
    [SerializeField]
    private Transform _attachTarget = null;

    /// <summary>
    /// 取りつくキャラクターからのカメラオフセット位置
    /// </summary>
    [SerializeField]
    private Vector3 _attachOffset = new Vector3(0f, 2f, -5f);

    /// <summary>
    /// 注視ターゲット
    /// </summary>
    [SerializeField]
    private Transform _lookTarget = null;

    /// <summary>
    /// ターゲットがいないときの注視点
    /// </summary>
    [SerializeField]
    private Vector3 _defaultLookPosition = Vector3.zero;

    /// <summary>
    /// ロック切り替え時間
    /// </summary>
    [SerializeField]
    private float _changeDuration = 0.1f;

    /// <summary>
    /// ロック切り替えタイマー
    /// </summary>
    private float _timer = 0f;

    /// <summary>
    /// 現在の注視点
    /// </summary>
    private Vector3 _lookTargetPosition = Vector3.zero;

    /// <summary>
    /// ロックを移すときの最後の注視点
    /// </summary>
    private Vector3 _latestTargetPosition = Vector3.zero;


    /// <summary>
    /// ターゲット切り替え
    /// </summary>
    /// <param name="target"></param>
    public void ChangeTarget(Transform target)
    {
        _latestTargetPosition = _lookTargetPosition;
        _lookTarget = target;

        _timer = 0f;
    }


    private void LateUpdate()
    {
        var targetPosition = _lookTarget != null ? _lookTarget.position : _defaultLookPosition;

        // 現在の注視点を更新
        if (_timer < _changeDuration)
        {
            _timer += Time.deltaTime;
            _lookTargetPosition = Vector3.Lerp(_latestTargetPosition, targetPosition, _timer / _changeDuration);
        }
        else
        {
            _lookTargetPosition = targetPosition;
        }

        // ターゲットへのベクトル
        Vector3 targetVector = _lookTargetPosition - _attachTarget.position;

        // ターゲットへのベクトルを前方とするクォータニオン
        Quaternion targetRotation = targetVector != Vector3.zero ? Quaternion.LookRotation(targetVector) : transform.rotation;

        // 位置と向き
        Vector3 position = _attachTarget.position + targetRotation * _attachOffset;
        Quaternion rotation = Quaternion.LookRotation(_lookTargetPosition - position);

        transform.SetPositionAndRotation(position, rotation);
    }
}
