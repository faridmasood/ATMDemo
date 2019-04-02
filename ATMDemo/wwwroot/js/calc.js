
/* ------------------------------------------------------------*/
/*----------------- calculator------------------------------*/
/* ------------------------------------------------------------*/
var Memory = "0";      // initialise memory variable
var Current = "0";      //   and value of Display ("current" value)
var Operation = 0;      // Records code for eg * / etc.
var MAXLENGTH = 30;     // maximum number of digits before decimal!
var dig;
var op;

function AddDigit(dig)          //ADD A DIGIT TO DISPLAY (kept as 'Current')
{
    if (Current.length > MAXLENGTH) {
        Current = "Aargh! Too long"; //limit length
    } else {
        if ((eval(Current) === 0) && (Current.indexOf(".") === -1)) {
            Current = dig;
        } else {
            Current = Current + dig;
        }
    }
    console.log(Current);
    document.getElementById("demo").value = Current;
}

function Clear()                //CLEAR ENTRY
{
    Current = "0";
    document.getElementById("demo").value = Current;
}
function AddBigDigit(dig)          //ADD A Big DIGIT TO DISPLAY (kept as 'Current')
{
    if (Current.length > MAXLENGTH) {
        Current = "Aargh! Too long"; //limit length
    } else {
        if ((eval(Current) === 0) && (Current.indexOf(".") === -1)) {
            Current = dig;
        } else {
            Current = dig;
        }
    }
    console.log(Current);
    document.getElementById("demo").value = Current;
}




