<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<DNE.WebMedia.Model.Aya>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	SuraAya
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>SuraAya</h2>

    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">Id</div>
        <div class="display-field"><%: Model.Id %></div>
        
        <div class="display-label">SuraId</div>
        <div class="display-field"><%: Model.SuraId %></div>
        
        <div class="display-label">AyaId</div>
        <div class="display-field"><%: Model.AyaId %></div>
        
        <div class="display-label">sura</div>
        <div class="display-field"><%: Model.sura %></div>
        
        <div class="display-label">Text</div>
        <div class="display-field"><%: Model.Text %></div>
        
        <div class="display-label">TextFull</div>
        <div class="display-field"><%: Model.TextFull %></div>
        
    </fieldset>
    <p>

        <%: Html.ActionLink("Edit", "Edit", new { id=Model.Id }) %> |
        <%: Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

