using System;
using System.Collections.Generic;
using System.Windows.Forms;

public class CellValidation
{
    private readonly Dictionary<string, IValidation> _validations = new Dictionary<string, IValidation>()
    {
        {DatabaseTypesName.STRING, new StringValidation()},
        {DatabaseTypesName.INT, new IntValidation()},
        {DatabaseTypesName.CHAR, new CharValidation()},
        {DatabaseTypesName.REAL, new RealValidation()},
        {DatabaseTypesName.COLOR, new ColorValidation()},
        {DatabaseTypesName.DATE, new DateValidation()},
    };

    public void TrySaveValue(DataGridViewCell cell, string column)
    {
        IValidation validation = _validations[column];

        if (cell.Value.ToString() == string.Empty)
            return;
        
        try
        {
            validation.Apply(cell.Value);
        }
        catch (Exception exception)
        {
            MessageBox.Show(exception.Message);
            cell.Value = string.Empty;
        }
    }
}