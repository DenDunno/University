const input = document.querySelector('input');
const log = document.getElementById('values');

input.addEventListener('input', updateValue);

function toggleDropdown() 
{
    document.getElementById("myDropdown").classList.toggle("show");
}

function addColumn(columnType)
{
    console.log(columnType);
}

function removeColumn()
{
    console.log('remove column');
}

function addRow()
{
    console.log('add row');
}

function removeRow()
{
    console.log('remove row');
}

function updateValue(e)
{
    log.textContent = e.target.value;
}

window.onclick = function(event) {
    if (!event.target.matches('.dropbtn')) {
        var dropdowns = document.getElementsByClassName("dropdown-content");
        var i;
        for (i = 0; i < dropdowns.length; i++) {
            var openDropdown = dropdowns[i];
            if (openDropdown.classList.contains('show')) {
                openDropdown.classList.remove('show');
            }
        }
    }
}