<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<SuraIndex>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	SuraIndex
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>SuraIndex</h2>
    <div class="suraindex">
    <%for (int i = 0; i < Model.Count; i++) {
          %>
          <div><%=Model[i].SuraNo %>. <a href='Pages/<%=Model[i].Min %>'><%=Model[i].Sura %></a> 
          from page: <a href='Pages/<%=Model[i].Min %>'><%=Model[i].Min %></a> to: <a href='Pages/<%=Model[i].Max %>'><%=Model[i].Max %></a></div>
          <%
      } %>
      </div>
</asp:Content>
