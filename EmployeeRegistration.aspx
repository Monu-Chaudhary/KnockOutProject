<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeRegistration.aspx.cs" Inherits="KnockOut.EmployeeRegistration" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/Styles/MainMaster.css" rel="stylesheet" type="text/css" />

    <link href="/Styles/Icon.css" rel="stylesheet" type="text/css" />
    <link href="/Styles/Style.css" rel="stylesheet" type="text/css" />
    <link href="/Styles/CustomStyle.css" rel="stylesheet" type="text/css" />
    <link href="/JsLibrary/Choosen/chosen.min.css" rel="stylesheet" type="text/css" />
    <link href="/Styles/jqueryAlerts.css" rel="stylesheet" type="text/css" />
    <link href="/Styles/jqx.base.css" rel="stylesheet" type="text/css" />
    <link href="/Styles/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="/Styles/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="/Styles/sm-core-css.css" rel="stylesheet" type="text/css" />
    <link href="/Styles/sm-mint.css" rel="stylesheet" type="text/css" />
    <link href="/Styles/Icon.css" rel="stylesheet" type="text/css" />
    <%--<link href="/Styles/Site.css" rel="stylesheet" type="text/css" />--%>
    <link href="/Styles/smartpaginator.css" rel="stylesheet" type="text/css" />
    <link href="/Styles/BeatPicker.min.css" rel="stylesheet" type="text/css" />


    <script src="/JsLibrary/jquery-2.1.3.js" type="text/javascript"></script>
    <script src="/JsLibrary/jqueryAlerts.js" type="text/javascript"></script>
    <script src="/JsLibrary/jquery-1.11.1.min.js" type="text/javascript"></script>
    <script src="/JsLibrary/bootstrap.js" type="text/javascript"></script>
    <script src="/JsLibrary/jquery_menus.js" type="text/javascript"></script>
    <script src="/JsLibrary/jquery.smartmenus.js" type="text/javascript"></script>
    <script src="/JsLibrary/knockout-3.1.0.js" type="text/javascript"></script>
    <script src="/JsLibrary/Common.js" type="text/javascript"></script>
    <script src="/JsLibrary/validation.js" type="text/javascript"></script>
    <script src="/JsLibrary/knockout.validation.js" type="text/javascript"></script>
    <script src="/JsLibrary/jquery.dropdownPlain.js" type="text/javascript"></script>
    <script src="/JsLibrary/tab.js" type="text/javascript"></script>
    <script src="/JsLibrary/SOSYS.Common.js" type="text/javascript"></script>
    <script src="/JsLibrary/ValidationBinders.js" type="text/javascript"></script>
    <script src="/JsLibrary/knockout.ajaxGrid.js" type="text/javascript"></script>
    <script src="/JsLibrary/chosen.jquery.min.js" type="text/javascript"></script>
    <script src="/JsLibrary/chosen.proto.min.js" type="text/javascript"></script>
    <script src="/JsLibrary/DateValidation.js" type="text/javascript"></script>
    <script src="/JsLibrary/bootstrap.min.js" type="text/javascript"></script>
    <script src="/JsLibrary/smartpaginator.js" type="text/javascript"></script>
    <script src="/JsLibrary/BeatPicker.min.js" type="text/javascript"></script>


