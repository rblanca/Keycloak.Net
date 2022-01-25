using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Keycloak.Net.Tests
{
    /// <summary>
    /// Set test collection <a href="https://docs.microsoft.com/en-us/dotnet/core/testing/order-unit-tests?pivots=xunit#order-by-collection-alphabetically">run order</a>.
    /// </summary>
    public class DisplayNameOrderer : ITestCollectionOrderer
    {
        public IEnumerable<ITestCollection> OrderTestCollections(
            IEnumerable<ITestCollection> testCollections)
        {
            return testCollections.OrderByDescending(collection => collection.DisplayName);
        }
    }
}
