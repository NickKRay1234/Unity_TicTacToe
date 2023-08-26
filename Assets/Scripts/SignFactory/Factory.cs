using Unity.VisualScripting;
using UnityEngine;

namespace SignFactory
{
    public abstract class Factory : MonoBehaviour
    {
        public abstract IProduct GetProduct(Vector3 position);
    }
}