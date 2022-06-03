using System;

namespace Keycloak.Net.Tests
{
    /// <summary>
    /// Set test cases <a href="https://docs.microsoft.com/en-us/dotnet/core/testing/order-unit-tests?pivots=xunit#order-by-custom-attribute">run priorities</a>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    public class TestPriorityAttribute : Attribute
    {
        public TestPriorityAttribute(int priority) => Priority = priority;

        public int Priority { get; }
    }
}
