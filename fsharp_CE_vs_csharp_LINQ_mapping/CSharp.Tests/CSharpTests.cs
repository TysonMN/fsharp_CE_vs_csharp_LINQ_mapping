using Xunit;
using MonadNamespace.LINQ;

namespace CSharp.Tests {
  public class CSharpTests {
    [Fact]
    public void CSharp_LINQ() {
      var mc =
        from a in MonadModule.Monad.ma
        from b in MonadModule.Monad.mb
        select a + b;
      var c = MonadClass.Value(mc);
      Assert.Equal(3, c);
      Assert.Equal((1, 1), (MonadModule.Monad.bindCount, MonadModule.Monad.mapCount));
    }
  }
}
