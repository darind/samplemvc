<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SampleMvc.Web.Models.UserViewModel>" %>
<%@ Import Namespace="SampleMvc.Web.Controllers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit</h2>

    <% using (Html.BeginForm<UsersController>(c => c.Update(null))) {%>
        <%: Html.ValidationSummary(true) %>
        <%: Html.HttpMethodOverride(HttpVerbs.Put) %>
        <%: Html.HiddenFor(model => model.Id) %>
        <%: Html.EditorForModel() %>
        <p>
            <input type="submit" value="Save" />
        </p>
    <% } %>

    <div>
        <%: Html.ActionLink<UsersController>(c => c.Index(), "Back to List") %>
    </div>

</asp:Content>

