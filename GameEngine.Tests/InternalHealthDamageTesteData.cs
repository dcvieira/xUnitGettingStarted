using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine.Tests
{
    public class InternalHealthDamageTesteData
    {
        public static IEnumerable<object[]> TestData
        {
            get
            {
                yield return new object[] { 0, 100 };
                yield return new object[] { 1, 99 };
                yield return new object[] { 50, 50 };
                yield return new object[] { 101, 1 };
            }
        }
    }
}
