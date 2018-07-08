using System;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.IO;
using Models;
using Services;
using UnityEditor;

namespace Tests
{
    public class DataLoadingTests
    {
        [Test]
        public void ResourcesDataLoader_Load_MethodShouldHandleWrongPath()
        {
            var path = "RES_WrongPath";
            var loader = new ResourcesDataLoader();
            LogAssert.ignoreFailingMessages = true;

            Assert.Throws<FileNotFoundException>(
                () => loader.Load<TestAsset>(path));
        }

        [Test]
        public void ResourcesDataLoader_Load_MethodShouldHandleWrongType()
        {
            var pathProject = "Assets/Resources/TestAsset.asset";
            var pathR = "TestAsset";
            var loader = new ResourcesDataLoader();
            LogAssert.ignoreFailingMessages = true;

            var asset = ScriptableObject.CreateInstance<TestAsset>();
            AssetDatabase.CreateAsset(asset, pathProject);
            AssetDatabase.SaveAssets();

            Assert.Throws<InvalidCastException>(
                () => loader.Load<Texture2D>(pathR));
        }

        [Test]
        public void JsonFileDataLoader_Load_MethodShouldHandleWrongPath()
        {
            var path = Application.dataPath + "/JSON_WrongPath.txt";
            var loader = new JsonFileDataLoader();
            LogAssert.ignoreFailingMessages = true;

            Assert.Throws<FileNotFoundException>(
                () => loader.Load<String>(path));
        }

        [TearDown]
        public void UnCheckIgnoreFailingMessages()
        {
            LogAssert.ignoreFailingMessages = false;
        }

        [TearDown]
        public void CleanCreatedAssetsInResources()
        {
            var path = "Assets/Resources/";
            var format = ".asset";
            var assets = Resources.FindObjectsOfTypeAll<TestAsset>();

            foreach (var asset in assets)
            {
                AssetDatabase.MoveAssetToTrash(path + asset.ToString() + format);
            }

            AssetDatabase.SaveAssets();
        }
    }
}