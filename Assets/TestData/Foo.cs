using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

[CreateAssetMenu(fileName = "foo", menuName = "TestData/Foo")]
public class Foo : ScriptableObject, ISerializationCallbackReceiver
{
    public Bar bar;
    public int baz;
    public int boz;

    public void OnBeforeSerialize()
    {
    }

    public void OnAfterDeserialize()
    {
        if (bar != null)
        {
            baz = bar.baz;
        }
    }
}
