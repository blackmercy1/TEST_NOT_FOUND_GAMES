using Plugins.Inputs_master.Inputs_master.Unity.Keys;
using UnityEngine;

namespace Code
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private AnimationCurve _curve;
        [SerializeField] private Projectile _projectilePrefab;
        [SerializeField] private Camera _camera;
        [SerializeField] private float _fireForce;

        private IKey _fireKey;

        private void Awake()
        {
            _fireKey = new KeyDown(KeyCode.Mouse0);
        }

        private void Update()
        {
            if (_fireKey.HasInput())
                Fire();
        }

        private void Fire()
        {
            var position = transform.position;
            var projectile = Instantiate(_projectilePrefab, position, Quaternion.identity);

            var mousePosition = Input.mousePosition;
            var viewportPoint = _camera.ScreenToWorldPoint(mousePosition);

            var delta = viewportPoint - position;
            var result = new Vector3(delta.x, 0, delta.z);
            
            projectile.Initialize(
                new ApplyPositionComposite(
                    new IDeltaPosition[]
                    {
                        new YDeltaPositionFromValue(
                            new CurveDeltaPosition(_curve, new UnityDeltaTime())),
                        new ConstantMultiplyDeltaPosition(
                            new FluidMultiplyDeltaPosition(new ConstantDeltaPosition(result), new UnityDeltaTime()),
                            _fireForce)
                    }));
        }
    }
}