$(document).ready(function ()
{
    SearchJobs('', '', 0, 0, 0);
    $("#Menu_CandidateSearch").on('click', function () {
        GetAppliedCandidates();
    });
    $("#Menu_EditProfile").on('click', function () {
        EditProfile();
    });
    $("#Menu_PostJobs").on('click', function () {
        SearchJobs('','',0,0,0);
    });

});


function ViewCandidateProfile(candid) {
    var params = { candid: candid };
    getData('/Employer/ViewCandidateProfile', params, function (data, err) {
        if (!err) {
            if (data.HasWarning) {
                alert(data.Message);
            } else {
                var divResult = $("#modal-body");
                divResult.html('');
                divResult.html(data);
            }
        }
    });

}
function ChangeCandProfileStatus(candid, jobid)
{
    var params = { candid: candid, jobid: jobid };
    getData('/Employer/ChangeCandProfileStatus', params, function (data, err) {
        if (!err) {
            if (data.HasWarning) {
                alert(data.Message);
            } else
            {
                var divResult = $("#modal-body");
                divResult.html('');
                divResult.html(data);
                document.getElementById("hd_CandId").value = candid;
                document.getElementById("hd_JobId").value = jobid;
            }
        }
    });

}

function UpdateCandProfileStatus()
{
    var status = document.getElementById("CandProfile_StatusId").value;
    var candid = document.getElementById("hd_CandId").value;
    var jobid = document.getElementById("hd_JobId").value;

    var params = { candid: candid, jobid: jobid, status: status };
    getData('/Employer/UpdateCandProfileStatus', params, function (data, err) {
        if (!err) {
            if (data.HasWarning) {
                alert(data.Message);
            } else {
                var divResult = $("#modal-body");
                divResult.html('');
                divResult.html(data);
            }
        }
    });

}

function GetAppliedCandidates() {
    getData('/Employer/GetAppliedCandidates', null, function (data, err) {
        if (!err) {
            if (data.HasWarning) {
                alert(data.Message);
            } else {
                GetPartialView(data);
            }
        }
    });

}


function SearchJobs(job_title, skill, cat_id, loc_id, exp_id)
{
    var params = { job_title: job_title, skill: skill, cat_id: cat_id, loc_id: loc_id, exp_id: exp_id };
    getData('/Employer/GetJobsPosted', params, function (data, err) {
        if (!err) {
            if (data.HasWarning) {
                alert(data.Message);
            } else {
                GetPartialView(data);
            }
        }
    });

}

function SearchProcessing()
{
    var job_title = document.getElementById("txt_JobName").value;
    var skill = document.getElementById("txt_Skills").value;
    var cat_id = document.getElementById("Sel_Category").value;
    var loc_id = document.getElementById("Sel_Location").value;
    var exp_id = document.getElementById("Sel_Experience").value;

    SearchJobs(job_title, skill, cat_id, loc_id, exp_id);
}
function EditProfile()
{
    getData('/Employer/EditProfile', null, function (data, err)
    {
        if (!err)
        {
            if (data.HasWarning)
            {
                alert(data.Message);
            } else {
                GetPartialView(data);
            }
        }
    });
}

function PostNewJob() {
    getData('/Employer/Create', null, function (data, err) {
        if (!err) {
            if (data.HasWarning) {
                alert(data.Message);
            } else {
                var divResult = $("#modal-body");
                divResult.html('');
                divResult.html(data);
            }
        }
    });
}

function EditJob(jobid) {
    var params = { jobid: jobid };
    getData('/Employer/Edit', params, function (data, err) {
        if (!err) {
            if (data.HasWarning) {
                alert(data.Message);
            } else {
                var divResult = $("#modal-body");
                divResult.html('');
                divResult.html(data);
            }
        }
    });
}

function SaveJob() {
    getData('/Employer/SaveJob', null, function (data, err) {
        if (!err) {
            if (data.HasWarning) {
                alert(data.Message);
            } else {
                if (data > 0)
                {
                    var divResult = $("#modal-body");
                    divResult.html('');
                    divResult.html("Job Saved Successfully");
                }
            }
        }
    });
}

function ViewJob(jobid) {
    var params = { jobid: jobid };
    getData('/Employer/ViewJob', params, function (data, err) {
        if (!err) {
            if (data.HasWarning) {
                alert(data.Message);
            } else {
                var divResult = $("#modal-body");
                divResult.html('');
                divResult.html(data);
            }
        }
    });
}

function DeleteJob(jobid) {
    if (confirm("Are you sure to delete this job?"))
    {
        var params = { jobid: jobid };
        getData('/Employer/DeleteJob', params, function (data, err) {
            if (!err) {
                if (data.HasWarning) {
                    alert(data.Message);
                } else
                {
                    if (data > 0) {
                        SearchProcessing();
                        alert("Job has been deleted successfully");

                    }
                    else
                        alert("Deletion Failed");
                }
            }
        });
    }
    return false;
   
}

function GetAppliedCandidates() {
    getData('/Employer/GetAppliedCandidates', null, function (data, err) {
        if (!err) {
            if (data.HasWarning) {
                alert(data.Message);
            } else {
                GetPartialView(data);
            }
        }
    });

}


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