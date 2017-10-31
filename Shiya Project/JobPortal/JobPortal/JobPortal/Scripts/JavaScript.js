

$(document).ready(function ()
{
    
    ListCandidate(0,0,0,0,"","");
    $("#Menu_GetCandidate").on('click', function () {
        ListCandidate(0, 0, 0, 0, '', '');
    });

    $("#Menu_GetEmployer").on('click', function () {
        ListEmployer(0,"","","");
    });
    $("#Menu_Jobs").on('click', function () {
        GetAllJobs( "", "",0,0,0);
    });
});


//CANDIDATE FUNCTIONS STARTS HERE--------------------------------------------------------------------------------------------------------------------------------------------------------
function ListCandidate(cand_id,cat_id,exp_id,loc_id,cand_name,skill)
{
    var params = { cand_id: cand_id,cat_id:cat_id, exp_id: exp_id, loc_id: loc_id, cand_name: cand_name, skill: skill };
    getData('/Admin/GetCandidateList', params, function (data, err)
    {
        if (!err)
        {
            if (data.HasWarning)
            {
                alert(data.Message);
            } else
            {
   
                GetPartialView(data);

            }
        }
    });

};

function SearchCandidate()
{
    var cand_name = document.getElementById("txt_Name").value;
    var skill = document.getElementById("txt_Skills").value;
    var exp_id = document.getElementById("Sel_Experience").value;
    var loc_id = document.getElementById("Sel_Location").value;
    var cat_id = document.getElementById("Sel_Category").value;

    ListCandidate(0, cat_id, exp_id, loc_id, cand_name, skill);
}

function Get_A_CandidateDetails(cand_id)
{
    var params={cand_id: cand_id};
    getData('/Admin/Get_A_CandidateDetails', params, function (data, err) {
        if (!err) {
            if (data.HasWarning) {
                alert(data.Message);
            } else
            {
                
                GetPartialView(data);
            }
        }
    });

};

function GetCandidateDeleteView(cand_id) {
    var params = { cand_id: cand_id };
    getData('/Admin/GetCandidateDeleteView', params, function (data, err) {
        if (!err) {
            if (data.HasWarning) {
                alert(data.Message);
            } else {

                GetPartialView(data);
            }
        }
    });

};

function DeleteCandidate(cand_id) {
    var params = { cand_id: cand_id };
    getData('/Admin/DeleteCandidate', params, function (data, err) {
        if (!err) {
            if (data.HasWarning)
            {
                alert(data.Message);
            } else
            {
                if (data == 1)
                    alert("Candidate  Successfully Deleted");
                else
                    alert("Deletion Failed");
                ListCandidate(0, 0, 0, 0, "", "");
                //SearchCandidate();
            }
        }
    });

};

//CANDIDATE FUNCTIONS ENDS HERE-------------------------------------------------------------------------------------------------------------------------------------------------

function SearchEmployer() {
    var EmpName = document.getElementById("txt_CompanyName").value;
    var EmpContact = document.getElementById("txt_Contact").value;
    var EmpStatus = document.getElementById("Sel_Status").value;
    
    ListEmployer(0, EmpName, EmpContact, EmpStatus);
}

function ListEmployer(empid, EmpName, EmpContact, EmpStatus)
{
    var params = { empid: empid, EmpName: EmpName, EmpContact: EmpContact, EmpStatus: EmpStatus };
    getData('/Admin/GetEmployerList', params, function (data, err) {
        if (!err)
        {
            if (data.HasWarning)
            {
                alert(data.Message);
            } else
            {
                GetPartialView(data);
            }
        }
    });
}

function Get_AnEmployerDetails(empid) {
    var params = { empid: empid };
    getData('/Admin/Get_AnEmployer', params, function (data, err) {
        if (!err) {
            if (data.HasWarning) {
                alert(data.Message);
            } else {

                GetPartialView(data);
            }
        }
    });

};

function GetEmployerDeleteView(empid) {
    var params = { empid: empid };
    getData('/Admin/GetEmployerDeleteView', params, function (data, err) {
        if (!err) {
            if (data.HasWarning) {
                alert(data.Message);
            } else {

                GetPartialView(data);
            }
        }
    });

};

function DeleteEmployer(empid) {
    var params = { empid: empid };
    getData('/Admin/DeleteEmployer', params, function (data, err) {
        if (!err) {
            if (data.HasWarning) {
                alert(data.Message);
            } else {
                if (data == 1)
                    alert("Employer  Successfully Deleted");
                else
                    alert("Deletion Failed");
                ListEmployer(0,'','','');
            }
        }
    });

};

function EditEmployerStatus(empid)
{
    var params = { EmpId: empid };
    getData('/Admin/EditEmployerStatus', params, function (data, err) {
        if (!err) {
            if (data.HasWarning) {
                alert(data.Message);
            } else
            {
                var divResult = $("#modal-body");
                divResult.html('');
                divResult.html(data);
                document.getElementById("hid_Empid").value = empid;
            }
        }
    });

};

function UpdateEmployerStatus() {
    
    var empid = document.getElementById("hid_Empid").value;
    var Status = document.getElementById("Emp_StatusId").value;
    if (Status == 0)
        Status = "False";
    else
        Status = "True";
    var params = { EmpId: empid, Status: Status }; 
    getData('/Admin/UpdateEmployerStatus', params, function (data, err) {
        if (!err) {
            if (data.HasWarning) {
                alert(data.Message);
            } else {
                if (data == 1)
                    alert("Status Updated");
                else
                    alert("Error!!! Try Again");
            }
        }
    });

};

function GetAllJobs(job_title, skill, cat_id, loc_id, exp_id)
{
    var params = { job_title: job_title, skill: skill, cat_id: cat_id, loc_id: loc_id, exp_id: exp_id };
    getData('/Admin/GetAllJobs', params, function (data, err) {
        if (!err) {
            if (data.HasWarning) {
                alert(data.Message);
            } else {
                GetPartialView(data);
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

function EditJobStatus(jobid) {
    var params = { jobid: jobid };
    getData('/Admin/EditJobStatus', params, function (data, err) {
        if (!err) {
            if (data.HasWarning) {
                alert(data.Message);
            } else {
                var divResult = $("#modal-body");
                divResult.html('');
                divResult.html(data);
                document.getElementById("hid_Jobid").value = jobid;
            }
        }
    });

};

function UpdateJobStatus() {

    var empid = document.getElementById("hid_Jobid").value;
    var Status = document.getElementById("Job_StatusId").value;
    if (Status == 0)
        Status = "False";
    else
        Status = "True";
    var params = { jobid: empid, Status: Status };
    getData('/Admin/UpdateJobStatus', params, function (data, err) {
        if (!err) {
            if (data.HasWarning) {
                alert(data.Message);
            } else {
                if (data == 1)
                    alert("Status Updated");
                else
                    alert("Error!!! Try Again");
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
//COMMON FUNCTIONS ENDS HERE--------------------------------------------------------------------------------------------------------------------------------------------------------------