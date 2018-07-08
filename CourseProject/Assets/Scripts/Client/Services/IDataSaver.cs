using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Services
{
    public interface IDataSaver
    {
        void Save(object obj, string path);
    }
}
