<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<SampleMvc.Web.Models.UserViewModel>" %>
<%@ Import Namespace="SampleMvc.Web.Controllers" %>

<td>
    <%: Html.ActionLink<UsersController>(c => c.Edit(Model.Id), "Edit") %> |
    <%: Html.ActionLink<UsersController>(c => c.Show(Model.Id), "Details") %> |
    <% using (Html.BeginForm<UsersController>(c => c.Destroy())) { %>
        <%: Html.HttpMethodOverride(HttpVerbs.Delete) %>
        <%: Html.HiddenFor(model => model.Id) %>
        <input type="submit" value="Delete" />
    <% } %>
</td>