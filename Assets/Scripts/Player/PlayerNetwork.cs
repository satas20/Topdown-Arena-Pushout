using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerNetwork : NetworkBehaviour
{
    private NetworkVariable<PlayerNetworkData> _netState = new(writePerm: NetworkVariableWritePermission.Owner);
    private Vector3 _vel;
    private float _rotVel;
    [SerializeField] private float _cheapInterpoalationTime = 0.1f;

    void Update()
    {
        if (IsOwner)
        {

            _netState.Value = new PlayerNetworkData()
            {
                Position = transform.position,
                Rotation = transform.rotation.eulerAngles
            };
        }
        else {

            //transform.position = Vector3.SmoothDamp(transform.position, _netState.Value.Position, ref _vel, _cheapInterpoalationTime);
            //transform.rotation = Quaternion.Euler(
            //    0,
            //    0,
            //    Mathf.SmoothDampAngle(transform.rotation.eulerAngles.z, _netState.Value.Rotation.z, ref _rotVel, _cheapInterpoalationTime));
            transform.position = _netState.Value.Position;
            transform.rotation =Quaternion.Euler(_netState.Value.Rotation);
        }
    }

    struct PlayerNetworkData : INetworkSerializable {
        private float _x, _y;
        private short _zRot;

        internal Vector3 Position
        {
            get => new Vector3(_x, _y, 0);
            set {
                _x = value.x;
                _y = value.y;
            }
        }
        internal Vector3 Rotation
        {
            get => new Vector3(0, 0, _zRot);
            set{
                _zRot = (short)value.z;
            }
        }
            
        public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
        {
            serializer.SerializeValue(ref _x);
            serializer.SerializeValue(ref _y);

            serializer.SerializeValue(ref _zRot);

        }
    }
}
