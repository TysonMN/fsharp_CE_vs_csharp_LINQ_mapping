using Xunit;
using MonadNamespace.LINQ;

namespace CSharp.Tests {
  public class CSharpTests {
    [Fact]
    public void CSharp_LINQ() {
      var mc =
        from a in MonadMoudle.Monad.ma
        from b in MonadMoudle.Monad.mb
        select a + b;
      var c = MonadClass.Value(mc);
      Assert.Equal(3, c);
      Assert.Equal((1, 1), (MonadMoudle.Monad.bindCount, MonadMoudle.Monad.mapCount));
    }
  }
}
