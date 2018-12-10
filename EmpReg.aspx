<%@ Page Title="" Language="C#" MasterPageFile="~/PCS.Master" AutoEventWireup="true" CodeBehind="EmpReg.aspx.cs" Inherits="KnockOut.EmpReg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <%-- <div class="container">
    <div class="row">
    <div class="col-md-3">
    <h3>Employee List </h3>
    </div>
    <div class="col-md-9">
    <h3>Employee List </h3>
    </div>
    </div><br />
        <div class="row">
       <div class="col-md-4">
       
<select id="lstEmployee" class="form-control" <%--style="min-height:637px; width:100%;" multiple="multiple"--%>
             data-bind='options:Employees , optionsText: "Name", optionsValue: "EmployeeId",
    optionsCaption: "------छान्नुहोस्-------"'></select>
    </div>
    </div>
    </div> 
--%>

   <%--
</select>
        </div>
            <div class="col-md-9">
                    
                    <div class="table-responsive">
                        
                        <table class="table-form">
                            <div class="row">  
                                <div class="form-group margin-bottom-0">
                                <label class="col-md-3 control-label text-top" for="textinput">
                                    Employee ID: <span class="mandatory">*</span></label>
                                <div class="col-md-5 ">
                                    <input type="text" class="form-control" id="Text1"
                                        data-bind="value: EmployeeId" />
                                </div> 
                               </div>
                              
                              </div>

                            <div class="row">
                                  <div class="form-group margin-bottom-0">
                                <label class="col-md-3 control-label text-top" for="textinput">
                                    Employee Name: <span class="mandatory">*</span></label>
                                <div class="col-md-5 ">
                         <input type="text" id="txtUserNameNep" 
                            data-bind="value: Name" class='required form-control' 
                           
                             /> 
                                </div>

                            </div></div>
                              
                            <div class="row">
                                    <div class="form-group margin-bottom-0">
                                <label class="col-md-3 control-label text-top" for="textinput">
                                   DOB: </label>
                                <div class="col-md-5 ">
<input type="text" id="txtDOB"  class="form-control" name="Mobile" data-bind="value: DOB"/>
                                </div>
                            </div>

                               </div>

                            <div class="row">
                                
                              <div class="form-group margin-bottom-0">
                                <label class="col-md-3 control-label text-top" for="textinput">
                                    Gender</label>
                                <div class="col-md-5 ">
<input type="text" id="txtGender"  class="form-control" name="Email" data-bind="value: Gender"/>
                                </div>
                            </div>
                                </div>
                            <div class="row">
                                
                              <div class="form-group margin-bottom-0">
                                <label class="col-md-3 control-label text-top" for="textinput">
                                    Salary</label>
                                <div class="col-md-5 ">
<input type="text" id="txtSalary"  class="form-control" name="Salary" data-bind="value: Salary"/>
                                </div>
                            </div>
                                    </div>  
                            
                           <div class="row">
                               
                                     <div class="form-group margin-bottom-0">
                                <label class="col-md-3 control-label text-top" for="textinput">
                                    Active: <span class="mandatory">*</span></label>
                                <div class="col-md-5 ">
  <input id="chkActive" type="checkbox" data-bind="checked: IsActive" style="float: left;"
                                        checked="checked" />
                                </div>
                            </div>

                                  </div>
                            
                          <h3>Qualification List</h3>
                            <div class="row">
                           <div class="form-group margin-bottom-0">
                                <label class="col-md-3 control-label text-top" for="textinput">
                                    Qual Name:<span class="mandatory">*</span></label>
                                <div class="col-md-5 dropdown">
                                    <select id="ddlQualification"   class="dropdown-select" 
                    data-bind='options: QualificationLists, optionsText: "QualName",
    optionsValue: $data, value:SelectedQualificationID, 
    optionsCaption:"------छान्नुहोस्-------"'></select>
                                </div>
                            </div>

                            </div>
                              
                            <div class="row">
                                       <div class="form-group margin-bottom-0" id="EmpIDNo">
                                <label class="col-md-3 control-label text-top" for="textinput">
                                    Marks <span class="mandatory">*</span></label>
                                <div class="col-md-5 ">
                           <input type="text" id="TxtMarks"  class="form-control" name="Marks" data-bind="value: Marks"/>
                                </div>
                            </div>
                           </div>
                      


   

         <div class="form-group col-md-1 margin-bottom-0" id="addID">
            <button class="btn icon-add btn-primary margin-left-15" data-bind="click: AddEmployeeQualification">
                            Add
                        </button>
                    </div>
              
 </div>
      
 
               
                        <div class="row" >

        <div class="col-lg-8">
            <div class="table-responsive">
                <table style="width: 100%;" data-bind="visible:toggle" border="0" class="dataTable table table-bordered table-condensed  sort" id="showTable">
                    <tr>
                        <th>
                            Id
                        </th>
                        <th>
                           QualId
                        </th>
                     
                        <th>
                           Qual Name
                        </th>
                        <th>
                          Marks
                        </th>
                          <th>
                           Action
                        </th>
                     
                    </tr>
                    <tbody data-bind="foreach:Qualifications ">
                        <!-- ko  if: Action()!='D' -->  
                        <tr>
                            <td>
                                <span data-bind="text: ($index() + 1)"></span>
                            </td>
                            <td align="left">
                                <span data-bind="text:QualId " style="width: 150px;" />
                            </td>
                            <td align="left">
                                <span data-bind="text:QualName " style="width: 150px;" />
                            </td>
                            <td align="left">
                                <span data-bind="text:Marks " style="width: 150px;" />
                            </td>
                              <td align="left">
                           <a data-bind="click:$root.EditQualification">
                                        <span class="glyphicon glyphicon-trash" title="Edit" rel="tooltip"></span>
                                        </a>
                                     <a data-bind="click:">
                                        <span class="glyphicon glyphicon-trash" title="Delete" rel="tooltip"></span>
                                        </a>
                                            </td>



                        </tr>
                        <!-- /ko -->
                    </tbody>
                </table>
            </div>
        </div>
    </div>
                   
              <div class="row">
             
            <div class="col-md-3 margin-top-15 pull-right">
                <button class="btn btn-primary" data-bind="click:SaveEmployee ">Submit</button>
                <button class="btn btn-primary" data-bind="click:UpdateQualification">Update</button>
                <button class="btn btn-primary" data-bind="click: ">Cancel</button>
            </div>
          </div>
          
            </div>
            <div class="clear"></div>
            
        </div>
--%>
    <%--<script src="Scripts/Member/User.js" type="text/javascript"></script>--%>


    <ul data-bind="foreach: places">
    <li data-bind="text: $data, event: { mouseover: $parent.logMouseOver }"> </li>
</ul>
<p>You seem to be interested in: <span data-bind="text: lastInterest"> </span></p>
 
 <script type="text/javascript">
         function MyViewModel() {
         var self = this;
         self.lastInterest = ko.observable();
         self.places = ko.observableArray(['London', 'Paris', 'Tokyo']);
         // The current item will be passed as the first parameter, so we know which place was hovered over
         self.logMouseOver = function (place) {
    self.lastInterest(place);
}
     }
     ko.applyBindings(new MyViewModel());
</script>


</asp:Content>