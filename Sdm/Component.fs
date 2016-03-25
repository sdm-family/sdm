namespace Sdm

type Component =
  | Heading of TextStyleGroup list * Level:int * Value:Text
  | Paragraph of TextStyleGroup list * Lines:Text list
  | List of ListStyleGroup list * Items:Components list
  | Table of TableStyleGroup list * TableContents
and Components = Component list
and TableContents =
  | RowsTable of ColumnStyleGroup list * ColumnContents list
  | ColumnsTable of RowStyleGroup list * RowContents list
and ColumnContents = {
  Heading: TableHeading option
  Rows: (CellStyleGroup list * Components) list
}
and RowContents = {
  Heading: TableHeading option
  Columns: (CellStyleGroup list * Components) list
}
and TableHeading = {
  StyleGroups: CellStyleGroup list
  Content: Components
}