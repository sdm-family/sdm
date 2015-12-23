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

type TextStyleGroup (name: string) = inherit StyleGroup(name)
type ListStyleGroup (name: string) = inherit StyleGroup(name)
type TableStyleGroup (name: string) = inherit StyleGroup(name)
type ColumnStyleGroup (name: string) = inherit StyleGroup(name)
type RowStyleGroup (name: string) = inherit StyleGroup(name)
type CellStyleGroup (name: string) = inherit StyleGroup(name)