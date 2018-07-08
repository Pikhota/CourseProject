using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tests
{
    [CreateAssetMenu(fileName = "TestAsset", menuName = "Testing/TestAsset")]
    public class TestAsset : ScriptableObject
    {
        public override string ToString()
        {
            return this.name;
        }
    }
}
