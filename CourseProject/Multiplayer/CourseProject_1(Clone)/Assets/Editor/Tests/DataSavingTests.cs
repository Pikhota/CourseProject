using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.IO;
using Models;
using Services;

namespace Tests
{
    public class DataSavingTests
    {

        [Test]
        public void JsonFileDataSaver_Save_MethodShouldHandleWrongPath()
        {
            var path = Application.dataPath + "/JSON_WrongPath.txt";
            var saver = new JsonFileDataSaver();
            var obj = new Object();

            LogAssert.ignoreFailingMessages = true;

            Assert.Throws<FileNotFoundException>(
                () => saver.Save(obj, path));
        }


        [TearDown]
        public void UnCheckIgnoreFailingMessages()
        {
            LogAssert.ignoreFailingMessages = false;
        }
    }
}