</head>
<body>
   <%-- <form id="form1" runat="server">--%>
    <div class="container">
        
        <div class="row">
            <%--<div class="col-md-3">
                <h3>Employee List</h3>
            </div>--%>
            <div class="col-md-9">
                <h3>Employee List</h3>
            </div>
        </div>
        <br />

        <div class = "row">
            <div class="col-md-3">
                <select id="lstEmployee" class="form-control" multiple="multiple" style="min-height:637px; width:100%; color: #000000;" 
                
                    data-bind="options:Employees, optionsText: 'Name', optionsValue:'EmployeeId', optionsCaption: '...Choose...', value: SelectedEmployeeId ,event:{change:EmployeeDetails}">
                </select>
            </div>

            <div class="col-md-9">
                <div class="table-responsive">
                    <div class="table-form">
                        <div class="row">
                            <div class="form-group margin-bottom-0">
                                <label class="col-md-3 control-label text-top" for="textinput">
                                Employee ID: <span class="mandatory">*</span>
                                </label>
                                <div class="col-md-5">
                                    <input type="text" class="form-control" id="Text1" data-bind="value: EmployeeId" />
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="form-group margin-bottom-0">
                                <label class="col-md-3 control-label text-top" for="textinput">
                                Employee Name: <span class="mandatory">*</span>
                                </label>
                                <div class="col-md-5">
                                    <input type="text" id="textuserNameNep" data-bind="value: Name" class="required form-control" />
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="form-group margin-bottom-0">
                                <label class="col-md-3 control-label text-top" for="textinput">
                                    DOB:
                                </label>
                                <div class="col-md-5">
                                    <input id="txtDOB" class="form-control" name="Mobile" data-bind="value: DOB" />
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="form-group margin-bottom-0">
                                <label class="col-md-3 control-label text-top" for="textinput">
                                    Gender:
                                </label>
                                <div class="col-md-5">
                                    <input id="txtGender" class="form-control" name="Gender" data-bind="value: Gender" />
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="form-group margin-bottom-0">
                                <label class="col-md-3 control-label text-top" for="textinput">Salary:</label>
                                <div class="col-md-5">
                                    <input id="txtSalary" class="form-control" name="Salary" data-bind="value: Salary" />
                                </div>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="form-group margin-bottom-0">
                                <label class="col-md-3 control-label text-top" for="textinput" >
                                    Active: <span class="mandatory">*</span>
                                </label>
                                <div class="col-md-5">
                                    <input id="chkActive" type="checkbox" data-bind="checked: IsActive" style="float:left;" checked="checked" />
                                </div>
                            </div>
                        </div>
                        <br />

                        <h3>Qualifiaction List</h3>
                            <div class="row">
                                <div class="form-group margin-bottom-0">
                                    <label class="col-md-3 control-label text-top" for="textinput">
                                        Qual Name: <span class="mandatory">*</span>
                                    </label>
                                    <div class="col-md-5 dropdown">
                                        <select id="drpdnQual" class="dropdown-select"
                                            data-bind="options: QualificationLists, optionsText: 'QualName', optionsValue: $data, value: SelectedQualificationID, optionsCaption:'....Choose....'"></select>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="form-group margin-bottom-0" id="EmpID">
                                    <label class="col-md-3 control-label text-top" for="textinput">
                                        Marks: <span class="mandatory">*</span>
                                    </label>
                                    <div class="col-md-5">
                                        <input type="text" id="TxtMarks" class="form-control" name="Marks" data-bind="value:Marks" />
                                    </div>
                                </div>
                            </div>

                            <div class="form-group col-md-1 margin-bottom-0" id="addID">
                                <button class="btn icon-add btn-primary margin-left-15" data-bind="click: AddEmployeeQualification">
                                    Add
                                </button>
                            </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-lg-8">
                        <div class="table-responsive">
                            <table style="width: 100%;" data-bind="visible:toggle" border="0" class="dataTable table table-bordered table-condensed sort" id="showTable">
                                <tr>
                                    <th>Id</th>
                                    <th>QualId</th>
                                    <th>Qual Name</th>
                                    <th>Marks</th>
                                    <th>Action</th>
                                </tr>
                                <tbody data-bind="foreach: Qualifications">
                                    <tr>
                                        <td><span data-bind="text: ($index()+1)"></span></td>
                                        <td align="left"><span data-bind="text: QualId" style="width: 150px;"></span></td>
                                        <td align="left"><span data-bind="text: QualName" style="width: 150px;"></span></td>
                                        <td align="left"><span data-bind="text: Marks" style="width: 150px;"></span></td>
                                        <td align="left">
                                            <a data-bind="click:$root.EditQualification"><span style="color:Blue">Edit</span>
                                                <%--<span class="glyphicon glyphicon-trash" title="Edit" rel="tooltip"></span>--%>
                                            </a>
                                            <a data-bind="click: $parent.DeleteQual"> <span style="color:Red; padding-left:10px">Delete</span>
                                                <%--<span class="glyphicon glyphicon-trash" title="Delete" rel="tooltip"></span>--%>
                                            </a>
                                            <%--here the $root and $parent is equivalent to Qualifications--%>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>

            </div>


        </div>

        <div class="col-md-3 margin-top-15 pull-right">
            <button class="btn btn-primary" data-bind="click: SaveEmployee">Submit</button>
            <%--<button class="btn btn-primary" data-bind="click: UpdateQualification">Update</button>--%>
            <button class="btn btn-primary" data-bind="click: refresh ">Cancel</button>
        </div>

    </div>

    

    <script src="/Scripts/Member/User.js" type="text/javascript"></script>

    </body>
</html>
