using SignFactory;
using UnityEngine;

internal interface IMarkFactory
{
    IProduct GetProduct(Transform parent);
}