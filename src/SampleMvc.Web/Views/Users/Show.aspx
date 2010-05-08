<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SampleMvc.Web.Models.UserViewModel>" %>
<%@ Import Namespace="SampleMvc.Web.Controllers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Show
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Show</h2>

    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">Id</div>
        <div class="display-field"><%: Model.Id %></div>
        
        <div class="display-label">FirstName</div>
        <div class="display-field"><%: Model.FirstName %></div>
        
        <div class="display-label">LastName</div>
        <div class="display-field"><%: Model.LastName %></div>
        
        <div class="display-label">Age</div>
        <div class="display-field"><%: Model.Age %></div>
        
    </fieldset>
    <p>
        <%: Html.ActionLink<UsersController>(c => c.Edit(Model.Id), "Edit") %> |
        <%: Html.ActionLink<UsersController>(c => c.Index(), "Back to List") %>
    </p>

</asp:Content>

