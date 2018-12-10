//Model for Employee

function Employee(data) {
    var self = this;
    self.EmployeeId = ko.observable(data.EmployeeId);
    self.Name = ko.observable(data.Name);
    self.Gender = ko.observable(data.Gender);
    self.DOB = ko.observable(data.DOB);
    self.Salary = ko.observable(data.Salary);
    self.IsActive = ko.observable(data.IsActive);
    self.Action = ko.observable(data.Action);
    self.Qualification = ko.observable(data.Qualification);
    //console.log(data);
}

//region structure for QualificationList
function QualificationList(data) {
    var self = this;
    self.QualId = ko.observable(data.QualId);
    self.QualName = ko.observable(data.QualName);
    self.Action = ko.observable(data.Action);
}

//region structure for qualification
function Qualification(data) {
    var self = this;
    self.EmployeeId = ko.observable(data.EmployeeId);
    self.QualId = ko.observable(data.QualId);
    self.QualName = ko.observable(data.QualName);
    self.Marks = ko.observable(data.Marks);
    self.Action = ko.observable(data.Action);
}


//ViewModel

var EmployeeRegestrationViewModel = function () {
    var self = this;

    //For Employee
    self.EmployeeId = ko.observable();
    self.Name = ko.observable();
    self.Gender = ko.observable();
    self.DOB = ko.observable();
    self.Salary = ko.observable();
    self.IsActive = ko.observable();
    self.Action = ko.observable();
    self.Qualification = ko.observable();

    //For Qualification
    self.Marks = ko.observable();

    //For QualificationList
    self.QualId = ko.observable();
    self.QualName = ko.observable();

    self.Employees = ko.observableArray([]);
    self.Qualifications = ko.observableArray([]);
    self.SelectedEmployeeId = ko.observable();
    self.QualificationLists = ko.observableArray([]);
    self.SelectedQualificationID = ko.observable();
    self.toggle = ko.observable();
    self.toggle(true);


    self.QualificationDetails = function () {
        debugger;
        waitMsg("Loading");
        waitMsg.show();

        $.ajax({
            dataType: "json",       //the type of data that is returned from the server
            cache: false,           //the data is not stored in cache
            async: false,           //synchronous data tranfer i.e. the statement that is calling needs to execute first before the next statement is executed...if async: true then the script will send a request to the browser and will continue executing other statements w/o waiting for the response from the browser.
            url: "../../../Handlers/Employee/EmployeeHandler.ashx",                                         //a string containing url to which the request is sent
            data: { 'method': 'GetQualificationDetails', 'EmployeeId': self.SelectedEmployeeId() },         //a plainobject(in this case) or an array or a string which is appended to the url for get request.
            contentType: "application/json; charset=utf-8",                                                 //it is either a boolean value or a string (in this case) which is sent to the server with the data. it is the type of data sent to the server.
            success: function (result) {                                    // a success function is called when the request is sucessful. the function get passed 3 arguments: data-the data returned from the server with its type defined by the DataType, [textStatus]- string defining the status, [jqXHR]- jQuery XMLHTTPRequest object .....[] implies optional parameter.
                waitMsg.hide();                                             
                if (result.IsSuccess) {
                    //debugger;
                    var mappedTask = $.map(result.ResponseData, function (item) {             //translates all item in an array or object (in this case)to a new array  of items. takes two parameters: an object/array and a callback function which returns a value as a flattened array.
                        return new Qualification(item)
                    });
                    //debugger;
                    self.Qualifications(mappedTask);
                }
                else {
                    msg(result.Message, "WARNING");
                }
            },
            error: function (err) {                                             // function when the request fails. 3 arguments: jqXHR, statustext, errorthrown
                waitMsg.hide();
                msg(err.status + " - " + err.statusText, "FAILURE");
            }
        });
    }



    self.GetQualificationList = function () {
        //debugger;
        $.ajax({
            dataType: "json",
            cache: false,
            async: false,
            url: '../../../Handlers/Employee/EmployeeHandler.ashx',
            data: { 'method': 'GetQualificationList', 'QualId': null },
            contentType: "application/json; charset=utf-8",
            success: function (result) {
                //debugger;
                var mappedTask = $.map(result.ResponseData, function (item) {
                    return new QualificationList(item)
                });

                self.QualificationLists(mappedTask);
                waitMsg.hide();
                //debugger;
            },
            error: function (err) {
                msg(err.status + " - " + err.statusText, "FAILURE");
            }
        });
    }

    self.GetQualificationList();

    self.GetEmployees = function () {
        //debugger;
        $.ajax({
            dataType: "json",
            cache: false,
            async: false,
            url: '../../../Handlers/Employee/EmployeeHandler.ashx',
            data: { 'method': 'GetEmployee', 'employeeId': null },
            contentType: "application/json; charset=utf-8",

            success: function (result) {                // result is an object.
                //console.log(result);
                //debugger;
                var mappedTask = $.map(result.ResponseData, function (item) {           //result.ResponseData is an object.
                    return new Employee(item)
                });
                //debugger;
                self.Employees(mappedTask);
            },
            error: function (err) {
                msg(err.status + " - " + err.statusText, "FAILURE");
            }
        });
    };

    self.GetEmployees();

    //AddEmployeeQualification
    self.AddEmployeeQualification = function () {
        debugger;
        if (self.ValidateQualification()) {
            var errMsg = "";
            var objFocus = null;
            var pro;
            var Acc = "A";
            var i;
            for (i = 0; i < this.Qualifications().length; i++) {
                if (ko.toJS(self.SelectedQualificationID().QualName) == this.Qualifications()[i].QualName()) {
                    var removeself = this.Qualifications()[i];
                    Acc = "E";
                    break;
                }
            }
            //debugger;
            pro = {
                QualId: self.SelectedQualificationID().QualId(),
                QualName: self.SelectedQualificationID().QualName(),
                Marks: self.Marks(),
                Action: Acc
            };

            if (Acc == "A") {
                self.Qualifications.push(new Qualification(pro));
            }
            else if (Acc == "E") {
                self.Qualifications()[i].Marks(pro.Marks)  //ko.toJS(pro.Marks);

                //self.Qualifications.replace(self.Qualifications()[i], new Qualification(pro));
            }
        }
    }

    self.ValidateQualification = function () {
        var errMsg = "";
        if (Validate.empty(self.Marks())) {
            errMsg += "Enter Marks!\n";
        }
        if (self.Marks() < 40 || self.Marks() > 100) {
            errMsg += "Enter Marks between 40 and 100!\n";
        }

        if (errMsg === "") {
            return true;
        }
        else {
            msg(errMsg);
            return false;
        }
    };

    // Save Employee
    self.SaveEmployee = function () {
        if (self.ValidateEmployee()) {
            debugger;
            var employeeAction = "";
            if (self.SelectedEmployeeId() == undefined) {
                employeeAction = "A";
            }
            if (self.SelectedEmployeeId() != undefined) {
                employeeAction = "E";
            }
            var employee = {

                EmployeeId: self.EmployeeId(),
                Name: self.Name(),
                DOB: self.DOB(),
                Gender: self.Gender(),
                Salary: self.Salary(),
                Qualification: self.Qualifications(),
                Action: employeeAction
            }

            var url = "../../../Handlers/Employee/EmployeeHandler.ashx";
            var data = { 'method': 'SaveEmployee', 'args': JSON.stringify(ko.toJS(employee)) };
            debugger;
            $.post(url, data, function (result) {
                debugger;
                var obj = jQuery.parseJSON(result);
                msg(obj.Message);
                if (obj.IsSuccess) {
                    self.GetEmployees();
                    self.QualificationLists([]);
                }
            });
        }
    }

    self.ValidateEmployee = function () {
        var errMsg = "";
        if (Validate.empty(self.Name())) {
            errMsg += "Enter Name!\n";
        }

        if (Validate.empty(self.DOB())) {
            errMsg += "Enter DOB!\n";
        }

        debugger;
        if (!self.DOB().match(/^\d{4}[\/]\d{2}[\/]\d{2}$/)) {
            errMsg += "Enter DOB in format yyyy/mm/dd!\n";
        }

        if (Validate.empty(self.Salary())) {
            errMsg += "Enter Salary!\n";
        }

        if (Validate.empty(self.Gender())) {
            errMsg += "Enter Gender!\n";
        }

        if (errMsg === "") {
            return true;
        }
        else {
            msg(errMsg);
            return false;
        }
    };



    self.EmployeeDetails = function () {
        debugger;

        if (self.SelectedEmployeeId() == null) {
            //
        }
        else {
            //debugger;

            $.ajax({
                dataType: "json",
                cache: false,
                async: false,
                url: '../../../Handlers/Employee/EmployeeHandler.ashx',
                data: { 'method': 'GetEmployeeDetails', 'EmployeeId': self.SelectedEmployeeId() },
                contentType: "application/json; charset=utf-8",
                success: function (result) {
                    var data = result.ResponseData[0];
                    self.EmployeeId(data.EmployeeId);
                    self.Name(data.Name);
                    self.DOB(data.DOB);
                    self.Gender(data.Gender);
                    self.Salary(data.Salary);
                    self.QualificationDetails();
                    //self.GetQualificationList();
                },
                error: function (err) {
                    console.log(err);
                    msg(err.status + " - " + err.statusText, "FAILURE");
                }
            });
        }
    }

    self.EditQualification = function (data) {
        //TODO
        debugger;
        console.log(data);
        self.Marks(data.Marks());
        //console.log(data.QualificationLists.QualName());
        console.log(data.QualName);
        for (var i = 0; i < self.QualificationLists().length; i++) {
            if (ko.toJS(self.QualificationLists()[i].QualName) == data.QualName()) {
                self.SelectedQualificationID(self.QualificationLists()[i]);
            }
        }
    }

    //    self.UpdateQualification = function () {
    //        if (self.ValidateEmployee()) {
    //            debugger;
    //            var QualAction = "";
    //            if (self.SelectedEmployeeId() == undefined) {
    //                QualAction = null;
    //            }
    //            else if (self.SelectedEmployeeId() != undefined) {
    //                QualAction = "I"
    //                if (self.SelectedQualificationID().QualId != undefined) {
    //                    QualAction = "U";

    //                }
    //            }

    //            var qualification = {
    //                EmployeeId: self.EmployeeId(),
    //                QualId: self.SelectedQualificationID().QualId(),
    //                Marks: self.Marks(),
    //                Action: QualAction
    //            }

    //            var url = "../../../Handlers/Employee/EmployeeHandler.ashx";
    //            var data = { 'method': 'UpdateQualification', 'args': JSON.stringify(ko.toJS(qualification)) };

    //            $.post(url, data, function (result) {
    //                var obj = jQuery.parseJSON(result);
    //                msg(obj.Message);
    //                if (obj.IsSuccess) {
    //                    self.QualificationLists([]);
    //                }
    //            });
    //        }
    //    }

    self.DeleteQual = function () {
        self.Qualifications.remove(this);
    }

    self.refresh = function () {
        location.reload();
    }

}


$(document).ready(function () {
    var EmployeeRegistrationModel = new EmployeeRegestrationViewModel();
    ko.applyBindings(EmployeeRegistrationModel);
});

