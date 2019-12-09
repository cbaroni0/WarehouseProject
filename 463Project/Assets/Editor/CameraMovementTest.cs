using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class CameraMovementTest
    {
        [Test]
        public void ClampAngleTest()
        {
            var cm = new CameraMovement();
            float test_y = -365f;
            Assert.AreEqual(-5.0f, CameraMovement.ClampAngle(test_y, cm.yMinLimit, cm.yMaxLimit));
            test_y = 365f;
            Assert.AreEqual(5.0f, CameraMovement.ClampAngle(test_y, cm.yMinLimit, cm.yMaxLimit));
        }
    }
}