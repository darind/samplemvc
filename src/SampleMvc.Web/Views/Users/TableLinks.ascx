<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<SampleMvc.Web.Models.UserViewModel>" %>
<%@ Import Namespace="SampleMvc.Web.Controllers" %>

<td>
    <%: Html.ActionLink<UsersController>(c => c.Edit(Model.Id), "Edit") %> |
    <%: Html.ActionLink<UsersController>(c => c.Show(Model.Id), "Details") %> |
    <% using (Html.BeginForm<UsersController>(c => c.Destroy(Model.Id))) { %>
        <%: Html.HttpMethodOverride(HttpVerbs.Delete) %>
        <input type="submit" value="Delete" />
    <% } %>
</td>