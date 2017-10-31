function onset()
{
    document.getElementById("divfn1").style.visibility = 'hidden';
    document.getElementById("divsn1").style.visibility = 'hidden';
    document.getElementById("divmo1").style.visibility = 'hidden';
    document.getElementById("divbirth").style.visibility = 'hidden';
    document.getElementById("divpass").style.visibility = 'hidden';
    document.getElementById("divGen1").style.visibility = 'hidden';
    document.getElementById("ttfn").style.visibility = 'hidden';
    document.getElementById("ttsn").style.visibility = 'hidden';
    document.getElementById("ttm").style.visibility = 'hidden';
    document.getElementById("ttp").style.visibility = 'hidden';
    document.getElementById("ttdob").style.visibility = 'hidden';
    document.getElementById("ttg").style.visibility = 'hidden';
    
}

function fn(x)
{
    if (x == '')
    {
        document.getElementById("fn").className = "firstNameAlt";
        document.getElementById("divfn1").style.visibility = 'visible';
        document.getElementById("ttfn").style.visibility = 'hidden';
    }
    else {
        document.getElementById("fn").className = "firstName";
        document.getElementById("divfn1").style.visibility = 'hidden';
        document.getElementById("ttfn").style.visibility = 'hidden';
    }
}
function sn(x)
{
    if (x == '')
    {
        document.getElementById("sn").className = "surnameAlt";
        document.getElementById("divsn1").style.visibility = 'visible';
        document.getElementById("ttsn").style.visibility = 'hidden';
    }
    else {
        document.getElementById("sn").className = "surname";
        document.getElementById("divsn1").style.visibility = 'hidden';
        document.getElementById("ttsn").style.visibility = 'hidden';
    }
}
function me(x)
{
    if (x == '') {
        document.getElementById("me").className = "meAlt";
        document.getElementById("divmo1").style.visibility = 'visible';
        document.getElementById("ttm").style.visibility = 'hidden';
    }
    else {
        document.getElementById("me").className = "MobileOrEmail";
        document.getElementById("divmo1").style.visibility = 'hidden';
        document.getElementById("ttm").style.visibility = 'hidden';
    }
}
function ps(x)
{
    if (x == '') {
        document.getElementById("ps").className = "psAlt";
        document.getElementById("divpass").style.visibility = 'visible';
        document.getElementById("ttp").style.visibility = 'hidden';
    }
    else {
        document.getElementById("ps").className = "newPassword";
        document.getElementById("divpass").style.visibility = 'hidden';
        document.getElementById("ttp").style.visibility = 'hidden';
    }
}
function dobf2(x)
{
    var x = document.getElementById("dob").value;
    var y = document.getElementById("dobM").value;
    var z = document.getElementById("dobY").value;
        if (x == 'Select') {
            document.getElementById("dob").className = "dAlt";
            document.getElementById("dobM").className = "mAlt";
            document.getElementById("dobY").className = "yAlt";
            document.getElementById("divbirth").style.visibility = 'visible';
        }
        else if (y == 'Select') {
            document.getElementById("dob").className = "dAlt";
            document.getElementById("dobM").className = "mAlt";
            document.getElementById("dobY").className = "yAlt";
            document.getElementById("divbirth").style.visibility = 'visible';
        }
        else if (z == 'Select') {
            document.getElementById("dob").className = "dAlt";
            document.getElementById("dobM").className = "mAlt";
            document.getElementById("dobY").className = "yAlt";
            document.getElementById("divbirth").style.visibility = 'visible';
        }
        else
        {
            document.getElementById("dob").className = "day";
            document.getElementById("dobM").className = "month";
            document.getElementById("dobY").className = "year";
            document.getElementById("divbirth").style.visibility = 'hidden';
        }

}
function gen()
{
        var d = document.getElementById("gender").checked;
        var e = document.getElementById("gender1").checked;
        if (d == true) {
            return true;
        }
        else if (e == true) {
            return true;
        }

        else {
            document.getElementById("divGen1").style.visibility = 'visible';
        }
}
function fcheck()
{
    //var firstname = document.forms["myForm"]["fn"].value;
    //var surname = document.forms["myForm"]["sn"].value;
    //var mobile = document.forms["myForm"]["me"].value;
    //var password = document.forms["myForm"]["ps"].value;

    //if (firstname == '') {
    //    document.getElementById("fn").className = "firstNameAlt";
    //    document.getElementById("divfn1").style.visibility = 'visible';
    //}
    //else {
    //    document.getElementById("fn").className = "firstName";
    //    document.getElementById("divfn1").style.visibility = 'hidden';
    //}
}

