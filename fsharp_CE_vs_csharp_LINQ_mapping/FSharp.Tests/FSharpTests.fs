module Tests

open Xunit
open MonadMoudle


let assertions c =
  Assert.Equal(3, c)
  Assert.Equal((1, 1), (Monad.bindCount, Monad.mapCount))


[<Fact>]
let FSharp_functions () =
  let (Monad c) =
    Monad.ma |> Monad.bind (fun a ->
      Monad.mb |> Monad.map (fun b ->
        a + b))
  assertions c


[<Fact>]
let FSharp_CE () =
  let (Monad c) =
    monad {
      let! a = Monad.ma
      let! b = Monad.mb
      return a + b
    }
  assertions c
