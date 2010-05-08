<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SampleMvc.Web.Models.UserViewModel>" %>
<%@ Import Namespace="SampleMvc.Web.Controllers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	New
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>New</h2>

    <% using (Html.BeginForm<UsersController>(c => c.Create())) {%>
        <%: Html.ValidationSummary(true) %>

        <%: Html.EditorForModel() %>
        <p>
            <input type="submit" value="Create" />
        </p>
    <% } %>

    <div>
        <%: Html.ActionLink<UsersController>(c => c.Index(), "Back to List") %>
    </div>

</asp:Content>

