namespace Sdm

type Component =
  | Heading of TextStyleGroup list * Level:int * Value:Text
  | Paragraph of TextStyleGroup list * Lines:Text list
  | List of ListStyleGroup list * Items:Component list
  | Table of TableStyleGroup list * TableContents
and TableContents =
  | RowsTable of ColumnStyleGroup list * ColumnContents list
  | ColumnsTable of RowStyleGroup list * RowContents list
and ColumnContents = {
  Heading: TableHeading option
  Rows: (CellStyleGroup list * Component) list
}
and RowContents = {
  Heading: TableHeading option
  Columns: (CellStyleGroup list * Component) list
}
and TableHeading = {
  StyleGroups: CellStyleGroup list
  Content: Component
}