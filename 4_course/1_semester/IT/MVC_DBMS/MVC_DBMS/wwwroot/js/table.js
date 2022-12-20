
let columnNames = [];
let rows = 0;
let columns = 0;

function showUpOtherButtons() 
{
    document.getElementById("removeRowButton").hidden = false;
    document.getElementById("addRowButton").hidden = false;
    document.getElementById("removeColumnButton").hidden = false;
}

function addColumn(columnType)
{
    showUpOtherButtons();
    columnNames.push(columnType);
    resizeTable(rows, columns + 1);
}

function removeColumn()
{
    if (columns === 1)
        return;

    columnNames.pop();
    resizeTable(rows, columns - 1);
}

function addRow()
{
    resizeTable(rows + 1, columns);
}

function removeRow()
{
    resizeTable(rows - 1, columns);
}

function finishEditing()
{
    const table = document.getElementById("table");
    let names = readNames(table);
    let values = readTable(table);
    let tableName = document.getElementById("tableName").textContent;
    
    $.post('FinishTableEditing', { tableJson: JSON.stringify({ Name: tableName, Names : names, Data: values })});
}

function readNames(table)
{
    let result = []
    let header = table.rows[0];
    
    for (let i = 0; i < columns; ++i)
    {
        result.push(header.cells[i].firstChild.textContent);
    }
    
    return result;
}

function resizeTable(newRows, newColumns)
{
    const table = document.getElementById("table");
    let values = readTable(table);
    setTableSize(newRows, newColumns);
    erase(table);
    setTable(table, values);
}

function erase(htmlElement)
{
    htmlElement.innerHTML = '';
}

function setTableSize(newRows, newColumns)
{
    rows = newRows;
    columns = newColumns;

    if (rows === 0)
        rows = 1;

    if (columns === 0)
        columns = 1;
}

function readTable(table)
{
    let result = [[]];

    for (let i = 1; i < table.rows.length; ++i)
    {
        let row = table.rows[i];
        result.push(new Array(row.cells.length));

        for (let j = 0; j < row.cells.length; ++j)
        {
            result[i][j] = row.cells[j].firstChild.value;
        }
    }
    
    result.shift();
    
    return result;
}

function setTable(table, values)
{
    for (let i = 0; i <= rows; ++i)
    {
        let row = document.createElement("tr");

        for (let j = 0; j < columns; ++j)
        {
            let cell = document.createElement("td");
            let child = getTableChild(i, j, values);

            cell.appendChild(child);
            row.appendChild(cell);
        }

        table.appendChild(row);
    }
}

function getTableChild(i, j, values)
{
    if (i === 0)
    {
        return document.createTextNode(columnNames[j]);
    }
    else
    {
        let input = document.createElement("input");
        
        if (i - 1 < values.length && j < values[0].length)
        {
            input.value = values[i - 1][j];
            input.style.color = validation[columnNames[j]](input.value) ? "black" : "red";
        }
        
        input.oninput = function()
        {
            input.style.color = validation[columnNames[j]](input.value) ? "black" : "red";
        };
        
        return input;
    }
}

function setup(rows_input, columns_input)
{
    const table = document.getElementById("table");
    rows = rows_input;
    columns = columns_input;
    columnNames = readNames(table);
    
    if (columns !== 0)
        showUpOtherButtons();
}