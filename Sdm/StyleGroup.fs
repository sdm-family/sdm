namespace Sdm

open System
open System.Collections.Generic

[<AbstractClass>]
type StyleGroup (name: string) as self =
  static let names = Dictionary<string, Type>()
  do
    match names.TryGetValue(name) with
    | true, typ ->
        failwithf "%s is already used as style group name by %s." name typ.FullName
    | false, _ ->
        names.Add(name, self.GetType())

  override __.ToString() =
    let typ = names.[name]
    typ.Name + "(" + name + ")"

  member this.IsContained(groups: StyleGroup seq) =
    groups |> Seq.contains this

type TextStyleGroup (name: string) = inherit StyleGroup(name)
type ListStyleGroup (name: string) = inherit StyleGroup(name)
type TableStyleGroup (name: string) = inherit StyleGroup(name)
type ColumnStyleGroup (name: string) = inherit StyleGroup(name)
type RowStyleGroup (name: string) = inherit StyleGroup(name)
type CellStyleGroup (name: string) = inherit StyleGroup(name)

[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module StyleGroup =
  let contains x groups = groups |> Seq.contains x

[<AutoOpen>]
module Patterns =
  let (|Contains|_|) x groups =
    if StyleGroup.contains x groups then Some () else None