function fn1(x) {
    //document.getElementById("simpleSearchDiv").style.visibility = 'visible'; 
    //var test = document.getElementById("fn");
    //var testClass = test.className;
    //alert(testClass)
    //var t = document.getElementById("fn");
    //var tc = t.className;
    //alert(tc)
    if (x == '') {
        document.getElementById("fn").className = "firstNameAlt";
        document.getElementById("divfn1").style.visibility = 'visible';
    }
    else {
        document.getElementById("fn").className = "firstName";
        document.getElementById("divfn1").style.visibility = 'hidden';
    }
}
function sn1(x) {
    if (x == '') {
        document.getElementById("sn").className = "surnameAlt";
        document.getElementById("divsn1").style.visibility = 'visible';
    }
    else {
        document.getElementById("sn").className = "surname";
        document.getElementById("divsn1").style.visibility = 'hidden';
    }
}
function me1(x) {
    if (x == '') {
        document.getElementById("me").className = "meAlt";
        document.getElementById("divmo1").style.visibility = 'visible';
    }
    else {
        document.getElementById("me").className = "MobileOrEmail";
        document.getElementById("divmo1").style.visibility = 'hidden';
    }
}
function ps1(x) {
    if (x == '') {
        document.getElementById("ps").className = "psAlt";
        document.getElementById("divpass").style.visibility = 'visible';
    }
    else {
        document.getElementById("ps").className = "newPassword";
        document.getElementById("divpass").style.visibility = 'hidden';
    }
}
function dobf3(x) {
    var x = document.getElementById("dob").value;
    var y = document.getElementById("dobM").value;
    var z = document.getElementById("dobY").value;
    if (x == 'Select') {
        document.getElementById("dob").className = "dAlt";
        document.getElementById("dobM").className = "mAlt";
        document.getElementById("dobY").className = "yAlt";
        document.getElementById("divbirth").style.visibility = 'visible';
    }
    else if (y == 'Select') {
        document.getElementById("dob").className = "dAlt";
        document.getElementById("dobM").className = "mAlt";
        document.getElementById("dobY").className = "yAlt";
        document.getElementById("divbirth").style.visibility = 'visible';
    }
    else if (z == 'Select') {
        document.getElementById("dob").className = "dAlt";
        document.getElementById("dobM").className = "mAlt";
        document.getElementById("dobY").className = "yAlt";
        document.getElementById("divbirth").style.visibility = 'visible';
    }
    else {
        document.getElementById("dob").className = "day";
        document.getElementById("dobM").className = "month";
        document.getElementById("dobY").className = "year";
        document.getElementById("divbirth").style.visibility = 'hidden';
    }
}
function dobf4(x) {
        var x = document.getElementById("dob").value;
        var y = document.getElementById("dobM").value;
        var z = document.getElementById("dobY").value;
        if (x == 'Select') {
            document.getElementById("dob").className = "dAlt";
            document.getElementById("dobM").className = "mAlt";
            document.getElementById("dobY").className = "yAlt";
            document.getElementById("divbirth").style.visibility = 'visible';
        }
        else if (y == 'Select') {
            document.getElementById("dob").className = "dAlt";
            document.getElementById("dobM").className = "mAlt";
            document.getElementById("dobY").className = "yAlt";
            document.getElementById("divbirth").style.visibility = 'visible';
        }
        else if (z == 'Select') {
            document.getElementById("dob").className = "dAlt";
            document.getElementById("dobM").className = "mAlt";
            document.getElementById("dobY").className = "yAlt";
            document.getElementById("divbirth").style.visibility = 'visible';
        }
        else {
            document.getElementById("dob").className = "day";
            document.getElementById("dobM").className = "month";
            document.getElementById("dobY").className = "year";
            document.getElementById("divbirth").style.visibility = 'hidden';
        }

    }
function dobfd() {
    var t = document.getElementById("check").value = 1
    }


    function testfn()
    {
        var fn = document.getElementById("fn");
        var tfn = fn.className;
        if (tfn == 'firstNameAlt') {
            document.getElementById("ttfn").style.visibility = 'visible';
        }
    }
    function testsn() {
        var sn = document.getElementById("sn");
        var tsn = sn.className;
        if (tsn == 'surnameAlt') {
            document.getElementById("ttsn").style.visibility = 'visible';
        }
    }
    function testm() {
        var m = document.getElementById("me");
        var tm = m.className;
        if (tm == 'meAlt') {
            document.getElementById("ttm").style.visibility = 'visible';
        }
    }
    function testp() {
        var m = document.getElementById("ps");
        var tm = m.className;
        if (tm == 'psAlt') {
            document.getElementById("ttp").style.visibility = 'visible';
        }
    }
    function test()
    {
        if (document.getElementById("check").value == 1)
        {
        var x = document.getElementById("dobd").value;
        var y = document.getElementById("dobM").value;
        var z = document.getElementById("dobY").value;
        if (x == 'Select') {
            document.getElementById("dobd").className = "dAlt";
            document.getElementById("dobM").className = "mAlt";
            document.getElementById("dobY").className = "yAlt";
            document.getElementById("divbirth").style.visibility = 'visible';
        }
        else if (y == 'Select') {
            document.getElementById("dobd").className = "dAlt";
            document.getElementById("dobM").className = "mAlt";
            document.getElementById("dobY").className = "yAlt";
            document.getElementById("divbirth").style.visibility = 'visible';
        }
        else if (z == 'Select') {
            document.getElementById("dobd").className = "dAlt";
            document.getElementById("dobM").className = "mAlt";
            document.getElementById("dobY").className = "yAlt";
            document.getElementById("divbirth").style.visibility = 'visible';
        }
        else {
            document.getElementById("dobd").className = "day";
            document.getElementById("dobM").className = "month";
            document.getElementById("dobY").className = "year";
            document.getElementById("divbirth").style.visibility = 'hidden';
            document.getElementById("check").value = 0
        }
        }
    }