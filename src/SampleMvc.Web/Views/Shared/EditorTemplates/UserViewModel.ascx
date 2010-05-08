<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<SampleMvc.Web.Models.UserViewModel>" %>

<fieldset>
    <legend>Fields</legend>
            
    <div class="editor-field">
        <%: Html.HiddenFor(model => model.Id) %>
    </div>
            
    <div class="editor-label">
        <%: Html.LabelFor(model => model.FirstName) %>
    </div>
    <div class="editor-field">
        <%: Html.TextBoxFor(model => model.FirstName) %>
        <%: Html.ValidationMessageFor(model => model.FirstName) %>
    </div>
            
    <div class="editor-label">
        <%: Html.LabelFor(model => model.LastName) %>
    </div>
    <div class="editor-field">
        <%: Html.TextBoxFor(model => model.LastName) %>
        <%: Html.ValidationMessageFor(model => model.LastName) %>
    </div>
            
    <div class="editor-label">
        <%: Html.LabelFor(model => model.Age) %>
    </div>
    <div class="editor-field">
        <%: Html.TextBoxFor(model => model.Age) %>
        <%: Html.ValidationMessageFor(model => model.Age) %>
    </div>
</fieldset>