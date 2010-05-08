<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<SampleMvc.Web.Models.UserViewModel>>" %>
<%@ Import Namespace="SampleMvc.Web.Models" %>
<%@ Import Namespace="SampleMvc.Web.Controllers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Index</h2>
    <%: Html.Grid<UserViewModel>(Model)
        .Columns(column => {
            column.For("TableLinks").Named("");
            column.For(model => model.FirstName);
            column.For(model => model.LastName);
            column.For(model => model.Age);
        })
    %>
    <p>
        <%: Html.ActionLink<UsersController>(c => c.New(), "Create New") %>
    </p>
</asp:Content>