namespace Sdm

type TextSegment = {
  StyleGroups: TextStyleGroup list
  Value: string
}

type Text = {
  Segments: TextSegment list
}

[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module TextSegment =
  let create (styleGroups, value) =
    { StyleGroups = styleGroups; Value = value }

  let fromString (str: string) = create ([], str)

[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module Text =
  let create segments = { Segments = segments }

  let fromTextSegment segment =
    create [ segment ]

  let map f text = text.Segments |> List.map f

  let fold f seed text = text.Segments |> List.fold f seed