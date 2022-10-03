using System;
using System.Windows.Forms;

public class Cell
{
    private readonly IValidation _validation;
    private readonly DataGridViewCell _view;

    public Cell(IValidation validation, DataGridViewCell view)
    {
        _validation = validation;
        _view = view;
    }

    public void TrySaveValue()
    {
        try
        {
            _validation.Apply(_view.Value);
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
            _view.Value = string.Empty;
        }
    }
}