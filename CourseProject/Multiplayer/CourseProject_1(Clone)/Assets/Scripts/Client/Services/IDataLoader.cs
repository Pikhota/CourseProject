using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Services
{
    public interface IDataLoader
    {
        T Load<T>(string path);
    }
}
