
let columnNames = [];
let rows = 0;
let columns = 0;

function toggleDropdown() 
{
    document.getElementById("myDropdown").classList.toggle("show");
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

function erase(htmlElement)
{
    htmlElement.innerHTML = '';
}

function getTableChild(i, j) 
{
    if (i === 0)
    {
        return  document.createTextNode(columnNames[j]);
    }
    else
    {
        return document.createElement("input");
    }
}

function setTable(table) 
{
    for (let i = 0; i <= rows; ++i)
    {
        let row = document.createElement("tr");

        for (let j = 0; j < columns; ++j)
        {
            let cell = document.createElement("td");
            let child = getTableChild(i, j);

            cell.appendChild(child);
            row.appendChild(cell);
        }

        table.appendChild(row);
    }
}

function resizeTable(newRows, newColumns) 
{
    const table = document.getElementById("table");
    erase(table);
    setTableSize(newRows, newColumns);
    setTable(table);
}

function addColumn(columnType)
{
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

window.onclick = function(event)
{
    if (!event.target.matches('.dropbtn')) 
    {
        let dropdowns = document.getElementsByClassName("dropdown-content");
        let i;
        for (i = 0; i < dropdowns.length; i++) 
        {
            let openDropdown = dropdowns[i];
            if (openDropdown.classList.contains('show')) 
            {
                openDropdown.classList.remove('show');
            }
        }
    }
}