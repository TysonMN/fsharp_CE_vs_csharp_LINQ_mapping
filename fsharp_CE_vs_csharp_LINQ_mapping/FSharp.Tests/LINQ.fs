namespace MonadNamespace.LINQ

open System
open System.Runtime.CompilerServices
open MonadMoudle


type MonadClass private () =
  static member Value (ma: Monad<'a>) =
    let (Monad a) = ma
    a


[<Extension>]
[<AbstractClass; Sealed>]
type Extensions private () =

  [<Extension>]
  static member Select (ma: Monad<'a>, f: Func<'a, 'b>) : Monad<'b> =
    ma |> Monad.map f.Invoke

  [<Extension>]
  static member SelectMany (ma: Monad<'a>, f: Func<'a, Monad<'b>>) : Monad<'b> =
    ma |> Monad.bind f.Invoke

  [<Extension>]
  static member SelectMany (ma: Monad<'a>, f: Func<'a, Monad<'b>>, g : Func<'a, 'b, 'c>) : Monad<'c> =
    ma |> Monad.bind (fun a ->
      a |> f.Invoke |> Monad.map (fun b -> g.Invoke(a, b)))
