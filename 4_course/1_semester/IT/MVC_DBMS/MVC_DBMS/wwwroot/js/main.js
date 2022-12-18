

function toggleDropdown() 
{
    document.getElementById("myDropdown").classList.toggle("show");
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