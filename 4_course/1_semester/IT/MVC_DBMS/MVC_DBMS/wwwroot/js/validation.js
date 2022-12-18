
let validation =
{
    "COLOR": (input) => validateColor(input),
    "INT": (input) => validateInt(input),
    "REAL": (input) => validateFloat(input),
    "CHAR": (input) => validateChar(input),
    "DATE": (input) => validateDate(input),
    "STRING": (input) => validateString(input)
}
    
function validateColor(input)
{
    let isValid = true;

    for (let i = 1; i < input.length && isValid; ++i)
    {
        let char = input[i];
        isValid = char >= '0' && char <= '9' || char >= 'A' && char <= 'F';
    }

    return isValid && input.length === 7 && input[0] === '#';
}

function validateInt(input)
{
    return isNaN(parseInt(input)) === false;
}

function validateFloat(input)
{
    return isNaN(parseFloat(input)) === false;
}

function validateChar(input)
{
    return input.length === 1;
}

function validateDate(dateString)
{
    if(!/^\d{1,2}\/\d{1,2}\/\d{4}$/.test(dateString))
        return false;

    const parts = dateString.split("/");
    const day = parseInt(parts[1], 10);
    const month = parseInt(parts[0], 10);
    const year = parseInt(parts[2], 10);

    if(year < 1000 || year > 3000 || month === 0 || month > 12)
        return false;

    const monthLength = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];

    if(year % 400 === 0 || (year % 100 !== 0 && year % 4 === 0))
        monthLength[1] = 29;

    return day > 0 && day <= monthLength[month - 1];
}

function validateString()
{
    return true;
}