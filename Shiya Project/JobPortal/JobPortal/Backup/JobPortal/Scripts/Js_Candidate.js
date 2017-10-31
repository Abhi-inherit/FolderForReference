$(document).ready(function ()
{

    $("#Menu_SearchJobs").on('click', function () {
        Candidate_SearchJobs(0,0,0,'','');
    });

    $("#Menu_EditProfile").on('click', function () {
        EditProfile();
    });

    $("#Menu_ProfileHistory").on('click', function () {
        ProfileHistory();
    });


    $("input[id^='Cat_']").live('change', function () {
        SearchJobs();
    });
    $("input[id^='Loc_']").live('change', function () {
        SearchJobs();
    });
    $("input[id^='Exp_']").live('change', function () {
        SearchJobs();
    });

});

function ProfileHistory() {
    getData('/Candidate/ProfileHistory', null, function (data, err) {
        if (!err) {
            if (data.HasWarning) {
                alert(data.Message);
            } else {
                GetPartialView(data);
            }
        }
    });
}

function EditProfile() {
    getData('/Candidate/EditProfile', null, function (data, err) {
        if (!err) {
            if (data.HasWarning) {
                alert(data.Message);
            } else {
                GetPartialView(data);
            }
        }
    });
}

function Candidate_SearchJobs(cat_id, exp_id, loc_id, job_title, skill)
{

    var params = { cat_id: cat_id, exp_id: exp_id, loc_id: loc_id, job_title: job_title, skill: skill };
    getData('/Candidate/Candidate_SearchJobs', params, function (data, err) {
        if (!err) {
            if (data.HasWarning) {
                alert(data.Message);
            } else {

                GetPartialView(data);
                GetCategoryCheckBox();
                GetLocationCheckBox();
                GetExperienceCheckBox();

            }
        }
    });
}

function SearchJobs()
{
    var job_title = document.getElementById("txt_JobName").value;
    var skill = document.getElementById("txt_Skills").value;
    var cat_id = ($("input[id^='Cat_']:checked").map(function () { return this.value; }).get().join(","));
    var loc_id = ($("input[id^='Loc_']:checked").map(function () { return this.value; }).get().join(","));
    var exp_id = ($("input[id^='Exp_']:checked").map(function () { return this.value; }).get().join(","));

    Candidate_SearchJobs(cat_id, exp_id, loc_id, job_title, skill);
}

function GetCategoryCheckBox() {
    getData('/Candidate/Bind_Category', null, function (data, err) {
        if (!err) {
            if (data.HasWarning) {
                alert(data.Message);
            } else {
                var divResult = $("#Category");
                divResult.html('');
                divResult.html(data);
            }
        }
    });
}

function GetLocationCheckBox() {
    getData('/Candidate/Bind_Location', null, function (data, err) {
        if (!err) {
            if (data.HasWarning) {
                alert(data.Message);
            } else {
                var divResult = $("#Location");
                divResult.html('');
                divResult.html(data);
            }
        }
    });
}

function GetExperienceCheckBox() {
    getData('/Candidate/Bind_Experience', null, function (data, err) {
        if (!err) {
            if (data.HasWarning) {
                alert(data.Message);
            } else {
                var divResult = $("#Experience");
                divResult.html('');
                divResult.html(data);
            }
        }
    });
}



function Get_A_JobDetails(jobid) {

    var params = { jobid: jobid };
    getData('/Candidate/GetJobDetails', params, function (data, err) {
        if (!err) {
            if (data.HasWarning) {
                alert(data.Message);
            } else {

                GetPartialView(data);
            }
        }
    });

};

function ApplyJob(jobid)
{
    var params = { jobid: jobid };
    getData('/Candidate/ApplyJob', params, function (data, err) {
        if (!err) {
            if (data.HasWarning) {
                alert(data.Message);
            } else {
                if (data== 1)
                    alert("Your job application has been submitted");
                else if(data==2)
                    alert("You have applied this job before.");
                else
                    alert("Failed");
            }
        }
    });

};

//COMMON FUNCTIONS STARTS HERE----------------------------------------------------------------------------------------------------------------------------------------------------------
function GetPartialView(data) {
    var divResult = $("#DivContent");
    divResult.html('');
    divResult.html(data);
}

function postData(methodUrl, params, cb) {
    $.ajax({
        url: methodUrl,
        type: 'POST',
        async: false,
        cache: false,
        data: JSON.stringify(params),
        crossDomain: true,
        success: function (data, statusCode, xhr) {
            cb(data, null);
        },
        error: function (xhr, errType, ex) {
            cb(null, ex || xhr.statusText);
        }
    });
}

function getData(methodUrl, params, cb) {

    $.ajax({
        url: methodUrl,
        type: 'GET',
        async: true,
        data: params,

        success: function (data, statusCode, xhr) {
            cb(data, null);
        },
        error: function (xhr, errType, ex) {
            cb(null, ex || xhr.statusText);
        }
    });
}
//COMMON FUNCTIONS ENDS HERE---------------