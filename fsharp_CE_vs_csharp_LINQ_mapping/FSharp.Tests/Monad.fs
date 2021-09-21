module MonadModule

open System.Runtime.CompilerServices
open System


type Monad<'a> = Monad of 'a

module Monad =
  let ma = Monad 1
  let mb = Monad 2

  let mutable mapCount = 0
  let mutable bindCount = 0

  let map f (Monad a) =
    mapCount <- mapCount + 1
    a |> f |> Monad

  let bind f (Monad a) =
    bindCount <- bindCount + 1
    a |> f


type Builder internal () =

  member __.Bind(m: Monad<'a>, f: 'a -> Monad<'b>) : Monad<'b> =
    m |> Monad.bind f

  member __.Yield(a: 'a) : Monad<'a> =
    Monad a

  member __.Combine(_: Monad<unit>, m: Monad<'a>) : Monad<'a> =
    m

  member __.Delay(f : unit -> Monad<'a>) : Monad<'a> =
    f ()

  // Zero isn't needed, but the IntelliSense compiler gives an error without it
  member __.Zero() : Monad<unit> =
    Monad ()


let monad = Builder ()
