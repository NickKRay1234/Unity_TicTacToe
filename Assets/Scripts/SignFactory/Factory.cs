using UnityEngine;

namespace SignFactory
{
    public abstract class Factory : MonoBehaviour
    {
        public abstract IProduct GetProduct(Transform parent);
    }
}