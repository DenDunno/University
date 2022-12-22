using DbmsEmulator.Exceptions.Constants;
using DbmsEmulator.Exceptions;
using DbmsEmulator.Models.DbModels;
using DbmsEmulator.Models.RequestModels;
using DbmsEmulator.Convertation;
using DbmsEmulator.Constants;

#nullable disable

namespace DbmsEmulator.Services
{
    public class TableService
    {
        private readonly TableModel _table;

        public TableService(TableModel table)
        {
            _table = table;
        }

        public void AddColumn(string type)
        {
            _table.Columns.Add(new ColumnModel { Type = type.ToUpper() });

            for (int i = 0; i < _table.Rows.Count; i++)
            {
                _table.Rows[i].Row =_table.Rows[i].Row
                                            .Append(null).ToList();
            }
        }

        public void DeleteColumn(int index)
        {
            ColumnModel column = TryGetColumn(index);

            _table.Columns.Remove(column);

            if (_table.Columns.Count == 0)
            {
                _table.Rows = new List<RowModel>();
            }
            else
            {
                for (int i = 0; i < _table.Rows.Count; i++)
                {
                    _table.Rows[i].Row.RemoveAt(index - 1);
                }
            }
        }

        public void InsertRow(IEnumerable<object> row)
        {
            CheckRowSizeEqualsToColumnsAmount(row);

            List<string> values = new();

            row.ToList()
                .ForEach(value => values.Add(value?.ToString()));

            for (int i = 0; i < values.Count; i++)
            {
                ColumnModel column = TryGetColumn(i + 1);
                string value = values.ElementAt(i);

                CheckValueAndColumnTypeMatch(column.Type, value);
            }

            _table.Rows.Add(new RowModel { Row = values.ToList() });
        }

        public void DeleteRow(int index)
        {
            RowModel row = TryGetRow(index);

            _table.Rows.Remove(row);
        }

        public void SetValue(object value, CellInTable address)
        {
            ColumnModel column = TryGetColumn(address.ColumnNumber);
            RowModel row = TryGetRow(address.RowNumber);

            CheckValueAndColumnTypeMatch(column.Type, value.ToString());

            row.Row[address.ColumnNumber - 1] = value.ToString();
        }

        private ColumnModel TryGetColumn(int columnPosition)
        {
            try
            {
                return _table.Columns.ElementAt(columnPosition - 1);
            }
            catch
            {
                throw new NotFoundHttpException(ErrorMessages.ColumnNotFound);
            }
        }

        private RowModel TryGetRow(int rowPosition)
        {
            try
            {
                return _table.Rows.ElementAt(rowPosition - 1);
            }
            catch
            {
                throw new NotFoundHttpException(ErrorMessages.RowNotFound);
            }
        }

        private void CheckValueAndColumnTypeMatch(string type, string value) 
        {
            if (type != ColumnTypes.String)
            {
                TypeConverter converter = ConvertersProvider.GetConverter(type, value);

                if (!converter.IsConverted())
                {
                    throw new NotImplementedHttpException(ErrorMessages.ValueAndTypeDoNotMatch);
                }
            }
        }

        private void CheckRowSizeEqualsToColumnsAmount(IEnumerable<object> row)
        {
            if (row.Count() != _table.Columns.Count())
            {
                throw new NotImplementedHttpException(ErrorMessages.RowsSizeShouldBeEqualToColumns);
            }
        }
    }
}
